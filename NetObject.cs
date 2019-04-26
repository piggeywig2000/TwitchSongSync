using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Stuff I added
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace TwitchSongSync
{
    class NetObject
    {
        private TcpClient client;
        private NetworkStream stream;
        private Queue<string> sendQueue = new Queue<string>();
        private Queue<string> receiveQueue = new Queue<string>();
        
        private const int waitTime = 10;

        public void Send(string message)
        {
            if (!IsClosed) { sendQueue.Enqueue(message); }
        }
        public bool ReceiveQueueIsEmpty
        {
            get
            {
                if (receiveQueue.Count == 0) { return true; }
                else { return false; }
            }
        }
        public string Receive()
        {
            if (!IsClosed) { return receiveQueue.Dequeue(); }
            else { return "closed¶"; }
        }

        public bool IsClosed = false;


        public NetObject(TcpClient thisClient)
        {
            client = thisClient;
            stream = client.GetStream();

            Thread sendThread = new Thread(new ThreadStart(SendThread)) { IsBackground = true, Name = "Network Send" };
            Thread receiveThread = new Thread(new ThreadStart(ReceiveThread)) { IsBackground = true, Name = "Network Receive" };

            sendThread.Start();
            receiveThread.Start();
        }

        private void SendThread()
        {
            try
            {
                while (true)
                {
                    while (sendQueue.Count == 0)
                    {
                        Thread.Sleep(waitTime);
                    }

                    string messageString = sendQueue.Dequeue();

                    Byte[] data = Encoding.Unicode.GetBytes(messageString);

                    Byte[] length = BitConverter.GetBytes(data.Length);

                    Byte[] sendBytes = new Byte[length.Length + data.Length];
                    length.CopyTo(sendBytes, 0);
                    data.CopyTo(sendBytes, 4);

                    stream.Write(sendBytes, 0, sendBytes.Length);
                }
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("IOException on send thread");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("ObjectDisposedException on send thread");
            }
            finally
            {
                //Signal that it closed
                receiveQueue.Enqueue("closed¶");
            }
        }

        private void ReceiveThread()
        {
            try
            {
                while (true)
                {
                    //Get the length first
                    Byte[] byteLength = new Byte[4];
                    stream.Read(byteLength, 0, 4);
                    int length = BitConverter.ToInt32(byteLength, 0);

                    //If the length is 0, the socket is closed, so break out to trigger the closed
                    if (length == 0) { break; }

                    //Now get the data
                    List<Byte[]> responseList = new List<byte[]>();
                    //Keep reading from the stream until we have the whole message
                    int bytesLeft = length;
                    int received;
                    while (bytesLeft > 0)
                    {
                        Byte[] byteResponse = new Byte[length];
                        received = stream.Read(byteResponse, 0, bytesLeft);
                        bytesLeft -= received;
                        Array.Resize(ref byteResponse, received);

                        responseList.Add(byteResponse);
                    }
                    //Finally, put it all into one byte
                    Byte[] receiveByte = new Byte[length];
                    int currentPosition = 0;
                    foreach (Byte[] responsePiece in responseList)
                    {
                        responsePiece.CopyTo(receiveByte, currentPosition);
                        currentPosition += responsePiece.Length;
                    }

                    string response = Encoding.Unicode.GetString(receiveByte);

                    receiveQueue.Enqueue(response);
                }
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("IOException on receive thread");
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("ObjectDisposedException on receive thread");
            }
            finally
            {
                //Signal that it closed
                receiveQueue.Enqueue("closed¶");
            }
        }
    }
}

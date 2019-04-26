using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Stuff I added
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace TwitchSongSync
{
    class NetGuest : NetGeneric
    {
        private TcpClient client;
        private NetObject comms;

        private string[] names;

        private const int waitTime = 10;

        public NetGuest(FormMain thisForm) : base(thisForm)
        {
            client = new TcpClient();
        }

        public void ConnectAndGo(IPAddress ip, ushort port)
        {
            //Connect
            try { client.Connect(ip, port); }
            catch (SocketException) { theForm.dgShowError("Failed to connect to host", true); return; }

            //Create NetObject
            comms = new NetObject(client);

            //Create thread
            Thread threadMgr = new Thread(new ThreadStart(StartGuestManagement)) { IsBackground = true, Name = "Guest Manager" };
            threadMgr.Start();
        }

        private void StartGuestManagement()
        {
            //Request for names list and script data
            //comms.Send("getNames¶");
            //comms.Send("getScript¶");

            while (true)
            {
                //Networking receive
                if (!comms.ReceiveQueueIsEmpty)
                {
                    string response = comms.Receive();

                    //We got the response, now process it
                    Tuple<string, string> tResponse = FormatResponse(response);

                    string opcode = tResponse.Item1;
                    string operand = tResponse.Item2;

                    switch (opcode)
                    {
                        case "setNames":
                            names = FormatOperand(operand);
                            
                            theForm.dgUpdateUsersListbox(names);
                            theForm.dgUpdateScriptTable(names);
                            break;

                        case "updateScript":
                            theForm.ScriptEntries = JsonConvert.DeserializeObject<List<ScriptEntry>>(operand);
                            
                            theForm.dgUpdateScriptTable(names);
                            break;

                        case "closed":
                            theForm.dgShowError("Connection closed", true);
                            break;

                        case "preparingToRun":
                            PreparingToRun = Convert.ToBoolean(operand);
                            nextScript = 0;

                            comms.Send("ready¶" + operand);
                            break;

                        case "running":
                            myIndex = Convert.ToInt32(operand);

                            IsRunning = true;
                            break;

                        case "updateSettings":
                            string[] settings = FormatOperand(operand);
                            theForm.dgUpdateSettings(settings[0], settings[1]);
                            break;

                        default:
                            break;
                    }
                }

                //Form receive
                if (!theForm.FormActionIsEmpty)
                {
                    string response = theForm.GetFormAction();

                    //We got the response, now process it
                    Tuple<string, string> tResponse = FormatResponse(response);

                    string opcode = tResponse.Item1;
                    string operand = tResponse.Item2;

                    switch (opcode)
                    {
                        case "changeName":
                            comms.Send("changeName¶" + operand);

                            break;
                    }
                }

                //If its running, check if we need to enter anything into twitch
                CheckForScript();

                Thread.Sleep(waitTime);
            }
        }
    }
}

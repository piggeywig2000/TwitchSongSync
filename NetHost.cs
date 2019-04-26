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
using System.Diagnostics;

namespace TwitchSongSync
{
    class NetHost : NetGeneric
    {
        private class PersonInformation
        {
            public readonly TcpClient client;
            public readonly NetObject comms;
            public string name;
            public readonly bool isHost;
            public bool isReady;

            public PersonInformation(TcpClient thisClient)
            {
                if (thisClient == null)
                {
                    client = null;
                    comms = null;
                    name = "HOST";
                    isHost = true;
                    isReady = false;
                }
                else
                {
                    client = thisClient;
                    comms = new NetObject(client);
                    name = "GUEST";
                    isHost = false;
                    isReady = false;
                }
            }
            public PersonInformation(TcpClient thisClient, string thisName)
            {
                if (thisClient == null)
                {
                    client = null;
                    comms = null;
                    name = thisName;
                    isHost = true;
                }
                else
                {
                    client = thisClient;
                    comms = new NetObject(client);
                    name = thisName;
                    isHost = false;
                }
            }
        }

        private TcpListener server;
        private List<PersonInformation> clients = new List<PersonInformation>();
        
        private const int waitTime = 10;

        public NetHost(FormMain thisForm, IPAddress ip, ushort port) : base(thisForm)
        {
            clients.Add(new PersonInformation(null));
            server = new TcpListener(ip, port);
        }

        public void StartListening()
        {
            Thread threadLst = new Thread(new ThreadStart(ListeningThread)) { IsBackground = true, Name = "Host Listener" };
            Thread threadMgr = new Thread(new ThreadStart(StartHostManagement)) { IsBackground = true, Name = "Host Manager" };

            threadLst.Start();
            threadMgr.Start();
        }

        private void ListeningThread()
        {
            try { server.Start(); }
            catch (SocketException) { theForm.dgShowError("Failed to start server on this IP address and port", true); return; }
            while (true)
            {
                Console.WriteLine("Waiting for connection...");
                TcpClient client = server.AcceptTcpClient();
                //Check that we're not running the script. If we are, reject them
                if (PreparingToRun)
                {
                    Console.WriteLine("Rejected as script is running");
                    client.Close();
                }
                else
                {
                    Console.WriteLine("Connected!");

                    clients.Add(new PersonInformation(client));

                    //Send information about the new client
                    SendUserList();
                    SendScript();
                    SendSettings();
                    theForm.dgUpdateUsersListbox(GetNames());
                    theForm.dgUpdateScriptTable(GetNames());
                }
            }
        }

        private void StartHostManagement()
        {
            theForm.dgUpdateUsersListbox(GetNames());

            while (true)
            {
                //Get something from the network received queue and process it
                int lengthOfClients = clients.Count;
                Queue<PersonInformation> toRemove = new Queue<PersonInformation>();
                for (int i=0; i<lengthOfClients; i++)
                {
                    //Skip if it's ourselves
                    if (clients[i].isHost) { continue; }
                    //Skip if nothing has been received
                    if (clients[i].comms.ReceiveQueueIsEmpty) { continue; }

                    string response = clients[i].comms.Receive();

                    //We got the response, now process it
                    Tuple<string, string> tResponse = FormatResponse(response);

                    string opcode = tResponse.Item1;
                    string operand = tResponse.Item2;

                    switch (opcode)
                    {
                        case "changeName":
                            if (operand != "")
                            {
                                clients[i].name = operand;
                                SendUserList();
                                theForm.dgUpdateUsersListbox(GetNames());
                                theForm.dgUpdateScriptTable(GetNames());
                            }

                            SendUserList();
                            theForm.dgUpdateUsersListbox(GetNames());
                            theForm.dgUpdateScriptTable(GetNames());
                            break;
                            
                        case "getNames":
                            SendUserList();
                            break;

                        case "getScript":
                            SendScript();
                            break;

                        case "ready":
                            clients[i].isReady = Convert.ToBoolean(operand);
                            break;

                        case "closed":
                            toRemove.Enqueue(clients[i]);
                            break;

                        default:
                            break;
                    }
                }

                //Remove requested
                if (toRemove.Count > 0)
                {
                    while (toRemove.Count > 0) { clients.Remove(toRemove.Dequeue()); }
                    SendUserList();
                    theForm.dgUpdateUsersListbox(GetNames());
                    theForm.dgUpdateScriptTable(GetNames());

                    //If we're running or preparing to run, handle the disconnect
                    if (PreparingToRun)
                    {
                        SetMyIndexAndReady(true);
                        SendRunning();
                    }

                }

                //Get something from the form received queue and process it
                if (!theForm.FormActionIsEmpty)
                {
                    string response = theForm.GetFormAction();

                    //We got the response, now process it
                    Tuple<string, string> tResponse = FormatResponse(response);

                    string opcode = tResponse.Item1;
                    string operand = tResponse.Item2;

                    switch (opcode)
                    {
                        case "moveUser":
                            string[] fOperand = FormatOperand(operand);
                            int userIndex = Convert.ToInt32(fOperand[1]);

                            if (fOperand[0] == "0")
                            {
                                //Up
                                if (userIndex > 0)
                                {
                                    PersonInformation client = clients[userIndex];
                                    clients.RemoveAt(userIndex);
                                    clients.Insert(userIndex - 1, client);
                                }
                            }
                            else if (fOperand[0] == "1")
                            {
                                //Down
                                if (userIndex < clients.Count - 1)
                                {
                                    PersonInformation client = clients[userIndex];
                                    clients.RemoveAt(userIndex);
                                    clients.Insert(userIndex + 1, client);
                                }
                            }

                            SendUserList();
                            theForm.dgUpdateUsersListbox(GetNames());
                            theForm.dgUpdateScriptTable(GetNames());

                            break;

                        case "changeName":
                            for(int i=0; i<clients.Count; i++)
                            {
                                if (clients[i].isHost == true)
                                {
                                    clients[i].name = operand;
                                }
                            }

                            SendUserList();
                            theForm.dgUpdateUsersListbox(GetNames());
                            theForm.dgUpdateScriptTable(GetNames());

                            break;

                        case "updateScript":
                            theForm.dgUpdateScriptTable(GetNames());
                            SendScript();

                            break;

                        case "run":
                            //Set the preparing to run flag. This will change whether it is in lockdown, rejecting new clients
                            PreparingToRun = Convert.ToBoolean(operand);

                            //Set ourselves to be ready
                            SetMyIndexAndReady(Convert.ToBoolean(operand));

                            nextScript = 0;

                            //Tell everyone we're changing the preparing to run flag
                            SendMessage("preparingToRun¶" + operand);
                            break;

                        case "updateSettings":
                            SendSettings();
                            break;

                        default:
                            break;
                    }
                }

                //If it's preparing to run, check if everyone has set their ready flag
                if (PreparingToRun && !IsRunning)
                {
                    bool everyoneReady = true;
                    foreach (PersonInformation client in clients)
                    {
                        if (!client.isReady) { everyoneReady = false; }
                    }

                    //If everyone is ready, tell them to begin, and set the running flag to true
                    if (everyoneReady)
                    {
                        SendRunning();

                        IsRunning = true;
                    }
                }

                //If its running, check if we need to enter anything into twitch
                CheckForScript();

                Thread.Sleep(waitTime);
            }
        }

        private string[] GetNames()
        {
            string[] names = new string[clients.Count];

            //Build list of names
            for (int i = 0; i < clients.Count; i++)
            {
                names[i] = clients[i].name;
            }

            return names;
        }

        private void SetMyIndexAndReady(bool isReady)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].isHost == true)
                {
                    clients[i].isReady = isReady;
                    //Set the myIndex to the index of the host
                    myIndex = i;
                }
            }
        }

        private void SendMessage(string message)
        {
            foreach (PersonInformation client in clients)
            {
                if (!client.isHost)
                {
                    client.comms.Send(message);
                }
            }
        }

        private void SendUserList()
        {
            string[] namesArr = GetNames();
            string names = string.Join("¶", namesArr);
            
            SendMessage("setNames¶" + names);
        }

        private void SendScript()
        {
            string jsonObject = JsonConvert.SerializeObject(theForm.ScriptEntries);
            
            SendMessage("updateScript¶" + jsonObject);
        }

        private void SendSettings()
        {
            SendMessage("updateSettings¶" + theForm.Prefix + "¶" + theForm.Suffix);
        }

        private void SendRunning()
        {
            for(int i=0;i<clients.Count;i++)
            {
                if (!clients[i].isHost)
                {
                    clients[i].comms.Send("running¶" + i.ToString());
                }
            }
        }
    }
}

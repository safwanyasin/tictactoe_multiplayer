using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml.Serialization;
using static server.Form1;

namespace server
{


    public partial class Form1 : Form
    {

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<User> clientSockets = new List<User>();
        List<User> waitingusers = new List<User>();
        static string[] arr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static readonly int MAX_CLIENTS = 2; // Maximum number of clients allowed to connect
        static readonly int WAIT_CLIENTS = 2; // Maximum number of clients allowed to wait
        static int connectedClients = 0; // Current number of connected clients
        static string playerTurn;
        static int startingwin = 0;
        static int otherwin = 0;
        static int draws = 0;
        static int rounds = 0;
        static int flag = 0;
        bool terminating = false;
        bool terminatingwait = false;
        bool listening = false;
        string startingPlayer, otherPlayer, nextplayer;
        bool gameStarted = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match
            else if (arr[1] != "1" && arr[2] != "2" && arr[3] != "3" && arr[4] != "4" && arr[5] != "5" && arr[6] != "6" && arr[7] != "7" && arr[8] != "8" && arr[9] != "9")
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }

        private bool duplicateUsername(string username)
        {

            foreach (User user in clientSockets)
            {
                if (user.username == username)
                {
                    return true;
                }
            }
            foreach (User user in waitingusers)
            {
                if (user.username == username)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(5);

                listening = true;
                button_listen.Enabled = false;
                //textBox_message.Enabled = true;
                //button_send.Enabled = true;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                
                try
                {

                    User newUser = new User();
                    newUser.serverSocket = serverSocket.Accept();
                    
                    // logs.AppendText("I have accecpted user" + connectedClients+ "\n");
                    //connectedClients++;


                    logs.AppendText("Client connection in progress.\n");

                    if (connectedClients < (WAIT_CLIENTS + MAX_CLIENTS))
                    {
                       
                        connectedClients++;

                        Byte[] buffer = new Byte[64];
                        newUser.serverSocket.Receive(buffer);

                        string incomingMessage = Encoding.Default.GetString(buffer);
                        incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                        newUser.username = incomingMessage;

                        if (connectedClients < 3)
                        {
                            if (duplicateUsername(incomingMessage))
                            {
                                byte[] message2 = Encoding.Default.GetBytes("Duplicate username. Please reconnect");
                                connectedClients--;
                                newUser.serverSocket.Send(message2);
                                newUser.serverSocket.Shutdown(SocketShutdown.Both);
                                newUser.serverSocket.Close();
                                logs.AppendText("Client could not connect.\n");
                            }
                            else
                            {
                                byte[] message = Encoding.Default.GetBytes("You have succesfully connected");
                                newUser.serverSocket.Send(message);
                                clientSockets.Add(newUser);
                                
                                logs.AppendText("A client, " + incomingMessage + ", has connected\n");
                                Thread receiveThread = new Thread(() => Receiveforgame(newUser)); // updated
                                receiveThread.Start();
                                if (connectedClients == MAX_CLIENTS)
                                {
                                    Thread.Sleep(700);
                                    broadCast("Two connected. Game starting");
                                    
                                    logs.AppendText("Two connected. Game starting\n");
                                    Random rnd = new Random();
                                    int num = rnd.Next(2);

                                    if (num == 1)
                                    {
                                        otherPlayer = clientSockets[0].username;
                                        startingPlayer = clientSockets[1].username;
                                    }
                                    else
                                    {
                                        otherPlayer = clientSockets[1].username;
                                        startingPlayer = clientSockets[0].username;
                                    }
                                    Thread.Sleep(50);
                                    logs.AppendText(startingPlayer + " (X) starts. " + otherPlayer + " is O\n");
                                    broadCast(startingPlayer + " (X) starts. " + otherPlayer + " is O");
                                    playerTurn = clientSockets[num].username;
                                    //startingPlayer = clientSockets[1].username;
                                    gameStarted = true;

                                }
                            }
                        }
                        else if (connectedClients > 2 && connectedClients < 5)
                        {
                            if (duplicateUsername(incomingMessage))
                            {
                                byte[] message2 = Encoding.Default.GetBytes("Duplicate username. Please reconnect");
                                connectedClients--;
                                newUser.serverSocket.Send(message2);
                                newUser.serverSocket.Shutdown(SocketShutdown.Both);
                                newUser.serverSocket.Close();
                                logs.AppendText("Client could not connect.\n");
                            }
                            else
                            {
                                byte[] message = Encoding.Default.GetBytes("You have succesfully connected");
                                newUser.serverSocket.Send(message);
                                waitingusers.Add(newUser);
                                
                                logs.AppendText("A client, " + incomingMessage + ", has connected\n");
                                Thread receiveThread = new Thread(() => Receiveforwait(newUser)); // updated
                                receiveThread.Start();
                                if (connectedClients == MAX_CLIENTS)
                                {

                                    broadCast("Two connected. Game starting");
                                    logs.AppendText("Two connected. Game starting\n");
                                    Random rnd = new Random();
                                    int num = rnd.Next(2);

                                    if (num == 1)
                                    {
                                        otherPlayer = clientSockets[0].username;
                                        startingPlayer = clientSockets[1].username;
                                    }
                                    else
                                    {
                                        otherPlayer = clientSockets[1].username;
                                        startingPlayer = clientSockets[0].username;
                                    }
                                    Thread.Sleep(50);
                                    logs.AppendText(startingPlayer + " (X) starts. " + otherPlayer + " is O\n");
                                    broadCast(startingPlayer + " (X) starts. " + otherPlayer + " is O");
                                    playerTurn = clientSockets[num].username;
                                    //startingPlayer = clientSockets[1].username;
                                    gameStarted = true;

                                }
                            }

                        }




                    }
                    else
                    {
                        //logs.AppendText("i am in else \n");
                        //Socket clientSocket = serverSocket.Accept();
                        byte[] errorMessage = Encoding.Default.GetBytes("0001");
                        newUser.serverSocket.Send(errorMessage);
                        Thread.Sleep(100);
                        newUser.serverSocket.Shutdown(SocketShutdown.Both);
                        newUser.serverSocket.Close();
                    }
                    


                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receiveforgame(User thisClient) // updated
        {
            bool connected = true;
            byte[] Message1 = Encoding.Default.GetBytes("A" + startingwin.ToString());
            byte[] Message2 = Encoding.Default.GetBytes("B" + otherwin.ToString());
            byte[] Message3 = Encoding.Default.GetBytes("@" + draws.ToString());
            byte[] Message4 = Encoding.Default.GetBytes("R" + rounds.ToString());

            thisClient.serverSocket.Send(Message1);
            Thread.Sleep(100);
            thisClient.serverSocket.Send(Message2);
            Thread.Sleep(100);
            thisClient.serverSocket.Send(Message3);
            Thread.Sleep(100);
            thisClient.serverSocket.Send(Message4);
            Thread.Sleep(100);

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    thisClient.serverSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    //logs.AppendText(thisClient.username + ":" + incomingMessage + "\n");

                    if (thisClient.username == playerTurn)
                    {
                        int input;
                        int status;
                        bool checkRange = Int32.TryParse(incomingMessage, out input);

                        if (checkRange && input >= 1 && input <= 9)
                        {
                            if (arr[input] == incomingMessage)
                            {
                                if (thisClient.username == startingPlayer)
                                {
                                    arr[input] = "X";
                                    // check win
                                    status = CheckWin();
                                    playerTurn = otherPlayer;
                                    if (status == 0)
                                    {
                                        broadCast("X" + incomingMessage);
                                        logs.AppendText("X played " + incomingMessage+"\n");
                                        Thread.Sleep(50);
                                        broadCast("O's turn");
                                        logs.AppendText("O's turn.\n");


                                    }
                                    else if (status == -1)
                                    {
                                        // draw
                                        broadCast("X" + incomingMessage);
                                        draws++;
                                        gameEnd(-1, "");
                                        logs.AppendText("Game was a draw.\n");
                                        logs.AppendText("Games won by Player 1(X): " + startingwin + ".\n");
                                        logs.AppendText("Games won by Player 2(O): " + otherwin + ".\n");
                                        logs.AppendText("Games Drawn: " + draws + ".\n");
                                        logs.AppendText("Rounds Played: " + rounds + ".\n");
                                    }
                                    else
                                    {
                                        // starting player won
                                        broadCast("X" + incomingMessage);
                                        startingwin++;
                                        gameEnd(1, startingPlayer);
                                        logs.AppendText("Player 1(X) won.\n");
                                        logs.AppendText("Games won by Player 1(X): " + startingwin + ".\n");
                                        logs.AppendText("Games won by Player 2(O): " + otherwin + ".\n");
                                        logs.AppendText("Games Drawn: " + draws + ".\n");
                                        logs.AppendText("Rounds Played: " + rounds + ".\n");
                                    }
                                }
                                else if (thisClient.username == otherPlayer)
                                {
                                    arr[input] = "O";
                                    // check win
                                    status = CheckWin();
                                    playerTurn = startingPlayer;

                                    if (status == 0)
                                    {
                                        broadCast("O" + incomingMessage);
                                        logs.AppendText("O played " + incomingMessage + "\n");
                                        Thread.Sleep(50);
                                        broadCast("X's turn");
                                        logs.AppendText("X's turn.\n");
                                    }
                                    else if (status == -1)
                                    {
                                        // draw
                                        broadCast("O" + incomingMessage);
                                        draws++;
                                        gameEnd(-1, "");
                                        logs.AppendText("Game was a draw.\n");
                                        logs.AppendText("Games won by Player 1(X): " + startingwin + ".\n");
                                        logs.AppendText("Games won by Player 2(O): " + otherwin + ".\n");
                                        logs.AppendText("Games Drawn: " + draws + ".\n");
                                        logs.AppendText("Rounds Played: " + rounds + ".\n");

                                    }
                                    else if (status == 1)
                                    {
                                        // other player won
                                        broadCast("O" + incomingMessage);
                                        otherwin++;
                                        gameEnd(1, otherPlayer);
                                        logs.AppendText("Player 2(O) won.\n");
                                        logs.AppendText("Games won by Player 1(X): " + startingwin + ".\n");
                                        logs.AppendText("Games won by Player 2(O): " + otherwin + ".\n");
                                        logs.AppendText("Games Drawn: " + draws + ".\n");
                                        logs.AppendText("Rounds Played: " + rounds + ".\n");
                                    }
                                }

                            }
                            else
                            {
                                byte[] errorMessage = Encoding.Default.GetBytes("0004");
                                thisClient.serverSocket.Send(errorMessage);
                            }
                        }
                        else
                        {
                            byte[] errorMessage = Encoding.Default.GetBytes("0003");
                            thisClient.serverSocket.Send(errorMessage);
                        }

                    }
                    else
                    {
                        byte[] errorMessage = Encoding.Default.GetBytes("0002");
                        thisClient.serverSocket.Send(errorMessage);
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText(thisClient.username + " has disconnected\n");

                    }

                    if (waitingusers.Count != 0)
                    {
                        if (thisClient.username == clientSockets[0].username && connectedClients > 2)
                        {
                            if (thisClient.username == otherPlayer)
                            {
                                if (thisClient.username == playerTurn)
                                {
                                    clientSockets[0] = waitingusers[0];
                                    otherPlayer = waitingusers[0].username;
                                    playerTurn = otherPlayer;
                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 2 place with symbol 'O'");
                                    clientSockets[0].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is your turn");
                                    clientSockets[0].serverSocket.Send(Message0);

                                    logs.AppendText(otherPlayer + " has taken place of " + thisClient.username + " as Player 2\n");
                                }
                                else
                                {
                                    clientSockets[0] = waitingusers[0];
                                    otherPlayer = waitingusers[0].username;

                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 2 place with symbol 'O'");
                                    clientSockets[0].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is other player's turn");
                                    clientSockets[0].serverSocket.Send(Message0);

                                    logs.AppendText(otherPlayer + " has taken place of " + thisClient.username + " as Player 2\n");
                                }




                            }

                            else if (thisClient.username == startingPlayer)
                            {
                                if (thisClient.username == playerTurn)
                                {
                                    clientSockets[0] = waitingusers[0];
                                    startingPlayer = waitingusers[0].username;
                                    playerTurn = startingPlayer;
                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 1 place with symbol 'X'");
                                    clientSockets[0].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is your turn");
                                    clientSockets[0].serverSocket.Send(Message0);

                                    logs.AppendText(startingPlayer + " has taken place of " + thisClient.username + " as Player 1\n");
                                }
                                else
                                {
                                    clientSockets[0] = waitingusers[0];
                                    startingPlayer = waitingusers[0].username;

                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 1 place with symbol 'X'");
                                    clientSockets[0].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is other player's turn");
                                    clientSockets[0].serverSocket.Send(Message0);

                                    logs.AppendText(startingPlayer + " has taken place of " + thisClient.username + " as Player 1\n");
                                }



                            }
                        }
                        else if (thisClient.username == clientSockets[1].username && connectedClients > 2)
                        {
                            if (thisClient.username == otherPlayer)
                            {
                                if (thisClient.username == playerTurn)
                                {
                                    clientSockets[1] = waitingusers[0];
                                    otherPlayer = waitingusers[0].username;
                                    playerTurn = otherPlayer;
                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 2 place with symbol 'O'");
                                    clientSockets[1].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is your turn");
                                    clientSockets[1].serverSocket.Send(Message0);

                                    logs.AppendText(otherPlayer + " has taken place of " + thisClient.username + " as Player 2\n");
                                }
                                else
                                {
                                    clientSockets[1] = waitingusers[0];
                                    otherPlayer = waitingusers[0].username;
                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 2 place with symbol 'O'");
                                    clientSockets[1].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is other player's turn");
                                    clientSockets[1].serverSocket.Send(Message0);

                                    logs.AppendText(otherPlayer + " has taken place of " + thisClient.username + " as Player 2\n");
                                }



                            }

                            else if (thisClient.username == startingPlayer)
                            {
                                if (thisClient.username == playerTurn)
                                {
                                    clientSockets[1] = waitingusers[0];
                                    startingPlayer = waitingusers[0].username;
                                    playerTurn = startingPlayer;
                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 1 place with symbol 'X'");
                                    clientSockets[1].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is your turn");
                                    clientSockets[1].serverSocket.Send(Message0);

                                    logs.AppendText(startingPlayer + " has taken place of " + thisClient.username + " as Player 1\n");
                                }
                                else
                                {
                                    clientSockets[1] = waitingusers[0];
                                    startingPlayer = waitingusers[0].username;

                                    waitingusers.Remove(waitingusers[0]);
                                    byte[] Message = Encoding.Default.GetBytes("`You have taken player 1 place with symbol 'X'");
                                    clientSockets[1].serverSocket.Send(Message);
                                    Thread.Sleep(50);
                                    byte[] Message0 = Encoding.Default.GetBytes("It is other player's turn");
                                    clientSockets[1].serverSocket.Send(Message0);

                                    logs.AppendText(startingPlayer + " has taken place of " + thisClient.username + " as Player 1\n");
                                }


                            }
                        }
                    }
                    thisClient.serverSocket.Close();
                    clientSockets.Remove(thisClient);
                    //connectedClients--;
                    //connected = false;


                    connectedClients--;
                    connected = false;
                    if (gameStarted == true && connectedClients < 2)
                    {
                        broadCast("The other player disconnected. You win! ");
                        Thread.Sleep(50);
                        

                        gameStarted = false;
                        if (thisClient.username == startingPlayer)
                        {
                            otherwin++;
                            rounds++;
                            logs.AppendText(otherPlayer + " has won\n");

                        }
                        else if (thisClient.username == otherPlayer)
                        {
                            startingwin++;
                            rounds++;
                            logs.AppendText(startingPlayer + " has won\n");

                        }
                        for (int i = 0; i < 10; i++)
                        {
                            arr[i] = i.ToString();
                        }
                        //listening = false;
                        //terminating = true;

                        //removeClients();
                        //button_listen.Enabled = true;
                        broadCast("A" + startingwin.ToString());
                        Thread.Sleep(100);
                        broadCast("B" + otherwin.ToString());
                        Thread.Sleep(100);
                        broadCast("@" + draws.ToString());
                        Thread.Sleep(100);
                        broadCast("R" + rounds.ToString());
                        
                            

                        
                    }
                    
                    

                }
            }
        }
        private void Receiveforwait(User thisClient) // updated
        {
            bool connectedwait = true;
            bool endwait = false;
            int counter = 1;
            while (counter < 10)
            {
                if (arr[counter] != counter.ToString())
                {
                    byte[] Message = Encoding.Default.GetBytes(arr[counter] + counter.ToString());
                    thisClient.serverSocket.Send(Message);

                }
                counter++;
                Thread.Sleep(50);

            }

            byte[] Message1 = Encoding.Default.GetBytes("A" + startingwin.ToString());
            byte[] Message2 = Encoding.Default.GetBytes("B" + otherwin.ToString());
            byte[] Message3 = Encoding.Default.GetBytes("@" + draws.ToString());
            byte[] Message4 = Encoding.Default.GetBytes("R" + rounds.ToString());

            thisClient.serverSocket.Send(Message1);
            Thread.Sleep(100);
            thisClient.serverSocket.Send(Message2);
            Thread.Sleep(100);
            thisClient.serverSocket.Send(Message3);
            Thread.Sleep(100);
            thisClient.serverSocket.Send(Message4);
            Thread.Sleep(100);



            while (connectedwait && !terminating && !endwait)
            {
                try
                {
                    if (thisClient.username == startingPlayer || thisClient.username == otherPlayer)
                    {
                        Thread receiveThread = new Thread(() => Receiveforgame(thisClient)); // updated
                        receiveThread.Start();
                        endwait = true;

                    }

                    if (!endwait)
                    {
                        Byte[] buffer = new Byte[64];
                        thisClient.serverSocket.Receive(buffer);

                        string incomingMessage = Encoding.Default.GetString(buffer);
                        incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                        //logs.AppendText(thisClient.username + ":" + incomingMessage + "\n");
                        
                        if (incomingMessage.Substring(0,1) != "`")
                        {
                            byte[] errorMessage = Encoding.Default.GetBytes("you can only watch the game.");
                            thisClient.serverSocket.Send(errorMessage);
                        }

                    }
                }
                catch
                {
              
                    
                        if (!terminating)
                        {
                            logs.AppendText(thisClient.username + " has disconnected\n");
                        

                    }
                    thisClient.serverSocket.Close();
                    waitingusers.Remove(thisClient);
                    //connectedClients--;
                    //connected = false;
                    connectedClients--;
                        connectedwait = false;


                    



                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void gameEnd(int status, string winner)
        {
            rounds++;

            if (status == 1)
            {
                logs.AppendText("Game over! " + winner + " is the winner\n");
                broadCast("Game over! " + winner + " is the winner");
                Thread.Sleep(50);
                //listening = false;
                //terminating = true;
                //removeClients();
                //button_listen.Enabled = true;
            }
            else if (status == -1)
            {
                logs.AppendText("Game over! It is a draw\n");
                broadCast("Game over! It is a draw\n");
                Thread.Sleep(50);
                //listening = false;
                //terminating = true;
                //removeClients();
                //button_listen.Enabled = true;
            }
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i.ToString();
            }

            broadCast("0006");
            Thread.Sleep(100);
            broadCast("A" + startingwin.ToString());
            Thread.Sleep(100);
            broadCast("B" + otherwin.ToString());
            Thread.Sleep(100);
            broadCast("@" + draws.ToString());
            Thread.Sleep(100);
            broadCast("R" + rounds.ToString());
            Thread.Sleep(100);


            logs.AppendText(startingPlayer + " (X) starts. " + otherPlayer + " is O\n");
            broadCast(startingPlayer + " (X) starts. " + otherPlayer + " is O");
            playerTurn = startingPlayer;
        }

        private void removeClients()
        {
            foreach (User user in clientSockets)
            {
                user.serverSocket.Close();

            }
            clientSockets.Clear();
            connectedClients = 0;

        }

        // private void button_send_Click(object sender, EventArgs e)
        //{
        //    string message = textBox_message.Text;
        //    if(message != "" && message.Length <= 64)
        //    {
        //        Byte[] buffer = Encoding.Default.GetBytes(message);
        //        foreach (User client in clientSockets)
        //        {
        //            try
        //            {
        //                client.serverSocket.Send(buffer);
        //            }
        //            catch
        //            {
        //                logs.AppendText("There is a problem! Check the connection...\n");
        //                terminating = true;
        //                textBox_message.Enabled = false;
        //                button_send.Enabled = false;
        //                textBox_port.Enabled = true;
        //                button_listen.Enabled = true;
        //                serverSocket.Close();
        //            }

        //        }
        //    }
        // }

        private void broadCast(string message)
        {
            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                foreach (User client in clientSockets)
                {
                    try
                    {
                        client.serverSocket.Send(buffer);
                    }
                    catch
                    {
                        logs.AppendText("There is a problem! Check the connection...\n");
                        terminating = true;
                        //textBox_message.Enabled = false;
                        //button_send.Enabled = false;
                        textBox_port.Enabled = true;
                        button_listen.Enabled = true;
                        serverSocket.Close();
                    }
                }
                foreach (User client in waitingusers)
                {
                    try
                    {
                        client.serverSocket.Send(buffer);
                    }
                    catch
                    {
                        logs.AppendText("There is a problem! Check the connection...\n");
                        terminating = true;
                        //textBox_message.Enabled = false;
                        //button_send.Enabled = false;
                        textBox_port.Enabled = true;
                        button_listen.Enabled = true;
                        serverSocket.Close();
                    }

                }
            }
        }
        private void broadCastwaiting(string message)
        {
            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);

                foreach (User client in waitingusers)
                {
                    try
                    {
                        client.serverSocket.Send(buffer);
                    }
                    catch
                    {
                        logs.AppendText("There is a problem! Check the connection...\n");
                        terminating = true;
                        //textBox_message.Enabled = false;
                        //button_send.Enabled = false;
                        textBox_port.Enabled = true;
                        button_listen.Enabled = true;
                        serverSocket.Close();
                    }

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class User
        {
            public string username;
            public Socket serverSocket;

            public User()
            {
                username = "";

            }
        }
    }
}

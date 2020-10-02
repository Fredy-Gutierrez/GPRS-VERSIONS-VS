using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRS.Clases
{
    public class TcpClients
    {
        public string name;
        public string ip;
        public Int32 port;
        public string type;
        public DriverMaster driverMaster;

        TcpClient client;
        NetworkStream stream;

        BackgroundWorker TcpRead;
        BackgroundWorker TcpWrite;

        Byte[] msgToSend;

        Boolean serveractive = false;

        public TcpClients(DriverMaster driverMaster,string name,string ip,string port,string type)
        {
            this.driverMaster = driverMaster;
            this.name = name;
            this.ip = ip;
            this.port = Convert.ToInt32(port);
            this.type = type;

        }
          
        public Boolean beginTcp()
        {
            try
            {
                client = new TcpClient(ip, port);
                stream = client.GetStream();

                Console.WriteLine();
                TcpRead = new BackgroundWorker();
                TcpRead.DoWork += Read;
                TcpRead.RunWorkerAsync();
                TcpRead.WorkerSupportsCancellation = true;

                TcpWrite = new BackgroundWorker()
                {
                    WorkerSupportsCancellation = true
                };
                TcpWrite.DoWork += Write;
                serveractive = true;

                return serveractive;
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                new Error("El servidor " + ip + " no responde,\npuede que no se encuentre activo").ShowDialog();
                serveractive = false;
                return serveractive;
            }
        }
        public void CloseTcp()
        {
            Console.WriteLine("Puerto cerrado");
            if (serveractive)
            {
                TcpRead.CancelAsync();
                client.Close();
                stream.Close();
            }
        }
        Boolean active= true;
        private void Read(object s, DoWorkEventArgs e)
        {
            Byte[] msgReceived = new Byte[256];
            try
            {
                active = true;
                while (active)
                {
                    if(stream.Read(msgReceived, 0, msgReceived.Length) != 0)
                    {
                        sendRecived(msgReceived);
                    //sender.Receive(msgReceived);
                        
                        //send(msgReceived);
                        Console.WriteLine(Encoding.UTF8.GetString(msgReceived));
                    }
                    else
                    {
                        active = false;
                        TcpRead.CancelAsync();
                        Console.WriteLine("El servidor se ha desconectado");
                    }
                    
                }
            }
            catch(Exception se)
            {
                Console.WriteLine(se.Message.ToString());
                TcpRead.CancelAsync();
                //MessageBox.Show("Ocurrió un error, el servidor no responde");
            }

        }
        private void Write(object s, DoWorkEventArgs e)
        {
            stream.Write(msgToSend, 0, msgToSend.Length);
            TcpWrite.CancelAsync();
        }

        public void send(Byte [] msg)
        {
            this.msgToSend = msg;
            TcpWrite.RunWorkerAsync();
        }

        public string getName()
        {
            return name;
        }

        public void sendRecived(Byte[] msg)
        {
            if (type.Equals("Servers"))
            {
                driverMaster.reciveToSendServer(msg, name, "TcpClient");
            }
            else if (type.Equals("Modems"))
            {
                driverMaster.reciveToSendModem(msg, name, "TcpClient");
            }
        }

    }
}

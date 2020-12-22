using GPRS.Clases.Models;
using GPRS.Clases.Xml.SocketsMessages;
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
        public int port;
        public string type;
        public DriverMaster driverMaster;
        readonly TcpClientMessagesModel tcpClientMessagesModel = new TcpClientMessagesModel();

        TcpClient client;
        NetworkStream stream;

        BackgroundWorker TcpRead;
        BackgroundWorker TcpWrite;

        byte[] msgToSend;

        bool serveractive = false;

        readonly Configurations c;

        public TcpClients(DriverMaster driverMaster,string name,string ip,string port,string type, Configurations c)
        {
            this.driverMaster = driverMaster;
            this.name = name;
            this.ip = ip;
            this.port = Convert.ToInt32(port);
            this.type = type;
            this.c = c;
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
                Alerts.ShowError("El servidor " + ip + " no responde,\npuede que no se encuentre activo");
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
                c._UpdateTcpClient(name, ip, Convert.ToString(port), type, "Inactivo");
                client.Close();
                stream.Close();

            }
        }
        Boolean active= true;
        bool newMessage = true;
        private void Read(object s, DoWorkEventArgs e)
        {
            Byte[] msgReceived = new Byte[256];
            try
            {
                active = true;
                while (active)
                {
                    int byteread;
                    if((byteread = stream.Read( msgReceived, 0, msgReceived.Length)) != 0)
                    {

                        Byte[] newbyte = new Byte[byteread];

                        Buffer.BlockCopy(msgReceived, 0, newbyte, 0, byteread);
                        
                        string receivedText = Encoding.UTF8.GetString(msgReceived, 0, byteread);
                        
                        Console.WriteLine(Encoding.UTF8.GetString(msgReceived,0,byteread));

                        string hour = DateTime.Now.ToString("hh:mm:ss");

                        DateTime fechaHoy = DateTime.Now;

                        string date = fechaHoy.ToString("d");
                        
                        try {

                            Task.Run(() =>
                            {
                                sendRecived(newbyte, "[" + date + "   " + hour + "]");
                                
                                tcpClientMessagesModel.InsertMessage(this.name, receivedText, this.ip, date, hour, this.type);

                                if (newMessage)
                                {
                                    c._UpdateTcpClient(this.name, this.ip, Convert.ToString(this.port), this.type, "En comunicación");
                                    newMessage = false;
                                }
                            });
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Xml Exception: " + ex.Message.ToString());
                        }
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
                active = false;
                TcpRead.CancelAsync();
                //MessageBox.Show("Ocurrió un error, el servidor no responde");
            }

        }
        private void Write(object s, DoWorkEventArgs e)
        {
            stream.Write(msgToSend, 0, msgToSend.Length);
            TcpWrite.CancelAsync();
        }

        private void WriteRun(byte[] msg)
        {
            try
            {
               stream.Write(msg, 0, msg.Length);
               //Console.WriteLine("Sended by TCP" + BitConverter.ToString(text));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error" + ex.Message.ToString());
            }
        }

        public void send(Byte [] msg)
        {
            this.msgToSend = msg;
            /*try
            {
                TcpWrite.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }*/
            Task.Run(() =>
            {
                WriteRun(msg);
            });
        }

        public string getName()
        {
            return name;
        }

        public void sendRecived(Byte[] msg,string fecha)
        {
            if (type.Equals("Servers"))
            {
                driverMaster.reciveToSendServer(msg, name, "TcpClient",fecha);
            }
            else if (type.Equals("Modems"))
            {
                driverMaster.reciveToSendModem(msg, name, "TcpClient", fecha);
            }
        }

    }
}

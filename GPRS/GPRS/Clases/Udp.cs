using GPRS.Clases.Models;
using GPRS.Clases.Xml.SocketsMessages;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRS.Clases
{
    public class Udp
    {
        public DriverMaster driverMaster;
        public String name;
        public int enlaceport;
        public int destinationport;
        public string type;
        UdpClient Server;

        Configurations c;
        UdpServerMessagesModel udpServerMessagesModel = new UdpServerMessagesModel();


        public Udp(DriverMaster driverMaster, string name, string enlaceport, string destinationport,string type, Configurations c)
        {
            this.driverMaster = driverMaster;
            this.name = name;
            this.enlaceport = int.Parse(enlaceport);
            this.destinationport = int.Parse(destinationport);
            this.type = type;
            this.c = c;
        }

        public void beginServer()
        {
            
            try
            {
                Server = new UdpClient(enlaceport);
                Server.BeginReceive(new AsyncCallback(recibir), null);
                Console.WriteLine("Socket "+enlaceport+ " creado");
            }
            catch (SocketException se)
            {
                Alerts.ShowError("Imposible crear el socket,\n puede que el puerto no este liberado");
                Console.WriteLine(se.Message.ToString());
            }
        }

        IPEndPoint RemoteIPSE;
        public String DireccionDestinoSE = "";
        void recibir(IAsyncResult result)
        {
            try
            {
                RemoteIPSE = new IPEndPoint(IPAddress.Any, enlaceport);
                byte[] recibido = Server.EndReceive(result, ref RemoteIPSE);

                String data = BitConverter.ToString(recibido).Replace("-", " ");

                Console.WriteLine("Msg"+ RemoteIPSE.Address.ToString() + ": "+destinationport+": " + data);

                

                //*Dirección de destino del mensaje recibido*//
                DireccionDestinoSE = RemoteIPSE.Address.ToString();

                string hour = DateTime.Now.ToString("hh:mm:ss");

                DateTime fechaHoy = DateTime.Now;

                string date = fechaHoy.ToString("d");

                try
                {
                    Task.Run(() =>
                    {
                        sendRecived(recibido, "[" + date + "   " + hour + "]");

                        udpServerMessagesModel.InsertMessage(name, data, DireccionDestinoSE, date, hour, type);

                        if (!x)
                        {
                            c._UpdateUdpServer(name, Convert.ToString(enlaceport), Convert.ToString(destinationport), type, "En comunicación");
                        }
                    });
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Xml error: " + ex.Message.ToString());
                }

                x = true;

                //sendSe(recibido);
                //send(Encoding.UTF8.GetBytes(data));

                Server.BeginReceive(new AsyncCallback(recibir), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de recepcion");
                //this.CancelSyncronization();
                Console.WriteLine(ex.Message);
            }
        }
        Boolean x = false;
        public void send(byte[] msg)
        {
            if (x)
            {
                if (!DireccionDestinoSE.Equals(""))
                {
                    if (enlaceport.Equals(destinationport))
                    {
                        Server.Send(msg, msg.Length, RemoteIPSE);
                    }
                    else
                    {
                        UdpClient udpClient = new UdpClient();
                        udpClient.Connect(DireccionDestinoSE, destinationport);

                        udpClient.Send(msg, msg.Length);
                        Console.WriteLine("Enviado");

                        udpClient.Close();
                    }
                }
            }
            
            //
        }

        public Boolean getDireccion()
        {
            if (DireccionDestinoSE != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CloseUdp()
        {
            Server.Close();
         
            c._UpdateUdpServer(name, Convert.ToString(enlaceport), Convert.ToString(destinationport), type, "Inactivo");
            Console.WriteLine("Socket cerrado");
        }

        public void sendRecived(byte[] msg,string fecha)
        {
            if (type.Equals("Servers"))
            {
                driverMaster.reciveToSendServer(msg, name,"UdpServer",fecha);
            }
            else if (type.Equals("Modems"))
            {
                driverMaster.reciveToSendModem(msg, name, "UdpServer", fecha);
            }
        }

        public string getName()
        {
            return name;
        }
    }
}

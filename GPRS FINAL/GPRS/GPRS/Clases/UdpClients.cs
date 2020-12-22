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
    public class UdpClients
    {

        public DriverMaster driverMaster;
        private UdpClient client;
        private readonly string name = "";
        private readonly string ip = "";
        private readonly string type;
        private readonly int enlaceport;
        private readonly int destinationport;
        private readonly Configurations c;
        readonly UdpClientMessagesModel udpClientMessagesModel = new UdpClientMessagesModel();


        public UdpClients(DriverMaster driverMaster,string name, string ip, string enlaceport,string destinationport,string type, Configurations c)
        {
            this.driverMaster = driverMaster;
            this.name = name;
            this.ip = ip;
            this.enlaceport = Convert.ToInt32(enlaceport);
            this.destinationport = Convert.ToInt32(destinationport);
            this.type = type;
            this.c = c;
        }

        public void beginClient()
        {
            try
            {
                client = new UdpClient(enlaceport);

                client.BeginReceive(new AsyncCallback(DataReceived), null);

                Console.WriteLine("Iniciado"+ip+" "+enlaceport+" "+destinationport);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Alerts.ShowError("Se produjo un error en la creacion del socket,\n parece que otra aplicacion esta haciendo uso de el");
            }
            
        }

        bool newMsg = true;
        IPEndPoint receivedIpEndPoint;
        public void DataReceived(IAsyncResult ar)
        {
            try
            {
                receivedIpEndPoint = new IPEndPoint(IPAddress.Any, enlaceport);

                Byte[] receivedBytes = client.EndReceive(ar, ref receivedIpEndPoint);

                string receivedText = BitConverter.ToString(receivedBytes).Replace("-"," ");

                Task.Run(() =>
                {

                    String data = "RESPUESTA A: " + receivedText;

                    Console.Write(receivedIpEndPoint + ": " + receivedText + Environment.NewLine);


                    string hour = DateTime.Now.ToString("hh:mm:ss");

                    DateTime fechaHoy = DateTime.Now;

                    string date = fechaHoy.ToString("d");

                    sendRecived(receivedBytes, "[" + date + "   " + hour + "]");

                    udpClientMessagesModel.InsertMessage(this.name, receivedText, ip, date, hour, this.type);

                    try
                    {
                        if (newMsg)
                        {
                            c._UpdateUdpClient(name, ip, Convert.ToString(enlaceport), Convert.ToString(destinationport), type, "En comunicación");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Xml Exception: " + ex.Message.ToString());
                    }
                });
                
                newMsg = false;

                client.BeginReceive(new AsyncCallback(DataReceived), null);
            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message.ToString());
            }
        }

        public void sendRecived(Byte [] msg, string fecha)
        {
            if (type.Equals("Servers"))
            {
                driverMaster.reciveToSendServer(msg, name, "UdpClient",fecha);
            }
            else if (type.Equals("Modems"))
            {
                driverMaster.reciveToSendModem(msg, name, "UdpClient", fecha);
            }
        }

        public void send(Byte[] ms)
        {
            UdpClient udpClientSend = new UdpClient(ip, destinationport);

            udpClientSend.Send(ms, ms.Length);

            udpClientSend.Close();
        }

        public void CloseUdp()
        {
            client.Close();

            c._UpdateUdpClient(name, ip, Convert.ToString(enlaceport), Convert.ToString(destinationport), type, "Inactivo");
            Console.WriteLine("Socket cerrado");
        }
        
        public string getName()
        {
            return name;
        }
    }
}

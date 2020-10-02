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
        UdpClient client;
        string name = "";
        string ip = "";
        string type;
        Int32 enlaceport;
        Int32 destinationport;

        public UdpClients(DriverMaster driverMaster,string name, string ip, string enlaceport,string destinationport,string type)
        {
            this.driverMaster = driverMaster;
            this.name = name;
            this.ip = ip;
            this.enlaceport = Convert.ToInt32(enlaceport);
            this.destinationport = Convert.ToInt32(destinationport);
            this.type = type;
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
                new Error("Se produjo un error en la creacion del socket,\n parece que otra aplicacion esta haciendo uso de el").ShowDialog();
            }
            
        }
        IPEndPoint receivedIpEndPoint;
        public void DataReceived(IAsyncResult ar)
        {
            try
            {
                receivedIpEndPoint = new IPEndPoint(IPAddress.Any, enlaceport);
                Byte[] receivedBytes = client.EndReceive(ar, ref receivedIpEndPoint);

                sendRecived(receivedBytes);

                // Convert data to ASCII and print in console
                string receivedText = ASCIIEncoding.ASCII.GetString(receivedBytes);
                Console.Write(receivedIpEndPoint + ": " + receivedText + Environment.NewLine);
                
                String data = "RESPUESTA A: " + receivedText;
                //send(receivedBytes);
                //send(Encoding.UTF8.GetBytes(data));
                // Restart listening for udp data packages


                client.BeginReceive(new AsyncCallback(DataReceived), null);
            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message.ToString());
            }
        }

        public void sendRecived(Byte [] msg)
        {
            if (type.Equals("Servers"))
            {
                driverMaster.reciveToSendServer(msg, name, "UdpClient");
            }
            else if (type.Equals("Modems"))
            {
                driverMaster.reciveToSendModem(msg, name, "UdpClient");
            }
        }

        public void send(Byte[] ms)
        {
            UdpClient udpClientSend = new UdpClient(ip, destinationport);
            udpClientSend.Send(ms, ms.Length);
            udpClientSend.Close();
            /*client.Send(ms,ms.Length,receivedIpEndPoint);*/
        }

        public void CloseUdp()
        {
            client.Close();
        }
        
        public string getName()
        {
            return name;
        }
    }
}

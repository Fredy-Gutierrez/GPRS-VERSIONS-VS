using GPRS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRS.Clases
{
    public class UDPServidor 
    {
        UdpClient ServerSE;
        UdpClient ServerHUE;

        UdpClient ClienteSE = new UdpClient();

        String idModemSE = "56174";
        String idModemHue = "56175";

        public FormServidor tcpHUEDirection = null;
        public FormServidor tcpSEDirection;

        public List<TCPProcess> listClients;

        /*************************************ALMACENADORES DE MENSAJES**************************************/
        string data = "";
        string dataHUE = "";

        string dataTCPSE = "";
        string dataTCPHUE = "";

        /*******************************************PUERTOS SE**********************************************/
        Int32 puertoSE = 7180;
        Int32 puertoDestinoSE = 7171;

        /*******************************************PUERTOS HUEHUETOCA**********************************************/
        Int32 puertoHUE = 7181;
        Int32 puertoDestinoHUE = 7183;

        public FormServidor formServidor;

        public UDPServidor(FormServidor formServidor,List<Forms.TCPProcess> list)
        {
            this.listClients = list;
            this.formServidor = formServidor;
        }

        public void iniciar()
        {
            /*tcpServerSE = new TCPServidor();
            tcpServerSE.iniciar();*/

            /*****************************************SERVIDOR SE*************************************/
            ServerSE = new UdpClient(puertoSE);
            try
            {
                ServerSE.BeginReceive(new AsyncCallback(recibir), null);
            }
            catch (Exception ex)
            {
                /*****************************************ENVIO DE MENSAJES A LA VISTA*************************************/
                formServidor.Mensajes(ex.Message.ToString());
            }

            /******************************SERVIDOR HUEHUETOCA********************************/
            ServerHUE = new UdpClient(puertoHUE);

            try
            {
                ServerHUE.BeginReceive(new AsyncCallback(recibirHUE), null);
            }
            catch (Exception ex)
            {
                /*****************************************ENVIO DE MENSAJES A LA VISTA*************************************/
                formServidor.Mensajes(ex.Message.ToString() + " DEL SERVIDOR DE HUEHUETOCA");
            }
        }

        #region recepcion SE
        bool pausaSE;

        public String DireccionDestinoSE; 
        void recibir(IAsyncResult result)
        {
            try
            {
                IPEndPoint RemoteIPSE = new IPEndPoint(IPAddress.Any, puertoSE);
                byte[] recibido = ServerSE.EndReceive(result, ref RemoteIPSE);

                data = BitConverter.ToString(recibido);

                Console.WriteLine("hex:"+data);

                DireccionDestinoSE = RemoteIPSE.Address.ToString();


                if (tcpSEDirection == null)
                {
                    int x = 0;
                    while (x<listClients.Count)
                    {
                        if (listClients[x].getId() == idModemSE)
                        {
                            tcpSEDirection = listClients[x].GetFormServidor();
                        }
                        x++;
                    }
                }

                
                formServidor.Invoke(new MethodInvoker(delegate
                {
                    //txtMensajes.Text += "Mensaje: " + data + " Enviado desde: " + RemoteIP.Address.ToString() + "\n";
                    /*****************************************ENVIO DE MENSAJES A LA VISTA*************************************/
                    formServidor.Mensajes("Mensaje: " + data + " Enviado desde: " + RemoteIPSE.Address.ToString() + "\n");

                    #region tcp
                    /***************************ENVIO DEL MENSAJE AL CONECTOR TCP*****************************/
                    tcpSEDirection.Send(recibido);

                    #endregion

                }));
                ServerSE.BeginReceive(new AsyncCallback(recibir), null);
            }
            catch (Exception ex)
            {
                this.CancelSyncronization();
                Console.WriteLine(ex.Message);
            }
        }
        
        public void sendSe(byte[] msg)
        {
            UdpClient udpClientSE = new UdpClient(19000);
            udpClientSE.Connect(DireccionDestinoSE, puertoDestinoSE);
            
            udpClientSE.Send(msg,msg.Length);
            Console.WriteLine("Enviado");

            udpClientSE.Close();
        }


        #endregion

        #region recepcion huehuetoca
        /*********************************RECEPCIÓN DE MENSAJES ENTRANTES DE HUEHUETOCA*****************************************/
        bool pausaHUE;
        void recibirHUE(IAsyncResult result)
        {
            try
            {
                IPEndPoint RemoteIP = new IPEndPoint(IPAddress.Any, puertoDestinoHUE);
                byte[] recibido = ServerHUE.EndReceive(result, ref RemoteIP);
                dataHUE = Encoding.UTF8.GetString(recibido);

                if (tcpHUEDirection == null)
                {
                    int x = 0;
                    while (x < listClients.Count)
                    {
                        if (listClients[x].getId() == idModemHue)
                        {
                            tcpHUEDirection = listClients[x].GetFormServidor();
                        }
                        x++;
                    }
                }


                #region tcp HUE
                /***************************ENVIO DEL MENSAJE AL CONECTOR TCP*****************************/
                tcpHUEDirection.Send(recibido);

                #endregion

                ServerHUE.BeginReceive(new AsyncCallback(recibirHUE), null);
            }
            catch (Exception ex)
            {
                this.CancelSyncronization();
                Console.WriteLine(ex.Message);
            }
        }
        public void sendHue(byte[] msg)
        {
            UdpClient udpClientSE = new UdpClient(19000);
            udpClientSE.Connect(DireccionDestinoSE, puertoDestinoSE);

            udpClientSE.Send(msg, msg.Length);
            Console.WriteLine("Enviado");

            udpClientSE.Close();
        }
        #endregion

        public void reaunudar(String idModem)
        {
            if (idModem == idModemSE)
            {
                pausaSE = false;
            }else if (idModem == idModemHue)
            {
                pausaHUE = false;
            }
        }

        public void CancelSyncronization()
        {
            ServerSE.Close();
            ServerHUE.Close();
        }
    }
    
}
using GPRS.Clases.Models;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRS.Clases
{
    public class Tcp
    {
        public DriverMaster driverMaster;   /// <summary>
        /// Almacenador de la direccion de memoría del driver master, el cual es encargado del envío de datos a traves del los puertos de comunicacion
        /// </summary>
        
        public List<TCPClientData> listClient = new List<TCPClientData>();/// <summary>
        /// Almacena todas la direcciones de los clientes que se conectan al puerto tcp para tener el registro de estos
        /// </summary>
        
        public TcpListener listener;
        public string name;
        public int port;//puerto de comunicaciones del tcp

        public string type;

        
        public string recieve;//recepciona el mensaje recibido en tipo cadena (opcional, solo utilizable para pruebas)
        private TcpClient client;/// <summary>
        /// Almacena la coneccion del cliente actual, sin embargo como es un servidor tcp multicliente este estará cambiando cada que un 
        /// nuevo cliente se conecte
        /// </summary>

        
        public string id;/// <summary>
        /// id de respaldo del modem conectado, con este podremos saber a quien debemos darle su id cuando el modem comience la comunicacion y envíe el primer mensje
        /// </summary>

        public byte[] text;/// <summary>
                           /// encargado de almacenar el mensaje a enviar, una vez iniciado el proceso en segundo plano para escribir, el mensaje 
                           /// se enviara a traves del write
                           /// Nota: Todos los mensajes serán enviados y recibidos en tipo Byte para evitar problemas de decodificación
                           /// </summary>
                           /// 
        private readonly XmlConnection xmlConnection;

        public Configurations c;


        public Tcp(DriverMaster driverMaster, string name, string port, string type, Configurations c)
        {
            this.name = name;
            this.port = int.Parse(port);
            this.type = type;
            this.driverMaster = driverMaster;
            this.xmlConnection = new XmlConnection();
            xmlConnection._CreateXml();
            this.c = c;
        }

        public void CloseTcp()
        {
            /*if (listClient.Count < 1)
            {
                c._UpdateTcpServer(name, Convert.ToString(port), type, "Inactivo");
            }*/

            for (int x =0; x < listClient.Count; x++)
            {
                listClient[x].CloseClient();
            }
            if (client != null)
            {
                client.Close();
            }
            listener.Stop();
            
            c._UpdateTcpServer(name, Convert.ToString(port), type, "Inactivo");

        }

        public string getName()
        {
            return name;
        }

        public void sendToClient(Byte [] msg, string id)
        {
            for (int x = 0; x < listClient.Count; x++)
            {
                if (listClient[x].getId().Equals(id))
                {
                    listClient[x].Send(msg);
                }
            }
        }

        public void sendRecived(Byte [] msg, string id,string fecha)
        {
            if (type.Equals("Servers"))
            {
                Console.WriteLine("Recibido para envio"+id);
                
                driverMaster.reciveToSendTcpServer(msg, name, "TcpServer", id,fecha);
                
            }
            else if (type.Equals("Modems"))
            {
                Console.WriteLine("Recibido para envio " + id);
                
                
                driverMaster.reciveToSendTcpModem(msg, name, "TcpServer", id, fecha);
                
                
                //driverMaster.reciveToSendModem(msg, name, "UdpClient");
            }
        }

        public void cargarTcpServer()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                Task.Run(() =>
                {
                    iniciartcp();
                });
            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message.ToString());
                Alerts.ShowError("Ha ocurrido un error al crear el socket TCP,\ncompruebe que el puerto: " + port + " no este en uso");
            }
        }
        Boolean active = true;
        public int count = 1;
        public void iniciartcp()
        {
            try
            {
                int maxConect = 5;
                
                while (active)
                {
                    if (count < maxConect)
                    {
                        client = listener.AcceptTcpClient();
                        Console.WriteLine("Conectado");
                        c._UpdateTcpServer(this.name, Convert.ToString(this.port), this.type, "Conectado");
                        /*********************************ENVIO A TCPPROCESS***************************************/
                        TCPClientData tcpClienData = new TCPClientData(this, client, Convert.ToString(count), listClient);
                        listClient.Add(tcpClienData);
                        tcpClienData.iniciarTcp();

                        /// <summary>
                        /// Area de almacenamiento de conexiones
                        /// </summary>
                        string ipconexion = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                        string hour = DateTime.Now.ToString("hh:mm:ss");
                        xmlConnection._Add(ipconexion,hour);
                        count++;
                    }
                    else
                    {
                        Alerts.ShowInformation("Maximo de conecciones alcanzadas\n¡No se aceptaran más conecciones!");
                        active = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }


    /*****************************************************Clase diccionarion*********************************************************/
    public class TCPClientData
    {
        public NetworkStream stream;//usado para recepcion de mensajes y escritura al cliente
        public StreamReader sr;
        public  Tcp tcpDireccion;
        public string idr; /// <summary>
                           /// este id de respaldo servira para que aquel modem que se conecte tenga asignado un identificador desde el comienzo, este ya no será necesario cuando el modem
                           /// inicie la comunicación y envíe su id en el primer mensaje.
                           /// </summary>

        private string idp = string.Empty;/// <summary>
                                /// Id principal, este id es el enviado por el modem, para identificarse de los demas, además este id sirve para 
                                /// el ruteo de envios y recepciones de mensajes
                                /// </summary> 

        public List<TCPClientData> listClient = new List<TCPClientData>();

        public string recieve;//recepciona el mensaje recibido en tipo cadena (opcional, solo utilizable para pruebas)

        BackgroundWorker TcpRead;/// <summary>
                                 /// Para evitar que la vista se vea afectada por los metodos que estan siempre ejecutandose, se deben poner estos como segundo plano
                                 /// y así podremos continuar con el uso de la aplicacón normalmente mientras los metodo listen and write se ejecutan
                                 /// Nota: esta es la tarea en segundo plano que ejecuta el metodo listen para la recepcion de los mensajes tcp
                                 /// </summary>
        
        BackgroundWorker TcpWrite;/// <summary>
                                  /// Para evitar que la aplicacion se vea afectada al momento de la escritura de mensajes se crea una tarea en segundo
                                  /// plano para el metodo write, sin embargo esta solo se ejecutara cuando exista mensajes para enviar y terminara una
                                  /// vez que el mensaje se haya enviado
                                  /// </summary>

        public byte[] text;/// <summary>
                           /// encargado de almacenar el mensaje a enviar, una vez iniciado el proceso en segundo plano para escribir, el mensaje 
                           /// se enviara a traves del write
                           /// Nota: Todos los mensajes serán enviados y recibidos en tipo Byte para evitar problemas de decodificación
                           /// </summary>



        readonly TcpClient client;
        readonly Configurations c;
        readonly TcpServerMessagesModel tcpServerMessagesModel = new TcpServerMessagesModel();

        public TCPClientData(Tcp tcpDireccion, TcpClient client, string id, List<TCPClientData> listClient)
        {
            this.client = client;
            this.tcpDireccion = tcpDireccion;
            idr = id;
            stream = this.client.GetStream();
            this.listClient = listClient;
            sr = new StreamReader(client.GetStream());
            c = tcpDireccion.c;
            stream.ReadTimeout = 300000;//timeout
        }

        public void setId(string id)
        {
            idp = id;
        }

        public string getId()
        {
            return idp;
        }

        public Tcp getTcpDireccion()
        {
            return tcpDireccion;
        }

        public void iniciarTcp()
        {
            TcpRead = new BackgroundWorker();
            TcpRead.DoWork += Read;
            TcpRead.RunWorkerAsync();

            TcpWrite = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true
            };
            TcpWrite.DoWork += Write;
        }

        private void Write(object sender, DoWorkEventArgs e)
        {
            try
            {

                if (listClient.Count > 0)
                {
                    stream.Write(text, 0, text.Length);
                    Console.WriteLine("Sended by TCP" + BitConverter.ToString(text));
                }
                else
                {
                    MessageBox.Show("Sending failed");
                }
                TcpWrite.CancelAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay clientes conectados "+ex.Message.ToString());
                TcpWrite.CancelAsync();
            }
        }

        private void WriteRun(byte[] msg)
        {
            try
            {

                if (listClient.Count > 0)
                {
                    stream.Write(msg, 0, msg.Length);
                    //Console.WriteLine("Sended by TCP" + BitConverter.ToString(text));
                }
                else
                {
                    MessageBox.Show("Sending failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay clientes conectados " + ex.Message.ToString());
            }
        }

        public void Send(/*String msg*/ byte[] msg)
        {
            /*text = msg; 
            try
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
        public TCPClientData getTcpClientDataDirecction()
        {
            return this;
        }


        Boolean newMsg = true;
        private void Read(object sender, DoWorkEventArgs e)
        {
            Byte[] bytes = new Byte[256];
            try
            {
                int bytesRead;
                while ((bytesRead = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    /*se genera un nuevo arreglo de bytes limpio*/
                    Byte[] newbyte = new Byte[bytesRead];

                    /*for (int x = 0; x < bytesRead; x++)
                    {
                        newbyte[x] = bytes[x];
                    }*/

                    Buffer.BlockCopy(bytes,0, newbyte,0, bytesRead);

                    string msg = BitConverter.ToString(newbyte);

                    if (Encoding.ASCII.GetString(bytes, 0, bytesRead).Length <= 5)
                    {
                        if (newMsg)
                        {
                            idp = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                            for (int x = 0; x < listClient.Count; x++)
                            {
                                if (listClient[x].getId() == idp && listClient[x].getTcpClientDataDirecction() != this)
                                {
                                    listClient[x].CloseClient();
                                    listClient.RemoveAt(x);
                                    x--;
                                }
                            }
                        }
                        //tcpDireccion.sendRecived(newbyte, idp);
                    }

                    Task.Run(() =>
                    {
                        

                        string ipconexion = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                        Console.WriteLine("RECIVED by " + ipconexion + ": " + msg);

                        string hour = DateTime.Now.ToString("hh:mm:ss");

                        DateTime fechaHoy = DateTime.Now;

                        string date = fechaHoy.ToString("d");

                        tcpDireccion.sendRecived(newbyte, idp, "[" + date + "   " + hour + "]");

                        tcpServerMessagesModel.InsertMessage(tcpDireccion.name, msg, ipconexion, date, hour, tcpDireccion.type);

                        try
                        {
                            if (newMsg)
                            {
                                c._UpdateTcpServer(tcpDireccion.name, Convert.ToString(tcpDireccion.port), tcpDireccion.type, "En comunicación");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception: " + ex.Message.ToString());
                        }
                    });
                    newMsg = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de recepcion");
                Console.WriteLine(ex.Message.ToString());
                CloseClient();
            }
            finally
            {
                CloseClient();
            }
        }

        public void CloseClient()
        {
            try
            {
                c._UpdateTcpServer(tcpDireccion.name, Convert.ToString(tcpDireccion.port), tcpDireccion.type, "Inactivo");
                stream.Close();
                client.Close();
                tcpDireccion.count -= 1;
                listClient.Remove(this);
                Console.WriteLine("Socket cerrado");
            }
            catch (SocketException se)
            {
                //MessageBox.Show("No se han podido cerrar las conexiones");
                Console.WriteLine(se.Message.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error "+ex.Message.ToString());
            }
        }
    }
}

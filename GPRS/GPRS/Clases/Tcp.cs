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

        
        public String id;/// <summary>
        /// id de respaldo del modem conectado, con este podremos saber a quien debemos darle su id cuando el modem comience la comunicacion y envíe el primer mensje
        /// </summary>

        public byte[] text;/// <summary>
        /// encargado de almacenar el mensaje a enviar, una vez iniciado el proceso en segundo plano para escribir, el mensaje 
        /// se enviara a traves del write
        /// Nota: Todos los mensajes serán enviados y recibidos en tipo Byte para evitar problemas de decodificación
        /// </summary>

        public Tcp(DriverMaster driverMaster, string name, string port, string type)
        {
            this.name = name;
            this.port = int.Parse(port);
            this.type = type;
            this.driverMaster = driverMaster;
        }

        public void CloseTcp()
        {
            for (int x =0; x < listClient.Count; x++)
            {
                listClient[x].CloseClient();
            }
            if (client != null)
            {
                client.Close();
            }
            listener.Stop();
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

        public void sendRecived(Byte [] msg, string id)
        {
            if (type.Equals("Servers"))
            {
                Console.WriteLine("Recibido para envio"+id); 
                driverMaster.reciveToSendTcpServer(msg,name,"TcpServer",id);
            }
            else if (type.Equals("Modems"))
            {
                Console.WriteLine("Recibido para envio " + id);
                driverMaster.reciveToSendTcpModem(msg, name, "TcpServer", id);
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
                new Error("Ha ocurrido un error al crear el socket TCP,\ncompruebe que el puerto: " + port + " no este en uso").ShowDialog();
            }
        }

        public void iniciartcp()
        {
            try
            {
                int count = 1;
                while (true)
                {
                    client = listener.AcceptTcpClient();
                    Console.WriteLine("Conectado");
                    /*********************************ENVIO A TCPPROCESS***************************************/
                    TCPClientData tcpClienData = new TCPClientData(this, client, Convert.ToString(count), listClient);
                    listClient.Add(tcpClienData);
                    tcpClienData.iniciarTcp();

                    count++;
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
        public String idr; /// <summary>
        /// este id de respaldo servira para que aquel modem que se conecte tenga asignado un identificador desde el comienzo, este ya no será necesario cuando el modem
        /// inicie la comunicación y envíe su id en el primer mensaje.
        /// </summary>
        
        private String idp = "123";/// <summary>
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

        TcpClient client;

        public TCPClientData(Tcp tcpDireccion, TcpClient client, String id, List<TCPClientData> listClient)
        {
            this.client = client;
            this.tcpDireccion = tcpDireccion;
            idr = id;
            stream = this.client.GetStream();
            this.listClient = listClient;
            sr = new StreamReader(client.GetStream());
        }

        public void setId(String id)
        {
            this.idp = id;
        }

        public String getId()
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
                    Console.WriteLine("Sended by TCP");
                }
                else
                {
                    MessageBox.Show("Sending failed");
                }
                TcpWrite.CancelAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No hay clientes conectados");
                TcpWrite.CancelAsync();
            }
        }

        public void Send(/*String msg*/ byte[] msg)
        {
            text = msg;
            TcpWrite.RunWorkerAsync();
        }


        int msgNum = 0;
        private void Read(object sender, DoWorkEventArgs e)
        {
            int i;
            Byte[] bytes = new Byte[256];
            try
            {
                int bytesRead;
                while ((bytesRead = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    /*var expectedChars = decoder.GetCharCount(buffer, 0, bytesRead);
                    if (charBuffer.Length < expectedChars) charBuffer = new char[expectedChars];

                    var charCount = decoder.GetChars(buffer, 0, bytesRead, charBuffer, 0);

                    Console.Write(new string(charBuffer, 0, charCount));*/
                    tcpDireccion.sendRecived(bytes, idp);
                    Console.WriteLine("RECIVED "+Encoding.UTF8.GetString(bytes));
                }
            }
            catch (Exception se)
            {
                Console.WriteLine("Error de recepcion");
                Console.WriteLine(se.Message.ToString());
                //MessageBox.Show("Ciente desconectado");
                /*stream.Close();*/
               /* if (client != null)
                {
                    client.Close();
                }*/
            }
        }

        public void CloseClient()
        {
            try
            {
                stream.Close();
                client.Close();
            }
            catch (SocketException se)
            {
                MessageBox.Show("No se han podido cerrar las conexiones");
                Console.WriteLine(se.Message.ToString());
            }
        }


    }
}

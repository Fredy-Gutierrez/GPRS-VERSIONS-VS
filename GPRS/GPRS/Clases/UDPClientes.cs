using GPRS.Forms;
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
    class UDPClientes
    {
        FormCliente formCliente;
        UdpClient client;
        string data = "";
        Int32 puerto = 0;
        public UDPClientes(FormCliente formCliente)
        {
            this.formCliente = formCliente;
        }

        public void iniciar(String txtIP,String txtPuerto)
        {
            puerto = Convert.ToInt32(txtPuerto);
            client = new UdpClient(txtIP, puerto);

            try
            {
                client.BeginReceive(new AsyncCallback(recibir), null);
            }
            catch (Exception ex)
            {
                formCliente.mensajes(ex.Message.ToString());
            }
        }

        void recibir(IAsyncResult result)
        {

            try
            {
                IPEndPoint RemoteIP = new IPEndPoint(IPAddress.Any, 7171);
                byte[] recibido = client.EndReceive(result, ref RemoteIP);
                data = Encoding.UTF8.GetString(recibido);
                formCliente.Invoke(new MethodInvoker(delegate
                {
                    formCliente.mensajes("\nRecibido: " + data);

                }));
                client.BeginReceive(new AsyncCallback(recibir), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error");
                Console.WriteLine(ex.Message);

            }
        }

        public void enviar(String ms)
        {
            byte[] data = Encoding.ASCII.GetBytes(ms);
            client.Send(data, data.Length);
        }


    }
}

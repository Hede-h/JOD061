using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JOD061
{
    class Program
    {
        const int porta_ = 7000;
        const string ip = "192.168.0.27";
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                UdpClient parceiro = new UdpClient(porta_);

                Console.WriteLine("Sair: CTRL + C");
                while (true)
                {
                    byte[] bytesRecebidos = parceiro.Receive(ref endPoint);
                    Console.WriteLine("Mensagem recebida: {0}", Encoding.ASCII.GetString(bytesRecebidos));
                    Console.WriteLine("Mensagem enviada por {0}:{1}",endPoint.Address.ToString(), endPoint.Port.ToString());
                    
                }
            }
            catch (Exception)
            {
                UdpClient par = new UdpClient();
                par.EnableBroadcast = true;

                Console.WriteLine("Envie sua mensagem. Sair: ENTER");
                Console.WriteLine("- ");
                string msg = Console.ReadLine();

                while (msg.Length > 0)
                {
                    byte[] bytesEnviados = Encoding.ASCII.GetBytes(msg);
                    par.Send(bytesEnviados, bytesEnviados.Length, ip, porta_);

                    Console.Write("- ");
                    msg = Console.ReadLine();

                }
                par.Close();

            }
        }
    }
}
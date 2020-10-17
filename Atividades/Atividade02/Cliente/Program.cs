using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    class Program
    {
        const int porta = 7000;
        const string ip = " 192.168.0.27";

        static void Main(string[] args)
        {
            TcpClient cliente = new TcpClient();
            Console.Write("Conectando ao servidor... ");
            try
            {
                cliente.Connect(ip, porta);
                Console.WriteLine("OK!");
            }
            catch (Exception)
            {
                Console.WriteLine("Falhou!");
                return;
            }

            byte[] bytes = new byte[1024];
            NetworkStream stream = cliente.GetStream();

            Console.WriteLine("Envie uma mensagem. Sair: ENTER.");
            Console.Write("- ");
            string msg = Console.ReadLine();

            while (msg.Length > 0)
            {
                bytes = Encoding.ASCII.GetBytes(msg);
                stream.Write(bytes, 0, bytes.Length);

                Console.Write("- ");
                msg = Console.ReadLine();
            }

            stream.Close();
            Console.WriteLine("Desconectado!");
            cliente.Close();
        }
    }
}

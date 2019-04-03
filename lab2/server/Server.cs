using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net.Http.Headers;
namespace server
{
    class Server
    {
        private int port=8000;//numer portu serwera
        private string path;//ścieżka do katalogu z plikami
        private TcpListener listener;
        public Server(int port, string path) {
            this.port = port;
            this.path = path;
        }
        //uruchomienie serwera
        public void StartServer() {
            try
            {
                listener = new TcpListener(port);
                listener.Start();
                Console.WriteLine("Server start");
                ServerListen();
            }
            catch(SocketException e) {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally {
                listener.Stop();
            }
        }
        //nasłuchiwanie serwera
        private void ServerListen()
        {
            Byte[] bytes = new Byte[256];
            String data = null;
            //do losowania pliku
            int number;
            Random random = new Random();
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connected!");
                number = random.Next(1, 4);
                data = null;
                NetworkStream stream = client.GetStream();
                try
                {
                    
                    //czy klient coś wysłał
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        //tworzenie odpowiedzi
                   
                        string file;
                        
                        //jeżeli jest żądanie GET to odpowiedz
                        if (data.StartsWith("GET"))
                        {
                            string response = null;
                            if (data.Contains(".html"))
                            {
                                string[] dataParams = data.Split(' ');
                                file = dataParams[1].Substring(1).Split(' ')[0];
                                file = path + @"\" + file;
                            }
                            else {
                                file = path + @"\index.html";
                            }
                            if (File.Exists(file))
                            {
                                file = File.ReadAllText(file);
                                response = HeaderOk() + "\n" + file;
                            }
                            else
                            {
                                response = HeaderNotFound();
                            }
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", response);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch
                {
                    string response = HeaderServerError();
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", response);
                }
                finally
                { 
                    client.Close();
                }
            }
        }
        //zatrzymanie serwera
        public void StopServer() {
            listener.Stop();
            Console.WriteLine("Server stop");
        }
        //nagłówek 200
        private string HeaderOk() {
            List<string> values = new List<string>();
            values.Add("HTTP/1.1 200 OK\n");
            values.Add("Date" + DateTime.Now.ToUniversalTime().ToString("r") + "\n");
            values.Add("Access-Control-Allow-Access: *\n");
            values.Add("Content-Type: text/html; charset=utf-8\n");
            values.Add("Server: meinheld / 0.6.1\n");
            values.Add("x-xss-protection: 1; mode=block\n");
            values.Add("Connection: close\n");
            string table = null;
            foreach (string element in values)
            {
                if (table == null) { table = element.ToString(); }
                else table = table + element.ToString();
            }
            return table;
        }
        //nagłówek 404
        private string HeaderNotFound() {
            List<string> values = new List<string>();
            values.Add("HTTP/1.1 404 Not Found\n");
            values.Add("Date" + DateTime.Now.ToUniversalTime().ToString("r") + "\n");
            values.Add("Access-Control-Allow-Access: *\n");
            values.Add("Content-Type: text/html; charset=utf-8\n");
            values.Add("Server: meinheld / 0.6.1\n");
            values.Add("x-xss-protection: 1; mode=block\n");
            values.Add("Connection: close\n");
            values.Add("\n");
            values.Add("404 NOT FOUND");
            string table = null;
            foreach (string element in values)
            {
                if (table == null) { table = element.ToString(); }
                else table = table + element.ToString();
            }
            return table;
        }
        //nagłówek 500
        private string HeaderServerError() {
            List<string> values = new List<string>();
            values.Add("HTTP/1.1 500 Internal Server Error\n");
            values.Add("Date" + DateTime.Now.ToUniversalTime().ToString("r") + "\n");
            values.Add("Access-Control-Allow-Access: *\n");
            values.Add("Content-Type: text/html; charset=utf-8\n");
            values.Add("Server: meinheld / 0.6.1\n");
            values.Add("x-xss-protection: 1; mode=block\n");
            values.Add("Connection: close\n");
            values.Add("\n");
            values.Add("500 INTERNAL SERVER ERROR");
            string table = null;
            foreach (string element in values)
            {
                if (table == null) { table = element.ToString(); }
                else table = table + element.ToString();
            }
            return table;
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Notify
{
    class Server
    {
        Server()
        {


            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            listener.Prefixes.Add("http://localhost:8080/"); // doesn't throw access denied error + unable to access from local network
            //listener.Prefixes.Add("http://172.0.0.1:8080/"); // throws access denied error
            //listener.Prefixes.Add("http://LOCALNETWORKIP:8080/"); // throws access denied error

            listener.Start();

            Console.WriteLine("Listening...");

            while (true)
            {
                // Note: The GetContext method blocks while waiting for a request.
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.

                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // You must close the output stream.
                output.Close();
            }
            listener.Stop();

        }
    }
}
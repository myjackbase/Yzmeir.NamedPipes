using System;
using System.Collections.Generic;
using System.Text;
using Yzmeir.InterProcessComm;
using Yzmeir.NamedPipes;

namespace NamedPipesClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "";
            while ((key = Console.ReadLine()) != "exit")
            {
                if (key != "")
                {
                    DateTime dt = DateTime.Now;
                    // This cycle is used only when you want to run numerous name pipes requests 
                    // and measure the performance. In the general case it is not needed.
                    for (int i = 0; i < 1; i++)
                    {
                        IInterProcessConnection clientConnection = null;
                        try
                        {
                            clientConnection = new ClientPipeConnection("MyPipe", ".");
                            clientConnection.Connect();

                            clientConnection.Write(key);
                            Console.WriteLine(clientConnection.Read());
                            clientConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            clientConnection.Dispose();
                            throw (ex);
                        }
                    }
                    Console.WriteLine(DateTime.Now.Subtract(dt).Milliseconds.ToString());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Yzmeir.InterProcessComm;

namespace NamedPipesServer
{
    class Program
    {
        public static IChannelManager PipeManager;

        static void Main(string[] args)
        {
            PipeManager = new PipeManager();
            PipeManager.Initialize();

            Console.ReadKey();
        }

        ~Program()
        {
            if (PipeManager != null)
            {
                PipeManager.Stop();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_MultiThread
{
    public class Work
    {

        public Mutex mut;
        public int numero;

        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                mut.WaitOne();
                Console.ForegroundColor = (ConsoleColor)(numero + 1);
                Console.WriteLine("Run " + numero + " : " + i);
                mut.ReleaseMutex();
            }

        }
    }
}

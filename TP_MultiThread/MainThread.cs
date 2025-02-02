using System.Transactions;
using System.IO;

namespace TP_MultiThread
{
    internal class MainThread
    {
        String fichier;

        static void Main(string[] args)
        {
            Work work;
            Mutex m = new Mutex(true);

            for (int i = 0; i < 10; i++)
            {
                work = new Work();
                work.mut = m;
                work.numero = i;
                Thread t = new Thread(work.Run);
                t.Start();
            }

            m.ReleaseMutex();
            
        }

        public void Ecrire()
        {
            try
            {
                StreamWriter sw = new StreamWriter("\"D:\\Cours\\BTS2_Astier\\CS\\test.txt\"");
                sw.WriteLine("Hello");
                sw.WriteLine("");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void Lire()
        {
            try
            {
                StreamReader sr = new StreamReader("\"D:\\Cours\\BTS2_Astier\\CS\\test.txt\"");
                fichier = sr.ReadLine();
                while (fichier != null)
                {
                    Console.WriteLine(fichier);
                    fichier = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }



    }
}

using System.Security.Cryptography.X509Certificates;

namespace OldStyleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Kör vår konsol genom Main klassen. Hämtar En instans från Class11 där vi har vår konsol (info).
            Class11.info();

        }



        public static void Testing()
        {
            Console.Write("Mata in en sträng: ");
            string inputWrite = Console.ReadLine();
            
            Console.WriteLine("Tou have entered {0}  ",inputWrite);



            Console.Write("Mata in en sträng 2: ");
             int asciiValue = Console.Read();
          
            Console.WriteLine("Asci Value is {0} ", asciiValue);
          



       


            }
        }













    }
    


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static OldStyleApp.Class11;

namespace OldStyleApp
{
    public class Class11
    {



        /// <summary>
        /// Här har vi vår json fil och platsen där vi erhåller den.
        /// </summary>


        private static readonly string FilePath = @"C:\Projects\OldStyleApp\OldStyleApp\content.data";


        /// <summary>
        /// Denna metod används för att spara och konverta filen till en json fil (geno parametern (data) = (personD) = Bibloteket/dictionary. skriver över all data som konvertas till filepath(där allt sparas). Alltså information eller så kallade Dicitionary /bibloteket vi använder oss av för att lagra information från varje user. Denna metod används i slutet av Main metoden *(SaveToJsonFile(FilePath, personD)* Vi skickar in genom första parametern sökvägen och där vi erhåller filen (Filepath), genom den andra parametern så skickar vi alla data från bibloteket personD.. Så varje gång vi avslutar programmet så sparas all information i jsonfilen.
        /// </summary>
        /// 

        public static void SaveToJsonFile<T>(string filePath, T data)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to {FilePath}:{ex.Message} ");
            }

        }
        /// <summary>
        /// Denna metod används för att ladda upp json filen som vi sparat all information sen innan. Vi laddar upp vår *FilePath* via parametern filepath där vi sparat all information sen tidigare. Samt har vi en annan metod i denna metod (ensure file exists). Vi försöker ladda upp en gammal json fil som finns en innan. Men om det ej existerar så använder vi oss av denna metod för att skapa en ny json fil. Som vi sparar all information på. Men om Json filen existerar så använder vi en desirilizer, alltså konvertera tillbaka json filen till en data fil, så vi kan använda den igen i vårt Biblotek/dictionary.
        /// </summary>
        /// 
        static T LoadFromJsonFile<T>(string filePath)
        {
            try
            {
                EnsureFileExists(filePath);
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from {filePath}: {ex.Message}");
                return default(T);
            }
        }


        /// <summary>
        /// Försäkrar om json filen existerar , om den ej gör det så skapar vi en ny  fil för att lagra all information/data /biblotek.
        /// </summary>
        /// 

        static void EnsureFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }
        }


        public class person
        {

            /// <summary>
            ///Egenskaperna/Värde som används för varje kontakt. Som används tillsammans med Dicitionary/bibloteket.*(Dictionary<string, *person*> personD)
            /// </summary>




            public string name { get; set; }
            public string surname { get; set; }

            public string phonenumber { get; set; }
            public string mail { get; set; }

            public string adress { get; set; }


        }





        /// <summary>
        /// I denna metod Registerar vi användaren.Vi använder oss av dictionary och sparar all information i personD. Egenskaperna skriver in i varje konsol som sparas i varje värde från person metoden. Den unika värdet/key för varje user som sparas är Mail Adressen.  *(Dictionary<MailAdressen, person> personD)*
        /// </summary>
        /// 


        public static void Register(Dictionary<string, person> personD)
        {


           


            bool goingOne = true;

            while (goingOne)
            {


                Console.WriteLine("Write your name");
                string inputName = Console.ReadLine();

                Console.WriteLine("Write your surname");
                string inputSurName = Console.ReadLine();


                Console.WriteLine("Write your phonenumber");
                string inputPhone = Console.ReadLine();

                Console.WriteLine("Write your mail");
                string inputMail = Console.ReadLine();

                Console.WriteLine("Write your adress");
                string inputAdress = Console.ReadLine();


                if (!personD.ContainsKey(inputMail))
                {

                    personD[inputMail] = new person { name = inputName, surname = inputSurName, phonenumber = inputPhone, mail = inputMail, adress = inputAdress };

                    Console.WriteLine($"name:{inputName} added");

                    goingOne = false;
                }
                else if (personD.ContainsKey(inputMail))
                {

                    Console.WriteLine("name exist,try again");

                    goingOne = false;

                }
            }






        }





        /// <summary>
        /// I denna SearchMetod, Så har vi använt oss av en foreach loop ,som vi skapat en värde i., och loopar igenom bibloteket personD.Vi hämtar all information genom att använda dictionary i parametern, och använda värden från person metoden och hämta information från personD bibloteket. Personinfo har blivit den nya värden som vi har kombinerat med värden från person alltså alla egenskaper. Så om de finns någon information som tillhör usern som matas in i konsolen, så kommer all information att listas upp gällande usern. 
        
        /// </summary>
        /// 


        public static void Search(Dictionary<string, person> personD)
        {

            bool goingTwo = true;

            while (goingTwo)
            {
                Console.WriteLine("Enter Name to Search");
                string inputSearch = Console.ReadLine();

                bool found = false;

                foreach (var vp in personD)
                {
                    person personInfo = vp.Value;

                    if (personInfo.name.Contains(inputSearch) || personInfo.surname.Contains(inputSearch) ||
                personInfo.phonenumber.Contains(inputSearch) || personInfo.mail.Contains(inputSearch) ||
                personInfo.adress.Contains(inputSearch))
                      
                    {
                        Console.WriteLine($"{vp.Key}: {personInfo.name}, {personInfo.surname}, {personInfo.phonenumber}, {personInfo.mail}, {personInfo.adress}");
                        found = true;
                    }
                }

               if (!found) 
                {
                    Console.WriteLine("The name doesn't exist, try again");
                }

                goingTwo = false;
            }
        }











        /// <summary>
        /// Denna metod så raderar vi användaren/usern. Vi hämtar all information genom att använda dictionary i parametern och i den använder vi oss av person metoden för att hämta alla egenskaper och samt  hämta all information från bibloteket personD . Genom att ange de unika värdet för varje user (mailadressen). Så raderas all information för den usern.
        /// </summary>
        /// 



        public static void Remove(Dictionary<string, person> personD)
        {



            bool goingFour = true;


            while (goingFour)
            {


                Console.WriteLine("Write the email of the contact you want to remove");
                string inputRemove = Console.ReadLine();

                if (personD.ContainsKey(inputRemove))
                {
                    personD.Remove(inputRemove);

                    Console.WriteLine("Name removed");
                    goingFour = false;

                }


                else if (!personD.ContainsKey(inputRemove))
                {

                    Console.WriteLine("email dont exist, try again");

                    goingFour = false;

                }


            }




        }

        /// <summary>
        /// Denna metod så listar vi alla users/information.Vi hämtar all information genom att använda dictionary i parametern och hämta allt från personD där vi sparat allt. Men eftersom vi vill lista Alla namn i bokstavs ordning. Så har vi Order by funktion för att sortera alla personer utifrån deras förnamn. Och inte Utifrån deras Mail Adresser som är den Unika värdet/key varje user.
        /// </summary>
        /// 

        public static void ListP(Dictionary<string, person> personD)
        {

            var sortedList = personD.OrderBy(kp => kp.Value.name).ToList();


            bool going4 = true;


            while (going4)
            {

                Console.WriteLine("All persons:\n");

                foreach (var vp in sortedList)
                {
                    Console.WriteLine($"name:{vp.Value.name}, surname:{vp.Value.surname}, phonenumber:{vp.Value.phonenumber}, Mail:{vp.Key}:, adress:{vp.Value.adress} \n");
                }

                going4 = false;

            }




        }



       




        /// <summary>
        /// Här har vi en metod för dictionary/biblotek. Denna metod skapar  en biblotek med värdena som vi använder från person metoden.Värden från person metoderna sparas, samt så använder vi oss en av värden i person metoden, som en unik värde/key.Den gör varje user unik. Samt Laddar den upp Jsonfil/information sen innan om det finns något sparat. 
        /// </summary>
        /// <returns></returns>

        
        public static Dictionary<string, person> GetPersonDictionary()
        {
            return LoadFromJsonFile<Dictionary<string, person>>(FilePath) ?? new Dictionary<string, person>();
        }

        /// <summary>
        /// Denna metod info är main metoden som vi kör programmet/konsolen ifrån. vi har lagt in alla metoder för varje funktion i denna main metod. Med en if statement och en while loop, har vi gjort att programmet är igång, tills exit skrivs. Då avslutas programmet.
        /// </summary>

        public static void info()
        {


            ///Denna funktion använder vi bibloteket från GetpersonDicitionary metoden som vi hämtar information ifrån. Samt har vi gett denna Biblotek/information namnet personD, där all data sparas. Getpersondicitionary, gör att vi laddar tidigare jsonfil/data om det finns sparad i systemet. Om det ej finns så skapas en ny data. Men bibloteket heter alltid personD och genom den sparar vi och hämtar all information. Samt använder den i alla olika metoder för att kunna hämta information/data , biblotek.

            Dictionary<string, person> personD = GetPersonDictionary();



            ///Här har vi skapat en while loop, för att hålla igång konsolen, samt skapat en string med exit.


            bool going = true;
            string exit = "exit";

            while (going)
            {


                /// Skriver in till systemet med input funktionen. med int parsedValue och bool sucess, så har vi gjort en funktion att det bara går att skriva nummer, när vi ska välja vilken funktion vi vill använda.

                Console.WriteLine("Welcome press 1 to register, press 2 to search,press 3 to remove name,press 4 to list all names, type exit to quit");

                string input = Console.ReadLine();

                int parsedValue;

                bool sucess = int.TryParse(input, out parsedValue);




                if (parsedValue == 1 )
                {


                    Register(personD);

                  


                }

                else if (parsedValue == 2)
                {

                    Search(personD);






                }
                else if (parsedValue == 3)

                {



                   Remove(personD);



                }


                else if (parsedValue == 4)
                {
                    ListP(personD);

                }



                else if (input.ToLower() == "exit")
                {

                    ///Här sparar vi all information innan konsolen avslutas. Och den sparas i den sökvägen som vi angett sen innan. (se längst upp). Med den sparat i sökvägen så använder vi oss av när vi startar programmet för att kunna hämta information som vi sparat sen innan (LoadJsonfil) metoden.

                    SaveToJsonFile(FilePath, personD);

                    Console.WriteLine("Thank you for using the program,bye");


                    break;


                }




            }



        }

       
    }
}

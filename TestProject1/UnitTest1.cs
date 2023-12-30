using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OldStyleApp;
using static OldStyleApp.Class11;





namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {



        /// <summary>
        /// Denna testmetod, så skapar vi en jsonfil med en text *testing*. med metoden savetojsonfile. Tfilepath är namnet på filen och där den sparas, Tdata är information i filen.
        /// </summary>


        [TestMethod]
        public void Testing_Creating_Jsonfile()
        {





            // Arrange
            var Tdata = "testing";
            var TfilePath = @"C:\Projects\OldStyleApp\OldStyleApp\Testing.data";

            // Act
            Class11.SaveToJsonFile(TfilePath, Tdata);

            // Assert
            Assert.IsTrue(System.IO.File.Exists(TfilePath));
        }




        /// <summary>
        /// Vi skapar en user genom att använda bibloteket/dictionary samt värden från person metoden. Vi skriver texten med en stringReader och skickar in den via Cosole SetIn. in till Register metoden. Där efter använder vi oss av saveTojson fil, och sparar all information från dicitionary, samt Skapar och erhåller en plats (sökväg) för filen . Vi bekräftar att testet gick igenom , med att se att texten är lika med de vi förväntade oss, samt så bekräftar vi det också i jsonfilen som sparas när testet avslutas.Information som har angetts bör finnas i json filen. 
        /// </summary>

        [TestMethod]
        public void Testing_Creating_User()
        {

            // Arrange

            var personDictionary = new Dictionary<string, Class11.person>();


            var Userdata = personDictionary;
            var UserfilePath = @"C:\Projects\OldStyleApp\OldStyleApp\TestingCreatingUser.data";



            StringReader stringReader = new StringReader("TestName\nHas\n123\ntest@hotmail.com\ngatan123");

            Console.SetIn(stringReader);
            var ClassTest = new Class11();



            // Act

            Class11.Register(personDictionary);
            Class11.SaveToJsonFile(UserfilePath, Userdata);


            // ASsert

            Assert.IsTrue(personDictionary.ContainsKey("test@hotmail.com"));

            Assert.AreEqual("TestName", personDictionary["test@hotmail.com"].name);

            Assert.AreEqual("Has", personDictionary["test@hotmail.com"].surname);

            Assert.AreEqual("123", personDictionary["test@hotmail.com"].phonenumber);

            Assert.AreEqual("test@hotmail.com", personDictionary["test@hotmail.com"].mail);


            Assert.AreEqual("gatan123", personDictionary["test@hotmail.com"].adress);



        }


        /// <summary>
        ///         /// Vi skapar en user genom att använda bibloteket/dictionary samt värden från person metoden. Vi skriver texten med en stringReader och skickar in den via Cosole SetIn. Vi använder oss av jsonmetoden här, (sparar all information från bibloteket). Vi Använder Remove metoden för att ta bort all information gällande usern. Vi gör det genom de unika värdet för usern (mail adressen). Vi bekräftar att den är bortagen med assertfalse, samt jsonfilen som skapats och erhåller all information. ATt usern är borttagen.
        /// </summary>

        [TestMethod]
        public void Testing_Remove_User()
        {

            // Arrange

            var personDictionary = new Dictionary<string, Class11.person>();



            var Removedata = personDictionary;
            var RemovefilePath = @"C:\Projects\OldStyleApp\OldStyleApp\TestingRemovingUser.data";



            StringReader stringReader = new StringReader("TestRemove\n30\n123\ntest@hotmail.com\ngatan123");

            Console.SetIn(stringReader);
            var ClassTest = new Class11();

            Class11.Register(personDictionary);
            

            StringReader stringRemove = new StringReader("test@hotmail.com\n");
            Console.SetIn(stringRemove);

            // Act








            Class11.Remove(personDictionary);
Class11.SaveToJsonFile(RemovefilePath, Removedata);



            // Assert

            Assert.IsFalse(personDictionary.ContainsKey("test@hotmail.com"));


        }



        /// <summary>
        /// Vi testar sökmetoden . Vi registerar användare. sparar all information i bibloteket/json filen. Bekräftar att använder finns när vi använder stringReader genom Console set in för att söka efter användaren. Det bekräftas i Assert funktionerna att användaren finns , samt i jsonFilen som sparats.
       
        /// </summary>


        [TestMethod]
        public void Testing_Searching_User()
        {

            // Arrange

            var personDictionary = new Dictionary<string, Class11.person>();


            var Searchdata = personDictionary;
            var SearchfilePath = @"C:\Projects\OldStyleApp\OldStyleApp\TestingSearchingUser.data";



            StringReader stringReader = new StringReader("TestSearch\nfri\n123\ntest@hotmail.com\ngatan123");

            Console.SetIn(stringReader);
            var ClassTest = new Class11();

            Class11.Register(personDictionary);
            Class11.SaveToJsonFile(SearchfilePath, Searchdata);

            StringReader stringSearch = new StringReader("TestSearch\n");
            Console.SetIn(stringSearch);



            // Act


            Class11.Search(personDictionary);



            // Assert
            Assert.IsTrue(personDictionary.ContainsKey("test@hotmail.com"));

            Assert.AreEqual("TestSearch", personDictionary["test@hotmail.com"].name);

            Assert.AreEqual("fri", personDictionary["test@hotmail.com"].surname);

            Assert.AreEqual("123", personDictionary["test@hotmail.com"].phonenumber);

            Assert.AreEqual("test@hotmail.com", personDictionary["test@hotmail.com"].mail);


            Assert.AreEqual("gatan123", personDictionary["test@hotmail.com"].adress);



        }




        /// <summary>
        /// Vi testar listan för alla personer. Vi registerar två user. Sparar all information i bibloteket. Använder oss av list metoden. Kör list metoden med Dicitionary/bibloteket vi sparat all information. Sen bekräftar vi Om dessa två user finns i listan med att använda oss av Assert, och bekräfta information. Samt Sparas all information i JSonfilen som skapats.
        /// </summary>



        [TestMethod]
        public void Testing_list_User()
        {


            // Arrange

            var personDictionary = new Dictionary<string, Class11.person>();


            var Listdata = personDictionary;
            var ListfilePath = @"C:\Projects\OldStyleApp\OldStyleApp\TestingCreatingList.data";



            StringReader stringReader = new StringReader("TestlistOne\nyes\n123\ntest@hotmail.com\ngatan123");

            Console.SetIn(stringReader);
            var ClassTest = new Class11();

Class11.Register(personDictionary);


            



            StringReader stringReader1 = new StringReader("TestlistTwo\nSurName\n2\ntest2@hotmail.com\ngatan2");

            Console.SetIn(stringReader1);
            
            Class11.Register(personDictionary);
 Class11.SaveToJsonFile(ListfilePath, Listdata);
            // Act


            Class11.ListP(personDictionary);


            // ASsert

            Assert.IsTrue(personDictionary.ContainsKey("test@hotmail.com"));
            Assert.AreEqual("TestlistOne", personDictionary["test@hotmail.com"].name);
            Assert.AreEqual("yes", personDictionary["test@hotmail.com"].surname);
            Assert.AreEqual("123", personDictionary["test@hotmail.com"].phonenumber);
            Assert.AreEqual("test@hotmail.com", personDictionary["test@hotmail.com"].mail);
            Assert.AreEqual("gatan123", personDictionary["test@hotmail.com"].adress);



            Assert.IsTrue(personDictionary.ContainsKey("test2@hotmail.com"));
            Assert.AreEqual("TestlistTwo", personDictionary["test2@hotmail.com"].name);
            Assert.AreEqual("SurName", personDictionary["test2@hotmail.com"].surname);
            Assert.AreEqual("2", personDictionary["test2@hotmail.com"].phonenumber);
            Assert.AreEqual("test2@hotmail.com", personDictionary["test2@hotmail.com"].mail);
            Assert.AreEqual("gatan2", personDictionary["test2@hotmail.com"].adress);











        }
    }
}


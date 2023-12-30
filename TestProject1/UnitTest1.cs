using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OldStyleApp;
using static OldStyleApp.Class11;





namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {



        /// <summary>
        /// Denna testmetod, s� skapar vi en jsonfil med en text *testing*. med metoden savetojsonfile. Tfilepath �r namnet p� filen och d�r den sparas, Tdata �r information i filen.
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
        /// Vi skapar en user genom att anv�nda bibloteket/dictionary samt v�rden fr�n person metoden. Vi skriver texten med en stringReader och skickar in den via Cosole SetIn. in till Register metoden. D�r efter anv�nder vi oss av saveTojson fil, och sparar all information fr�n dicitionary, samt Skapar och erh�ller en plats (s�kv�g) f�r filen . Vi bekr�ftar att testet gick igenom , med att se att texten �r lika med de vi f�rv�ntade oss, samt s� bekr�ftar vi det ocks� i jsonfilen som sparas n�r testet avslutas.Information som har angetts b�r finnas i json filen. 
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
        ///         /// Vi skapar en user genom att anv�nda bibloteket/dictionary samt v�rden fr�n person metoden. Vi skriver texten med en stringReader och skickar in den via Cosole SetIn. Vi anv�nder oss av jsonmetoden h�r, (sparar all information fr�n bibloteket). Vi Anv�nder Remove metoden f�r att ta bort all information g�llande usern. Vi g�r det genom de unika v�rdet f�r usern (mail adressen). Vi bekr�ftar att den �r bortagen med assertfalse, samt jsonfilen som skapats och erh�ller all information. ATt usern �r borttagen.
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
        /// Vi testar s�kmetoden . Vi registerar anv�ndare. sparar all information i bibloteket/json filen. Bekr�ftar att anv�nder finns n�r vi anv�nder stringReader genom Console set in f�r att s�ka efter anv�ndaren. Det bekr�ftas i Assert funktionerna att anv�ndaren finns , samt i jsonFilen som sparats.
       
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
        /// Vi testar listan f�r alla personer. Vi registerar tv� user. Sparar all information i bibloteket. Anv�nder oss av list metoden. K�r list metoden med Dicitionary/bibloteket vi sparat all information. Sen bekr�ftar vi Om dessa tv� user finns i listan med att anv�nda oss av Assert, och bekr�fta information. Samt Sparas all information i JSonfilen som skapats.
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


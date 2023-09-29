using System.ComponentModel.Design;
using System.Globalization;
using System.Xml;

namespace NumbersGame
{
    internal class Program
    {
        //Viktoria Wallström .NET23
        static void Main(string[] args)
        {

            //Skriver ut i början av spelet. Använder "\n" för att byta rad.
            Console.WriteLine("Välkommen till nummerspelet!\n" +
                "Jag tänker på ett tal mellan 1 och 20, kan du gissa vilket?\n" + 
                "Du får 5 försök på dig att gissa rätt. Lycka till!\n" +
                "-----------------------------------------------------------"); //Gör så koden delar upp sig på ett snyggt sätt i konsollen

            CheckGuess(); //Antopar metoden "CheckGuess"

        }


        static void CheckGuess() //Metod som testar om det användaren skrivit är rätt eller fel
        {
            Random random = new Random(); //Skapar en slumpmässig generator
            int randomNumber = random.Next(1, 21); //Genererar en slumpmässig siffra mellan 1 och 20

            int attempts = 5; //Antal försök användaren har på sig
            bool guessedCorrectly = false; //En bool som kör loopen så länge guessedCorrectly är falsk

            for (int i = 1; i <= attempts; i++) //En loop som ökar gissnningsförsök med 1 för varje gissning och sparas i variabeln "i"
            {
                Console.Write($"Gissning nummer {i}: "); //Skriver ut antal gissningsförsök

                int userGuess;
                try //Testar om användaren skriver rätt inmatning
                {
                    userGuess = int.Parse(Console.ReadLine()); //Konverterar användarens inmatning från en sträng till heltal
                }
                catch (FormatException) //Fångar upp ifall användaren skriver annat än siffror
                {
                    Console.WriteLine("Fel inmatning, du kan endast ange siffror.");
                    i--; //Minskar antalet gissningsförsök med 1 för att inte använda felskrivningen som ett försök

                    continue; //Fortsätter spelet
                }


                if (userGuess == randomNumber) //Om användarens gissning är samma som det slumpmässiga talet
                {
                    guessedCorrectly = true; //Ändrar boolen till sant
                    Console.WriteLine($"Wohoo, du gissade rätt! Det rätta talet är {randomNumber}. Bra jobbat!\n" + 
                        "--------------------------------------------------------------"); 
                    PlayAgain(); //Anropar metoden PlayAgain()

                }
                else if (userGuess < randomNumber && i != attempts) //Om användaren gissar lägre än det slumpmässiga talet och om antal försök inte är lika med 5
                {
                    Console.WriteLine("Du gissade för lågt. Försök igen."); //Skriv ut till användaren
                }
                else if (userGuess > randomNumber && i != attempts) //Om användaren gissar högre än det slumpmässiga talet och om antal försök inte är lika med 5
                {
                    Console.WriteLine("Du gissade för högt. Försök igen."); //Skriv ut till användaren
                }
                //Om användaren inte lyckas gissa talet på 5 försök och antal försök är lika med 5
                if (!guessedCorrectly && i == attempts) 
                {

                    Console.WriteLine($"Tyvärr. Du lyckades inte gissa rätt på 5 försök. Det rätta talet var {randomNumber}!");
                    PlayAgain(); //Anropar metoden PlayAgain()
                    
                }
            }
            

        }   
            static void PlayAgain() //Metod för att spela igen

            {
            while (true) //Loop som körs så länge villkoret är sant
            {
                Console.WriteLine("Vill du spela igen? Ja/Nej");
                string userInPut = Console.ReadLine();

                if (userInPut == "Ja" || userInPut == "ja") //Om användaren svarar Ja eller ja
                {
                    CheckGuess(); //Anropar metoden CheckGuess 
                }
                else if (userInPut == "Nej" || userInPut == "nej") //Om användaren svarar Nej eller nej
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode; //Används för att stödja specialtecken
                    string emoji = "👍"; //String för emoji som sparas i variabeln emoji 

                    Console.Clear(); //Rensar konsollen
                    Console.WriteLine("Tack för att du spelat! " + emoji);
                    Environment.Exit(0); //Stänger programmet
                }
                else //Om användaren skriver fel inmatning
                {
                    Console.WriteLine("Fel inmatning. Svara Ja eller Nej.");
                    continue; //Fortsätter fråga tills användaren ger rätt inmatning
                }
                }
            

            }
    }
}
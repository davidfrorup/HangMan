namespace HangMan
{
    internal class Program
    {
        static string guessedLetters = "";
        static int lifeLeft = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! And welcome to HangMan!");

            string word = RandomWord();

            while (true)
            {
                GUI(word);
                string letter = InputLetter();
                AddLetterToGuessed(letter);
                IsLetterInWord(word, letter);
            }
            
        }

        static string InputLetter()
        {

            char letter;
            do
            {

                Console.Write("\n\nInput a letter");
                letter = char.ToUpper(Console.ReadKey().KeyChar);
            }
            while (!char.IsLetter(letter));
           
                return letter.ToString();
        }


        static void IsLetterInWord(string word, string letter)
        {
            if (word.Contains(letter)) Console.WriteLine("Good job!");
            else
            {
                Console.WriteLine("Wrong!");
                lifeLeft--;
                Hangman();
            }
        }

        static void Hangman()
        {
            lifeLeft--;
            if (lifeLeft == 0) Console.WriteLine("You lost! :-( ");
        }





        static void AddLetterToGuessed(string letter)
        { 
        if (guessedLetters.Contains(letter))
            {
                Console.WriteLine("You already guessed that letter");
            }
        else { guessedLetters += letter;  }
        }


        //static void TestingKeyboard()
        //{
        //    while(true) 
        //    {
        //    ConsoleKeyInfo
        //    }
        //}



        static void GUI(string word)
        {
            //int numLetters = word.Length;
            Console.WriteLine($"\n {lifeLeft} \nGuessed letters: {guessedLetters} \n");
            
            foreach(char letter in word)
            {
                if (guessedLetters.Contains(letter)) Console.Write(letter);
                else Console.Write("_");
            }


            //for (int i = 0; i < numLetters; i++) 
            //{
            //    if (guessedLetters.Contains(word[i])) Console.Write(word[i]);
            //    else Console.Write("_");

            //}
            //string underScores = "".PadLeft(numLetters, '_');
            //Console.WriteLine(underScores);
        }

        static string RandomWord()
        {
            string[] words = { "Kaffekrus", "Elefant", "Skygge", "Blyant", "Vindmølle", "Chokolade", "Regnbue", "Skjorte", "Telefon", "Bjergtop", "Fuglesang", "Lommelygte", "Havbølge", "Stjerneskud" };


           // return words{new Random().Next(words.Length)}; ;

            Random rnd = new Random();
            int num = rnd.Next(words.Length);
            string word = words[num];
            return word.ToUpper();


        }

    }
}
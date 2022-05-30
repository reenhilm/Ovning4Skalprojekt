using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            //Stack & Heap frågor
            //1. Stacken fungerar så att referens-typer allokeras på heapen och value-typer kan allokeras på stacken eller heapen beroende på om dom är deklarerade i en klass/struct eller inte. I fallet struct så beror det på om struct blir deklarerad på heap eller stack.
            //2. value-types blir kopierade varje gång man tilldelar dess värde till en ny plats, referens types ger istället sin referens när man tilldelar dess värde till en ny plats
            //3. i första exemplet har värdet av x har blivit kopierat till y och x förblir då oförändrat och fortfarande 3 när man byter y till 4. i andra exemplet när x är en referens-typ gör vi en tilldelning y = x att alltså både y och x ska båda referera till samma plats och vi ändrar värdet på platsen till 4 alltså refererar även x till 4.
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            //1. Har skrivit klart implementationen så att undersökningen blev genomförbar
            //2. Den ökar vid första instättningen från 0 till 4
            //3. Den ökar med 4 varje gång.
            //4. Varje gång den ökar allokeras den interna arrayen till en ny större med ny length och den gamla städas senare upp av GC
            //5. Nej den minskar inte
            //6. När man inte ska lägga till eller ta bort några element i arrayen. Men ingen stor fördel mot att man angett capacity för listan i konstruktorn för listan.

            List<string> theList = new ();
            Console.WriteLine("A new list has been created");
            OutputCountAndCapacity(theList);
            //Loop this method untill the user inputs something to exit to main menue.
            string input = ""; //Creates the character input to be used with the switch-case below.
            do
            {
                Console.WriteLine("+Adam (adds Adam to list)");
                Console.WriteLine("-Adam (removes Adam to list)");                
                Console.WriteLine("0.Exit to main menu");
                try
                {
                    input = Console.ReadLine()!; //Tries to set input to the first char in an input line 
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (GetFirstCharOrEmpty(input))
                {
                    //'+': Add the rest of the input to the list(The user could write + Adam and "Adam" would be added to the list)
                    case '+':
                        AddToList(theList, input);
                        OutputCountAndCapacity(theList);
                        break;
                    //'-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                    case '-':
                        RemoveFromList(theList, input);
                        OutputCountAndCapacity(theList);
                        break;
                    //As a default case, tell them to use only + or -
                    default:
                        Console.WriteLine("use only + or -");
                        break;
                }
            }
            while (input != "0");
        }

        private static void OutputCountAndCapacity(List<string> theList)
        {
            //In both cases, look at the count and capacity of the list
             Console.WriteLine($"List count:{theList.Count}, List capacity:{theList.Capacity}");
        }

        private static void OutputCount(Stack<char> stack)
        {
            Console.WriteLine($"Stack count:{stack.Count}");
        }

        private static void OutputCount(Queue<string> icaQueue)
        {
            //Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            Console.WriteLine($"Queue count:{icaQueue.Count}");
        }

        public static string GetTextAfterOperator(string input)
        {
            if (input.Length >= 2)
                return input.Substring(1);
            else
                return "";
        }

        public static void AddToQueue(Queue<string> icaQueue, string input)
        {
            string item = GetTextAfterOperator(input);
            icaQueue.Enqueue(GetTextAfterOperator(input));
            Console.WriteLine($"{item} added to queue");
        }

        public static void AddToList(List<string> theList, string input)
        {
            string item = GetTextAfterOperator(input);
            theList.Add(item);
            Console.WriteLine($"{item} added to list");
        }

        public static void RemoveFromList(List<string> theList, string input)
        {
            string item = GetTextAfterOperator(input);
            //TODO check if Equals does correct thing we want here
            bool bWasRemoved = theList.Remove(item);
            if(bWasRemoved)
                Console.WriteLine($"{item} removed from list");
            else
                Console.WriteLine($"{item} was not found in list");
        }

        public static char GetFirstCharOrEmpty(string input)
        {
            if (input.Length > 0)
                return input[0];
            else
                return ' ';
        }


        static void TestQueue()
        { 
            Queue<string> icaQueue = new();
            Console.WriteLine("A new queue has been created - ICA öppnar och kön till kassan är tom");
            icaQueue.Enqueue("Kalle");
            icaQueue.Enqueue("Greta");
            icaQueue.Dequeue();
            icaQueue.Enqueue("Stina");
            icaQueue.Dequeue();
            icaQueue.Enqueue("Olle");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

            Queue<string> icaQueue = new();
            Console.WriteLine("A new queue has been created");
            OutputCount(icaQueue);
            //Loop this method untill the user inputs something to exit to main menue.
            string input = ""; //Creates the character input to be used with the switch-case below.         
            do
            {
                Console.WriteLine("+Adam (Enqueue Adam)");
                Console.WriteLine("1. Dequeue");
                Console.WriteLine("0.Exit to main menu");
                try
                {
                    input = Console.ReadLine()!; //Tries to set input to the first char in an input line 
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                //Create a switch with cases to enqueue items or dequeue items
                switch (GetFirstCharOrEmpty(input))
                {
                    //'+': Add the rest of the input to the queue(The user could write + Adam and "Adam" would be added to the queue)
                    case '+':
                        AddToQueue(icaQueue, input);
                        OutputCount(icaQueue);
                        break;
                    //'1': Remove the first item in queue
                    case '1':
                        string item = icaQueue.Dequeue();
                        Console.WriteLine($"{item} removed from queue");
                        OutputCount(icaQueue);
                        break;
                    //As a default case, tell them to use only + or 1
                    default:
                        Console.WriteLine("use only + or 1");
                        break;
                }
            }
            while (input != "0");
        }

        static void ReverseText(string input)
        {
            Console.WriteLine("A new stack has been created");
            Stack<char> charStack = new();
            OutputCount(charStack);
            foreach (char c in input)
                charStack.Push(c);

            while (charStack.Count > 0)
                Console.Write(charStack.Pop());
            Console.WriteLine();
            OutputCount(charStack);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            //1. För att vi måste då lagra personerna vi tar bort med pop någon annanstans till det är deras tur och det blir krångligt att hålla reda på vems tur det är         
            //Loop this method untill the user inputs something to exit to main menue.
            string input = ""; //Creates the character input to be used with the switch-case below.
            do
            {
                Console.WriteLine("Write text to reverse the text");
                Console.WriteLine("0.Exit to main menu");
                try
                {
                    input = Console.ReadLine()!; //Tries to set input to the first char in an input line 
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                ReverseText(input);
            }
            while (input != "0");

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}


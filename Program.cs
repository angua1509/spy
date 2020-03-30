using System;

namespace exercisesSoloLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }




        // function to figure out how many digits the input has
        static int CountDigits(int number)
        {
            // In case of negative numbers
            number = Math.Abs(number);

            if (number >= 10)
                return CountDigits(number / 10) + 1;
            return 1;
        }
        static void MainMenu()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("                     Spy Numbers                             ");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("a number is a spy number if the sum of its digits            ");
            Console.WriteLine("and the product of its digits are equal                      ");
            Console.WriteLine("use my awesome programm to see if a number is a spy number   ");
            Console.WriteLine("or let it generate spy numbers in a range of your choice     ");
            Console.WriteLine("     example 123: 1 + 2 + 3 = 6  and 1 * 2 * 3 = 6           ");
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine();
            string menu;

            do
            {
                Console.WriteLine("     ---------------------------------------------");
                Console.WriteLine("                 [C] Check number                 ");
                Console.WriteLine("                 [G] Get Spy number in range      ");
                Console.WriteLine("                 [Q] Quit                         ");
                Console.WriteLine("     ---------------------------------------------");
                menu = Console.ReadLine();

                if (menu == "c" || menu == "C")
                {
                    CheckNumber();
                }
                else if (menu == "g" || menu == "G")
                {
                    CreateNumber();
                }
                else if (menu == "q" || menu == "Q")
                {
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Unknown Commmand. Please try again!");
            } while (menu != "q" && menu != "Q");
        }
        
        static void CheckNumber()
        {
            // promt user for input and store in variable
            Console.Write("Which number do you want to check?: ");
            int input = Convert.ToInt32(Console.ReadLine());
            // determine how many digits that number has
            int amountDigits = CountDigits(input);
            // get the single digits of that number
            int[] digits = GetDigits(amountDigits, input);
            // determine sum and product of the digits
            int sum = GetSum(digits);
            int product = GetProduct(digits);
            // check if it is a spy number
            if (sum == product)
            {
                Console.WriteLine();
                Console.WriteLine("Your number is a Spy Number!");
                Console.WriteLine("The sum of its digits is: {0}", sum);
                Console.WriteLine("The Product of it's digits is: {0}", product);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Your number is NOT a Spy Number!");
                Console.WriteLine("The sum of its digits is: {0}", sum);
                Console.WriteLine("The Product of it's digits is: {0}", product);
                Console.WriteLine();
            }
        }
        
        static void CreateNumber()
        {
            // promt user for input and store in variables
            Console.Write("Where does your range start?: ");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Where does your range end?: ");
            int end = Convert.ToInt32(Console.ReadLine());
            // create array in size of the number of digits the user enters
            int amountDigits = CountDigits(end);
            // create array to store potential spynumbers
            int rangeLength = end - start;
            int[] spyNumbers = new int[rangeLength];

            // loop through numbers from start to end
            for (int i = 0; i < rangeLength; i++)
            {
                int[] digits = GetDigits(amountDigits, start + i);
                int sum = GetSum(digits);
                int product = GetProduct(digits);
                // if its is a spyNumber put it in the array
                if (sum == product)
                {
                    spyNumbers[i] = start;
                }
            }
            Console.WriteLine("Your range from {0} to {1} contains the following SpyNumbers: ", start, end);
            for (int i = 0; i < spyNumbers.Length; i++)
            {
                if (spyNumbers[i] != 0)
                {
                    Console.Write(spyNumbers[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static int[] GetDigits(int a, int b)
        {
            int[] digits = new int[a];
            for (int j = 0; j < a; j++)
                {
                    digits[j] = b % 10;
                    b /= 10;
                }
            return digits;
        }
        static int GetSum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }
        static int GetProduct(int[] a)
        {
            int product = 1;
            for (int i = 0; i < a.Length; i++)
            {
                
                if (a[i] != 0)
                {
                    product *= a[i];
                } 
            }
            return product;
        }
    }
}

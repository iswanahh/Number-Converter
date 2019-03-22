using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numberconverter
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] tens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] twenties = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] hundreds = { "", "One Hundred", "Two Hundred", "Three Hundred", "Four Hundred", "Five Hundred", "Six Hundred", "Seven Hundred", "Eight Hundred", "Nine Hundred" };
            string[] thousands = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septilion", "octillion" };

            Console.WriteLine("Enter a number");
            string number = Console.ReadLine();
            //check if it empty or null first,

            bool _isValidNumber = IsValidNumber(number);


            if (_isValidNumber == false)
            {
                //means the number is not valid
                //so you can either display an error message or recollect input
            }

            else {

                string result = GetWordForNumber(number);
                Console.WriteLine(result);
                Console.ReadKey(true);
            }
            





        }
        public static string GetWordForNumber(string input) {
            int Numlegth = input.Length;
            bool isCompleted = false;
            string word = "";

            int position = 0;
            string place = "";
            switch (Numlegth)

            {
                case 1:
                    //single
                    //call a method that takes in the digit and returns the string then 
                    word = ConvertSingleDigit(input);
                    isCompleted = true;
                    break;
                case 2:
                    //tens
                    //call a method that takes in the two digits and returns their word representation
                    word = ConvertDoubleDigits(input);
                    isCompleted = true;
                    break;

                case 3:
                    //hundreds
                    position = (Numlegth % 3) + 1;
                    place = " Hundred ";
                    break;

                case 4:
                case 5:
                case 6:
                    //thousands

                    position = (Numlegth % 4) + 1;
                    place = " Thousand ";
                    break;
                case 7:
                case 8:
                case 9:
                    //millions
                    position = (Numlegth % 7) + 1;
                    place = " Million ";
                    break;

                case 10:
                case 11:
                case 12:
                    //trillions

                    position = (Numlegth % 10) + 1;
                    place = " Billion ";
                    break;

                case 13:
                case 14:
                case 15:
                    position = (Numlegth % 13) + 1;
                    place = " Trillion ";
                    break;

                default:
                    isCompleted = true;
                    break;

            }

            if (!isCompleted)
            {//if transalation is not done, continue...(Recursion comes in now!!)    
                if (input.Substring(0, position) != "0" && input.Substring(position) != "0")
                {
                    try
                    {
                        word = GetWordForNumber(input.Substring(0, position)) + place + GetWordForNumber(input.Substring(position));
                    }
                    catch
                    {

                    }
                }
                else
                {
                    word = GetWordForNumber(input.Substring(0, position)) + GetWordForNumber(input.Substring(position));
                }

            }
            //ignore digit grouping names    
            if (word.Trim().Equals(place.Trim()))
            {

                word = "";
            }
        
        
        
           return word.Trim();  
        
    }
        private static string ConvertSingleDigit(string input)
        {
            int _convertedNumber = Convert.ToInt32(input);
            string word = "";
            switch (_convertedNumber)
            {

                case 1:
                    word = "One";
                    break;
                case 2:
                    word = "Two";
                    break;
                case 3:
                    word = "Three";
                    break;
                case 4:
                    word = "Four";
                    break;
                case 5:
                    word = "Five";
                    break;
                case 6:
                    word = "Six";
                    break;
                case 7:
                    word = "Seven";
                    break;
                case 8:
                    word = "Eight";
                    break;
                case 9:
                    word = "Nine";
                    break;
            }
            return word;
        }
        private static string ConvertDoubleDigits(string input)
        {
            int _convertedNumber = Convert.ToInt32(input);
            string word = null;
            switch (_convertedNumber)
            {
                case 10:
                    word = "Ten";
                    break;
                case 11:
                    word = "Eleven";
                    break;
                case 12:
                    word = "Twelve";
                    break;
                case 13:
                    word = "Thirteen";
                    break;
                case 14:
                    word = "Fourteen";
                    break;
                case 15:
                    word = "Fifteen";
                    break;
                case 16:
                    word = "Sixteen";
                    break;
                case 17:
                    word = "Seventeen";
                    break;
                case 18:
                    word = "Eighteen";
                    break;
                case 19:
                    word = "Nineteen";
                    break;
                case 20:
                    word = "Twenty";
                    break;
                case 30:
                    word = "Thirty";
                    break;
                case 40:
                    word = "Fourty";
                    break;
                case 50:
                    word = "Fifty";
                    break;
                case 60:
                    word = "Sixty";
                    break;
                case 70:
                    word = "Seventy";
                    break;
                case 80:
                    word = "Eighty";
                    break;
                case 90:
                    word = "Ninety";
                    break;
                default:
                    if (_convertedNumber > 0)
                    {
                        //break into two parts, one to take care of the tens and the remainder
                        word = ConvertDoubleDigits(input.Substring(0, 1) + "0") + " " + ConvertSingleDigit(input.Substring(1));
                    }
                    break;
            }
            return word;
        }
        public static bool IsValidNumber(string input)
        {

            if (string.IsNullOrEmpty(input))
            {

                return false;
            
            }

           else
            {

                for(int i = 0; i <input.Length; i++)
                {

                    if(!(i >= 0 && i <= 9|| i == 46))
                    {
                    return false;
                    }
                    else
                    {
                    return true;
                    }

                }
                return false;
            }

            
        }
    }
}

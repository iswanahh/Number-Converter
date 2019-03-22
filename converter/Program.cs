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
            int rightValue = int.Parse(number);
            string newnumber = "";
            int a, b;
            if (rightValue >= 1 && rightValue < 100)
            {
                a = rightValue / 10;
                b = rightValue % 10;
                if (a == 1)
                {
                    newnumber += tens[a];
                }
                else
                {

                    newnumber += twenties[a] + " " + units[b];
                }
            }

            else if (rightValue >= 100 && rightValue <= 1000000000)
            {
                int single_digit, ten_digit, hundred_digit;
                if (number.Length == 3)
                {



                    single_digit = rightValue % 10;
                    ten_digit = ((rightValue % 100) - single_digit) / 10;
                    hundred_digit = ((rightValue % 1000) - (ten_digit * 10) - single_digit) / 100;
                    // hundred_digit = number[0];
                    string t = "";
                    string h = "";
                    if (hundred_digit != 0 && ten_digit == 0 && single_digit == 0)
                    {
                        t = units[hundred_digit] + " hundred";
                    }
                    else if (hundred_digit != 0)
                    {
                        t = units[hundred_digit] + " hundred and ";
                        if (ten_digit < 1)
                        {
                            h = units[rightValue % 100];
                        }
                        else if (ten_digit == 1)
                        {
                            h = tens[rightValue % 10];
                        }
                        else
                        {
                            h = twenties[ten_digit] + " " + units[single_digit];
                        }
                    }


                    newnumber = t + h;

                }


            }


            Console.WriteLine("The number you typed in is: " + newnumber);




            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationSystems
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Type linear equations in augmented matrix notation: a1 a2... aN d +" +
                              "\nWhere a1..N are coefficients and d is constant");

            bool contin = true;
            int numberOfEq;
            while (contin)
            {
                Console.Write("\nEnter number of equations: "); 

                numberOfEq = int.Parse(Console.ReadLine());
                SystemOfEquation newEquation = new SystemOfEquation(numberOfEq, numberOfEq + 1);
                newEquation.augMatrix.SetLinearEquationMatrix();
                newEquation.DisplayEquation();
                newEquation.DisplayX();

                Console.Write("\nDo you want to continue(y/n): ");
                if (askForContinue(Console.ReadLine()))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    contin = false;
                }
            }
        }

        static public bool askForContinue(string input)
        {
            if (input[0].ToString().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    

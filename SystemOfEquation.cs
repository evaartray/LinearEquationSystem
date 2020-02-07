using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationSystems
{
    public class SystemOfEquation //:AugmentedMatrix
    {
        private readonly Calculator calculate;
        private readonly AugmentedMatrix augMatrix;
        public double[,] matrix;
        public int nRow;
        public int nColumn;

        //getting values of rows and columns from matrix class
        public SystemOfEquation(int newNumberOfEquation, int newNumberOfUnknown)
            //: base(newNumberOfEquation, newNumberOfUnknown)
        {
            augMatrix = new AugmentedMatrix(newNumberOfEquation, newNumberOfUnknown);
            nRow = augMatrix.nRow;
            nColumn = augMatrix.nRow;
            matrix = augMatrix.matrix;
            calculate = new Calculator(matrix); //assigning matrix parameters into calculator
        }

        //eliminating next x and pivoting nex p, then returning backward result
        public double[] GetRoot()
        {
            calculate.ForwardEliminationMatrix();
            calculate.Pivoting();
            return calculate.BackwardsSubstitution();
        }


        //loop of dispaying the equation
        public void DisplayEquation()
        {
            Console.Clear();
            string[] variableArray = Enumerable.Repeat("X", nColumn).ToArray();
            Console.WriteLine("You have entered the following equation:");
            for (int i = 0; i < nRow; i++)
            {
                Console.Write("Eq #{0}: ", i + 1);
                for (int j = 0; j < nColumn; j++)
                {
                    //if adding x
                    if (matrix[i, j] > 0 && j < (nColumn - 1) && j > 0)
                    {
                        Console.Write("+ {0}*{1}{2} ", matrix[i, j], "X", j + 1);
                    }
                    //if subtracting x
                    if (matrix[i, j] < 0 && j < (nColumn - 1) && j > 0)
                    {
                        Console.Write("- {0}*{1}{2} ", Math.Abs(matrix[i, j]), "X", j + 1);
                    }
                    //if number in the column is 0
                    if (j == 0)
                    {
                        Console.Write("{0}*{1}{2} ", matrix[i, j], "X", j + 1);
                    }
                    //if number in the column is -1
                    if (j == (nColumn - 1))
                    {
                        Console.Write("= {0}", matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        //displaying results of calculating
        public void DisplayX()
        {
            var result = GetRoot();
            Console.WriteLine("\nResult: ");

            int numX = GetRoot().Length;
            for (int i = 0; i < numX; i++)
            {
                Console.WriteLine("X{0}: {1}", i + 1, result[i]);
            }
        }

       
    }
}

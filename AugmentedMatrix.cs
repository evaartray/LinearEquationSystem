using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationSystems
{
    public class AugmentedMatrix //base class to set coefficients to system of equations
    {
        //matrix parameters
        public readonly int nRow;
        public readonly int nColumn;
        public readonly double[,] matrix;

        public AugmentedMatrix(int newRow, int newCol)
        {
            nRow = newRow;
            nColumn = newCol;
            matrix = new double[nRow, nColumn]; //setting defined rows and columns into a new matrix
        }

        //looping output for every next coefficient
        public double[,] SetLinearEquationMatrix()
        {
            for (int i = 0; i < nRow; i++)
            {
                Console.WriteLine("\nEnter coefficient for Eq #{0}: ", i + 1);

                int input;
                for (int j = 0; j < nColumn; j++)
                {
                    Console.Write("Coefficient #{0}: ", j + 1);

                    //if value for detected coefficient was wrong
                    while (!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.Write("Please enter cofficient #{0} again: ", j + 1);
                    }
                    matrix[i, j] = input;
                }
            }
            return matrix;
        }

    }
}


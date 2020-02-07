using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationSystems
{
    class Calculator //implicit calculator to handle equation solving step by step
    {
        private int nRow;
        private int nColumn;
        public double[,] matrix;

        public Calculator(double[,] newMatrix)
        {
            matrix = newMatrix;
            nRow = matrix.GetLength(0);
            nColumn = matrix.GetLength(1);
        }

        //using row operations to transform the matrix:
        //assigning non-zero only to the first coefficient in the first row, but zero in all the others
        public double[,] ForwardEliminationMatrix()
        {
            for (int i = 0; i < nRow; i++) //handle the row
            {
                for (int j = i + 1; j < nRow; j++) //handle the next rows
                {
                    double factor = matrix[j, i] / matrix[i, i];

                    for (int k = i; k < nColumn; k++)
                    {
                        matrix[j, k] -= factor * matrix[i, k];
                    }
                }
            }
            return matrix;
        }

        //calculating result
        public double[] GetRoot()       
        {
            ForwardEliminationMatrix();
            Pivoting();
            return BackwardsSubstitution();
        }
        
        //using the solution from forward elimination as substitution for var from second to last row
        public double[] BackwardsSubstitution()
        {
            double[] result = new double[nRow];          
            for (int i = nRow - 1; i >= 0; i--) //handle the row from bottom to top
            {
                result[i] = matrix[i, nColumn - 1];
                for (int j = i + 1; j <= nRow - 1; j++) //handle the next row
                {
                    result[i] -= matrix[i, j] * result[j];
                }
                result[i] = result[i] / matrix[i, i];
            }
            return result;
        }

        //swaping rows for pivoting after
        private void SwapRow(int rowA, int rowB)
        {
            double[] temp = new double[nColumn];
            for (int i = 0; i < nColumn; i++)
            {
                temp[i] = matrix[rowA, i];
                matrix[rowA, i] = matrix[rowB, i];
                matrix[rowB, i] = temp[i];
            }
        }

        //take the largest coefficient in the column, swap rows to make the largest coefficient ends up on the diagonal
        public void Pivoting()
        {
            for (int i = 0; i < nColumn - 1; i++) //control column
            {
                double highestPivot = matrix[i, i]; //control row
                for (int j = i + 1; j < nRow; j++)
                {
                    if (matrix[j, i] > highestPivot && matrix[j, i] != 0)
                    {
                        highestPivot = matrix[j, i];
                        SwapRow(i, j);
                    }
                }
            }
        }
    }
}


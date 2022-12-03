using System.Collections.ObjectModel;
using System.Linq;

namespace PIF1006_tp2
{
    class CalculMatrice
    {
        internal static double Determinant(double[,] matrix, int v)
        {
            double retour = 0;
            if (v == 2)
            {
                retour = MatrixTwoByTwo(matrix);
            }
            else
            {
                ObservableCollection<double[,]> subMatrices = new ObservableCollection<double[,]>();
                for (int i = 0; i != v; i++)
                {
                    subMatrices.Add(GenerateSubMatrice(i, matrix));
                }
                for (int i = 0; i != v; i++)
                {
                    if (i % 2 == 0)
                    {
                        retour += matrix[0, i] * Determinant(subMatrices.ElementAt(i), subMatrices.ElementAt(i).GetLength(0));
                    }
                    else
                    {
                        retour -= matrix[0, i] * Determinant(subMatrices.ElementAt(i), subMatrices.ElementAt(i).GetLength(0));
                    }
                }
            }
            return retour;
        }

        private static double[,] GenerateSubMatrice(int i, double[,] matrix)
        {
            double[,] temp = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            int compteur = 0;
            for (int x = 1; x != matrix.GetLength(0); x++)
            {
                for (int j = 0; j != matrix.GetLength(1); j++)
                {
                    if (j != i)
                    {
                        temp[x - 1, compteur] = matrix[x, j];
                        compteur++;
                        if (compteur == temp.GetLength(1))
                        {
                            compteur = 0;
                        }
                    }
                }
            }
            return temp;
        }

        private static double MatrixTwoByTwo(double[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        internal static Matrix2D SousMatrice(int i, int j, double[,] matrix)
        {
            double[,] temp = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            int comptCol = 0;
            int comptRow = 0;
            for (int x = 0; x != matrix.GetLength(0); x++)
            {
                for (int y = 0; y != matrix.GetLength(1); y++)
                {
                    if (x != i && y != j)
                    {
                        temp[comptRow, comptCol] = matrix[x, y];
                        comptCol++;
                        if (comptCol == temp.GetLength(0))
                        {
                            comptCol = 0;
                            comptRow++;
                        }
                    }
                }
            }
            Matrix2D subM = new Matrix2D("SousMatrice", matrix.GetLength(0), matrix.GetLength(1));
            subM.SetMatrix(temp);
            return subM;
        }
    }
}

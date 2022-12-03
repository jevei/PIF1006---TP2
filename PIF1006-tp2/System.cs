using System;

namespace PIF1006_tp2
{
    public class System
    {
        public Matrix2D A { get; private set; }
        public Matrix2D B { get; private set; }

        public System(Matrix2D a, Matrix2D b)
        {
            // Doit rester tel quel

            A = a;
            B = b;
        }

        public bool IsValid()
        {
            // À compléter (0.25 pt)
            // Doit vérifier si la matrix A est carrée et si B est une matrice avec le même nb
            // de ligne que A et une seule colonne, sinon cela retourne faux.
            // Avant d'agir avec le système, il faut toujours faire cette validation
            int nbRow = 0;
            int nbCol = 0;
            for (int i = 0; i != A.Matrix.GetLength(0); i++)
            {
                nbRow++;
            }
            bool carre = A.IsSquare();
            for (int i = 0; i != B.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j != B.Matrix.GetLength(1); j++)
                {
                    nbCol++;
                }
            }
            if (nbCol == nbRow && carre == true)
            {
                return true;
            }
            Console.WriteLine("Erreur: Système non valide.");
            Environment.Exit(0);
            return false;
        }

        public Matrix2D SolveUsingCramer()
        {
            // À compléter (1 pt)
            // Doit retourner une matrice X de même dimension que B avec les valeurs des inconnus 
            IsValid();
            double det = A.Determinant();
            Matrix2D result = new Matrix2D("Cramer", B.Matrix.GetLength(0), B.Matrix.GetLength(1));
            for (int i = 0; i != B.Matrix.GetLength(0); i++)
            {
                Matrix2D temp = new Matrix2D("temp", A.Matrix.GetLength(0), A.Matrix.GetLength(1));
                temp.SetMatrix(SetupMatrice(A.Matrix));
                for (int j = 0; j != temp.Matrix.GetLength(0); j++)
                {
                    temp.Matrix[j, i] = B.Matrix[j, 0];
                }
                result.Matrix[i, 0] = temp.Determinant() / det;
            }
            return result;
        }

        private double[,] SetupMatrice(double[,] matrix)
        {
            double[,] retour = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i != matrix.GetLength(0); i++)
            {
                for (int j = 0; j != matrix.GetLength(1); j++)
                {
                    retour[i, j] = matrix[i, j];
                }
            }
            return retour;
        }

        public Matrix2D SolveUsingInverseMatrix()
        {
            // À compléter (0.25 pt)
            // Doit retourner une matrice X de même dimension que B avec les valeurs des inconnus 
            IsValid();
            Matrix2D inverse = A.Inverse();
            Matrix2D result = new Matrix2D("InverseResult", B.Matrix.GetLength(0), B.Matrix.GetLength(1));
            if (inverse != null)
            {
                Matrix2D temp = new Matrix2D("temp", inverse.Matrix.GetLength(0), inverse.Matrix.GetLength(1));
                temp.SetMatrix(SetupMatrice(inverse.Matrix));
                for (int i = 0; i != B.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j != temp.Matrix.GetLength(0); j++)
                    {
                        temp.Matrix[i, j] *= B.Matrix[j, 0];
                    }
                    result.Matrix[i, 0] = RowSum(i, temp.Matrix);
                }
            }
            return result;
        }

        private double RowSum(int i, double[,] matrix)
        {
            double result = 0;
            for (int j = 0; j != matrix.GetLength(0); j++)
            {
                result += matrix[i, j];
            }
            return result;
        }

        public Matrix2D SolveUsingGauss()//0=Lx-Ly*z
        {
            // À compléter (1 pts)
            // Doit retourner une matrice X de même dimension que B avec les valeurs des inconnus 
            IsValid();
            Matrix2D result = new Matrix2D("Gauss", B.Matrix.GetLength(0), B.Matrix.GetLength(1));
            Matrix2D temp = new Matrix2D("temp", A.Matrix.GetLength(0), A.Matrix.GetLength(1));
            result.SetMatrix(SetupMatrice(B.Matrix));
            temp.SetMatrix(SetupMatrice(A.Matrix));
            for (int i = 0; i != A.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j != temp.Matrix.GetLength(1); j++)
                {
                    if (j != i)
                    {
                        double facteur = FindFacteur(temp.Matrix[i, i], temp.Matrix[j, i]);
                        temp.SoustraireFacteur(j, facteur, i);
                        result.SoustraireFacteur(j, facteur, i);
                    }
                }
            }
            for (int i = 0; i != A.Matrix.GetLength(0); i++)
            {
                result.Matrix[i, 0] /= temp.Matrix[i, i];
            }
            return result;
        }

        private double FindFacteur(double v1, double v2)//pour trouver le z de 0=Lx-Ly*z
        {
            return v2 / v1;
        }

        public override string ToString()
        {
            // À compléter (0.5 pt)
            // Devrait retourner en format:
            // 
            // 3x1 + 5x2 + 7x3 = 9
            // 6x1 + 2x2 + 5x3 = -1
            // 5x1 + 4x2 + 5x3 = 5
            IsValid();
            string temp = "";
            for (int i = 0; i != A.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j != A.Matrix.GetLength(1); j++)
                {
                    temp += A.Matrix[i, j] + "x" + (j + 1) + " ";
                    if (j + 1 != A.Matrix.GetLength(1))
                    {
                        temp += "+ ";
                    }
                    else
                    {
                        temp += "= " + B.Matrix[i, 0];
                    }
                }
                temp += "\n";
            }
            return temp;
        }
    }
}

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
            return A.Comatrix();
        }

        public Matrix2D SolveUsingInverseMatrix()
        {
            // À compléter (0.25 pt)
            // Doit retourner une matrice X de même dimension que B avec les valeurs des inconnus 
            IsValid();
            throw new NotImplementedException();
        }

        public Matrix2D SolveUsingGauss()
        {
            // À compléter (1 pts)
            // Doit retourner une matrice X de même dimension que B avec les valeurs des inconnus 
            IsValid();
            throw new NotImplementedException();
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

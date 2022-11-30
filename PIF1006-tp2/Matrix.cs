using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PIF1006_tp2
{
    public class Matrix2D
    {
        public double[,] Matrix { get; private set; }
        public string Name { get; private set; }

        public Matrix2D(string name, int lines, int columns)
        {
            // Doit rester tel quel

            Matrix = new double[lines, columns];
            Name = name;
        }

        public Matrix2D Transpose()
        {
            // À compléter (0.25 pt)
            // Doit retourner une matrice qui est la transposée de celle de l'objet
            Matrix2D retour;
            double[,] tMatrix = new double[Matrix.GetLength(1), Matrix.GetLength(0)];
            for (int i = 0; i != Matrix.GetLength(0); i++)
            {
                for (int j = 0; j != Matrix.GetLength(1); j++)
                {
                    tMatrix[j, i] = Matrix[i, j];
                }
            }
            retour = new Matrix2D(Name + "1", Matrix.GetLength(1), Matrix.GetLength(0));
            retour.SetValue(tMatrix);
            return retour;
        }

        private void SetValue(double[,] tMatrix)
        {
            Matrix = tMatrix;
        }

        public bool IsSquare()
        {
            // À compléter (0.25 pt)
            // Doit retourner vrai si la matrice est une matrice carrée, sinon faux
            int nbCol = 0;
            int nbRow = 0;
            for (int i = 0; i != Matrix.GetLength(0); i++)
            {
                nbRow++;
                for (int j = 0; j != Matrix.GetLength(1); j++)
                {
                    nbCol++;
                }
            }
            if (nbCol % nbRow == 0)
            {
                return true;
            }
            Console.WriteLine("Erreur: Matrice non carrée.");
            Environment.Exit(0);
            return false;
        }

        public double Determinant()
        {
            // À compléter (2 pts)
            // Aura sans doute des méthodes suppl. privée à ajouter,
            // notamment de nature récursive. La matrice doit être carrée de prime à bord.
            throw new NotImplementedException();
        }

        public Matrix2D Comatrix()
        {
            // À compléter (1 pt)
            // Doit retourner une matrice qui est la comatrice de celle de l'objet
            throw new NotImplementedException();
        }

        public Matrix2D Inverse()
        {
            // À compléter (0.25 pt)
            // Doit retourner une matrice qui est l'inverse de celle de l'objet;
            // Si le déterminant est nul ou la matrice non carrée, on retourne null.
            throw new NotImplementedException();
        }

        internal void SetValue(ObservableCollection<string> values)
        {
            int compteur = 0;
            for (int i = 0; i != Matrix.GetLength(0); i++)
            {
                for (int j = 0; j != Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = Convert.ToDouble(values.ElementAt(compteur));
                    compteur++;
                }
            }
        }

        public override string ToString()
        {
            // À compléter (0.25 pt)
            // Doit retourner l'équivalent textuel/visuel d'une matrice.
            // P.ex.:
            // A:
            // | 3 5 7 |
            // | 6 2 5 |
            // | 5 4 5 |
            string temp = "";
            for (int i = 0; i != Matrix.GetLength(0); i++)
            {
                temp += "| ";
                for (int j = 0; j != Matrix.GetLength(1); j++)
                {
                    temp += Matrix[i, j] + " ";
                }
                temp += "|\n";
            }
            return temp;
        }
    }
}

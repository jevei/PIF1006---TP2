using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace PIF1006_tp2
{
    class ListMatrix
    {
        private ObservableCollection<Matrix2D> MatrixList;
        private char Letter;
        private int Barem;

        public ListMatrix()
        {
            MatrixList = new ObservableCollection<Matrix2D>();
            Letter = 'A';
            Barem = 0;
        }

        public void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int nbRow = 0;
            int nbCol = 0;
            ObservableCollection<string> Values = new ObservableCollection<string>();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                if (nbCol == 0)
                {
                    nbCol = EvaluateCol(line);
                    foreach (string element in ExtractorData(line))
                    {
                        Values.Add(element);
                    }
                }
                else if (nbCol == EvaluateCol(line))
                {
                    foreach (string element in ExtractorData(line))
                    {
                        Values.Add(element);
                    }
                }
                else if (nbCol != EvaluateCol(line))
                {
                    MatrixList.Add(new Matrix2D(NameGenerator(), nbRow, nbCol));
                    MatrixList.ElementAt(MatrixList.Count - 1).SetValue(Values);
                    nbCol = 0;
                    nbRow = 0;
                    Values = new ObservableCollection<string>();
                    foreach (string element in ExtractorData(line))
                    {
                        Values.Add(element);
                    }
                }
                nbRow++;
            }
            MatrixList.Add(new Matrix2D(NameGenerator(), nbRow, nbCol));
            MatrixList.ElementAt(MatrixList.Count - 1).SetValue(Values);
        }

        private string NameGenerator()
        {
            char previous = Letter;
            if (previous != 90)
            {
                Letter++;
            }
            else
            {
                Letter = 'A';
                Barem++;
            }
            return BaremLetter() + previous;
        }

        private string BaremLetter()
        {
            string temp = "";
            for(int i=0;i!=Barem;i++)
            {
                temp += Letter;
            }
            return temp;
        }

        private ObservableCollection<string> ExtractorData(string input)
        {
            ObservableCollection<string> temp = new ObservableCollection<string>();
            string value = "";
            for (int i = 0; i <= input.Length; i++)
            {
                if (i != input.Length)
                {
                    value += input[i];
                    if (input[i] == 32)
                    {
                        temp.Add(value);
                        value = "";
                    }
                }
                else
                {
                    temp.Add(value);
                }
            }
            return temp;
        }

        private int EvaluateCol(string input)
        {
            int nbCol = 1;
            for (int i = 0; i != input.Length; i++)
            {
                if (input[i] == 32)
                {
                    nbCol++;
                }
            }
            return nbCol;
        }
    }
}

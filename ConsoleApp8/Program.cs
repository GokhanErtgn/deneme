using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        //static int N = 3;
        static void Main(string[] args)
        {
            BirSayisiMiktar(15);
        }

        private static void BirSayisiMiktar(int v)
        {
            int[,] matris = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            RotateMatrixCounterClockwise(matris);

            Rotate90(matris);



            printMatrix(matris);

            int[] array1 = new int[] { 1, 0, 0, 0, 1, 0, 1 };
            MaksimumUzaklik(array1);
            var a = array1.Max();
            var b = array1.Min();

            var c = array1.Max() - array1.Min();

            int total = 0;

            for (int i = 1; i <= v; i++)
            {
                total += i.ToString().ToCharArray().Where(x => x.Equals('1')).Count();
            }
        }

        private static int MaksimumUzaklik(int[] koltuklar)
        {
            int bestIndex = 0;
            int bestValue = 0, leftValue = 0, rightValue = 0;

            for (int i = 1; i < koltuklar.Length; i++)
            {
                if (koltuklar[i] == 1)
                    continue;

                rightValue = 0;

                for (int j = i + 1; j < koltuklar.Length; j++)
                {
                    if (koltuklar[j] == 1)
                        break;

                    rightValue++;
                }

                leftValue = 0;

                for (int k = i - 1; k>= 0; k--)
                {
                    if (koltuklar[k] == 1)
                        break;

                    leftValue++;
                }

                if (leftValue >= rightValue && leftValue > bestValue && rightValue!=0)
                {
                    bestValue = leftValue;
                    bestIndex = i;
                }

                else if (rightValue >= leftValue && rightValue > bestValue && leftValue != 0)
                {
                    bestValue = rightValue;
                    bestIndex = i;
                }
            }

            return bestIndex;

        }

        static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
        {
            for (int row = 0; row < oldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < oldMatrix.GetLength(1); col++)
                {
                    Console.Write(oldMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            for (int col = oldMatrix.GetLength(1) - 1; col >= 0; col--)
            {
                for (int row = 0; row < oldMatrix.GetLength(1); row++)
                {
                    Console.Write(oldMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    oldMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        static void printMatrix(int[,] matris)
        {
            int N = matris.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(matris[i, j] + " ");
                Console.Write("\n");
            }
        }

        private static void Rotate90(int[,] matris)
        {
            int N = matris.GetLength(0);

            for (int i = 0; i < N / 2; i++)
            {
                for (int j = i; j < N - i - 1; j++)
                {
                    int temp = matris[i, j];
                    matris[i, j] = matris[N - 1 - j, i];
                    matris[N - 1 - j, i] = matris[N - 1 - i, N - 1 - j];
                    matris[N - 1 - i, N - 1 - j] = matris[j, N - 1 - i];
                    matris[j, N - 1 - i] = temp;
                }
            }
        }

        static double DeterminantHesap(int[,] matris)
        {
            int boyut = Convert.ToInt32(Math.Sqrt(matris.Length));
            int isaret = 1;
            double toplam = 0;
            if (boyut == 1)
                return matris[0, 0];
            for (int i = 0; i < boyut; i++)
            {
                int[,] altMatris = new int[boyut - 1, boyut - 1];
                for (int satir = 1; satir < boyut; satir++)
                {
                    for (int sutun = 0; sutun < boyut; sutun++)
                    {
                        if (sutun < i)
                            altMatris[satir - 1, sutun] = matris[satir, sutun];
                        else if (sutun > i)
                            altMatris[satir - 1, sutun - 1] = matris[satir, sutun];
                    }
                }
                if (i % 2 == 0)
                    isaret = 1;
                else
                    isaret = -1;

                toplam += isaret * matris[0, i] * (DeterminantHesap(altMatris));

            }

            return toplam;  
        }
    }
}

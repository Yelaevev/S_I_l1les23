using System;
using System.Collections.Generic;


namespace Level1Space
{
    public static class Level1
    {
        public static bool Compare(int[] A1, int[] A2)
        {
            bool rezult = false;
            if (A1.Length != A2.Length) return false;
            int check = 0;
            for (int i = 0; i < A1.Length; i++)
            {
                if (A1[i] == A2[i]) check++;
            }
            if (check == A1.Length) rezult = true;
            return rezult;
        }

        public static bool Football(int[] F, int N)
        {
            /// Добавляем отсортированный массив для сравнения
            int[] Standart = new int[F.Length];
            F.CopyTo(Standart, 0);
            Array.Sort(Standart);
            ///
             //// перестановка двоих элементов
            List<int> Temp = new List<int>();
            int[] FRemove = new int[F.Length];
            F.CopyTo(FRemove, 0);
            bool Case1 = false;
            for (int i = 0; i < F.Length - 1; i++)
            {

                if (FRemove[i] > FRemove[i + 1])
                {
                    Temp.Add(i);

                }
            }

            if (Temp.Count == 1)
            {
                if (FRemove[Temp[0]] > FRemove[FRemove.Length - 1]) Temp.Add(FRemove.Length - 2);//-2, а не 1, ибо в алгоритме ниже прибавляем 1, 
                                                                                                 // а он более общий
            }

            if (Temp.Count == 2)
            {
                Temp[1]++;
                int temp = FRemove[Temp[0]];
                FRemove[Temp[0]] = FRemove[Temp[1]];
                FRemove[Temp[1]] = temp;
                //Console.WriteLine("случай замены двух не крайних");
                //foreach (int t in FRemove) Console.Write(t + " ");
                //Console.WriteLine();

                //Console.WriteLine(Compare(FRemove, Standart) + "Case1");
                if (Compare(FRemove, Standart)) return true;
                

            }

            ///
            ////  реверс последовательности
            bool Case2 = false;
            int[] FRevers = new int[F.Length];
            F.CopyTo(FRevers, 0);
            if (Temp.Count > 0) Temp.RemoveRange(0, Temp.Count);
            /// случай полного реверса

            Array.Reverse(FRevers);
            if (Compare(FRevers, Standart)) return true;
            else Array.Reverse(FRevers);
          

            /// случай частичного реверса
            int StartBoard = 0;
            int EndBoard = 0;
            for (int i = 0; i < F.Length; i++)
            {
                if (FRevers[i] < FRevers[i + 1])
                {
                    StartBoard = i + 1;
                    break;
                }
            }
            for (int i = 0; i < F.Length - 1; i++)
            {
                //if (FRevers[i] < FRevers[i + 1]) StartBoard = i + 1;
                if (FRevers[i] > FRevers[i + 1])
                {
                    Temp.Add(F[i]);
                    EndBoard = i;
                }
              // if ((FRevers[i] < FRevers[i + 1])&&(EndBoard>StartBoard)) break;
            }
            EndBoard++;
            Temp.Add(F[EndBoard]);
            Temp.Reverse();

           

            if (StartBoard >= EndBoard) StartBoard = 0;
            else
            {
                if ((Temp.Count-1 > (EndBoard - StartBoard)) && (!Case1)) return false;
            }

            Temp.CopyTo(FRevers, StartBoard);

            //foreach (int t in F) Console.Write(t + " ");
            //Console.WriteLine();

            if (Compare(FRevers, Standart)) Case2 = true;
            //Console.WriteLine(Case2+ "Case2");
            //Console.WriteLine(Case1 + "Case1");
            ///
            return Case1 || Case2;
        }

        //static void Main(string[] args)
        //{

        //    //  int[] F = new[] { 5,3,2,1,7 };
        //    int[] F = new[] { 9, 5, 3, 7, 1 };
        //    //int[] F = new[] { 1, 9, 7,6, 5,14};
        //     //int[] F = new[] { 0, 4, 3 ,2,1, 5 };
        //   // int[] F = new[] { 3, 2, 1 };
        //    int[] Standart = new int[F.Length];
        //    F.CopyTo(Standart, 0);
        //    Array.Sort(Standart);
        //    foreach (int t in F) Console.Write(t + " ");
        //    Console.WriteLine();
        //    foreach (int t in Standart) Console.Write(t + " ");
        //    Console.WriteLine();
        //    Console.WriteLine(Football(F,F.Length));


        //}  


    }
}

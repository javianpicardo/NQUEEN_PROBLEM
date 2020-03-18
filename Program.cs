using System;
using System.Runtime.Serialization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Reflection;
/*
Example 1:
Input: [2, 4, 6, 1, 3, 5]
Output Expected: true

Example 2:
Input: [3, 4, 2, 1, 6, 5]
Output Expected: false
*/
namespace NQUEEN_PROBLEM
{
    class Program
    {

        
        public class Position
        {
            public int row, col;
            public Position(int row, int col)
            {
                this.row = row;
                this.col = col;
            }

        }

        public Position[] NQueen(int n)
        {
            Position[] positions = new Position[n];
            bool hasSolution = NQueenUtil(n, 0, 0, positions);
            if (hasSolution)
            {
                return positions;
            }
            else
            {
                return new Position[0];
            }
        }

        public bool NQueenUtil(int n, int row, int col, Position[] positions)
        {
            if (n == row)
            {
                return true;
            }
            //int col;
            for (col = 0; col < n; col++)
            {
                bool foundSafe = true;

                //check if this row and col is not under attack from any previous queen.
                for (int queen = 0; queen < row; queen++)
                {
                    if (positions[queen].col == col ||positions[queen].row - positions[queen].col == row - col ||
                            positions[queen].row + positions[queen].col == row + col)
                    {
                        foundSafe = false;
                        break;
                    }
                }
                if (foundSafe)
                {
                    positions[row] = new Position(row, col);
                    if (NQueenUtil(n, row + 1, col, positions))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
        public static void Main(string[] args)
        {
            //Enter Input Here
            int[] arrInput = new int[] {2, 4, 6, 1, 3, 5};  //<<-Enter Input Here//
            //Main NQueen Logic Called
            Program s = new Program();
            Position[] objpositions = new Position[arrInput.Length];
            objpositions = s.NQueen(arrInput.Length);
            Position[] positions = new Position[arrInput.Length];
            for (int i = 0; i < arrInput.Length; i++)
            {
                positions[i] = new Position(i,Convert.ToInt32(arrInput.GetValue(i)) - 1);
            }
            bool ismatch = true;
            int arrIndex= arrInput.Length-1;
            for(int i=0; i<arrInput.Length;i++)
            {
                    if (objpositions[i].row.ToString() != positions[i].row.ToString() || objpositions[i].col.ToString() != positions[i].col.ToString())
                    {
                        ismatch = false;
                        break;
                    }
            }            
            Console.WriteLine("-------------");
            Console.WriteLine("Output Expected: " +  ismatch);

            Console.WriteLine("Printing NQueenSolution Array Index");
            foreach (Position arr in objpositions)
            {
                Console.WriteLine(arr.row + " " + arr.col);
            }
            Console.WriteLine("-------------");
            
            Console.WriteLine("Printing Input Code  Array Index");
            foreach (Position arri in positions)
            {
                Console.WriteLine(arri.row + " " + arri.col);
            }
            Console.WriteLine("-------------");
            
            Console.ReadKey();










        }



    }


}

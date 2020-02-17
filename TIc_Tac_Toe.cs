using System;

namespace Tic_Tac_Toe
{
    class Program
    {

            /// <summary>
            ///    Matrix Length
            /// </summary>
            static int MATRIX_SIZE = 3;
            //y,x

            /// <summary>
            ///  matrix array [y,x]
            /// </summary>
            /// <value>empty matrix</value>
            static char[,] matrix = new char[3,3] {
                {' ',' ',' '},
                {' ',' ',' '},
                {' ',' ',' '}};
        
        static void Main(string[] args)
        {
            PrintMatrix();
            AddValue('X', 0, 0);
            
        }

        /// <summary>
        ///    Prints the Matrix
        /// </summary>
        static void PrintMatrix() {

            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                string line ="";
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    //INterpolate String
                    // Console.WriteLine($"[y, x] = {y}, {x}");
                    line += matrix[y,x] + "|";
                }
                
                line.Substring(0, line.Length - 1);
                Console.WriteLine(line);
                Console.WriteLine("------");
            }

        }

        /// <summary>
        /// Adds a value to the matrix in the specified position.
        /// </summary>
        /// <param name="value">value to add</param>
        /// <param name="y">y position</param>
        /// <param name="x">x position</param>      
        static void AddValue(char value, int y, int x){
                //Necesitamos y, x
                //Necesitamos el valor a agregar ("X", "0")


        }
    }
}

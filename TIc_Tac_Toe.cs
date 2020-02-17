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
                
                line = line.Substring(0, line.Length - 1);
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

                matrix[y,x] = value;
        }

        static void InputRequest()
        {
                Console.WriteLine("Escribe las coordenadas de la forma y,x en donde quieres hacer movimiento y presiona enter.");
                string userInputCoordinates = Console.ReadLine();

                //Quitar espacios
                userInputCoordinates = userInputCoordinates.Replace(" ", "");

                //Separar en un arreglo de valores diviendo por ","
                string[] coordinates = userInputCoordinates.Split(",");

                //Convertir en coordenadas tipo enter
                int y = Convert.ToInt32(coordinates[0]);
                int x = Convert.ToInt32(coordinates[1]);

                AddValue('X', y, x);

      
      
        static void Main(string[] args)
        {
            InputRequest();
            PrintMatrix();

            // bool gameEnded = false;
            // int turns = 0;

            // while (!gameEnded) {
                
            //     InputRequest();
            //     turns++;
                
            //     //Check if user won
            //     gameEnded = CHeckTHreeLines();


            //     //End after 9 turns
            //     if (turns >= 9) {
            //         gameEnded = true;
            //     }

            //     if (!gameEnded) {

            //         //AIRequest();
            //         turns++;
            //         //Check if AI won
            //         gameEnded = CheckThreeLines();

            //     }




            }
        }



        }
    }
}

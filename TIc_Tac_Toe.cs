using System;

namespace tic_tac_toe

{
    class Program
    {   
        static int MATRIX_SIZE = 3;

        //y, x
        //static char[,] matrix = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};

        /// <summary>
        /// Matrix array [y, x]
        /// </summary>
        /// <value>Empty matrix</value>
        static char[,] matrix = new char[3, 3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}};

        static bool usedArea = false;

        /// <summary>
        /// Prints the matrix.
        /// </summary>

        static void PrintMatrix() 
        {
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                string line = "";
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    //Interpolate string
                    //Console.WriteLine($"[y, x] = {y}, {x}");
                    //Console.Write(matrix[y,x]);
                    line += matrix [y,x] + "|";
                }
                line = line.Substring(0, line.Length - 1);
                Console.WriteLine(line);
                if(y != MATRIX_SIZE -1){
                Console.WriteLine("------");
                }
            }
        }



        //Documentacion de un metodo
        /// <summary>
        /// Adds a value to the matrix in the specified position.
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="y">Y position</param>
        /// <param name="x">X Position</param>

        static void AddValue(char value, int y, int x)
        {
            //Necesitamos y, x
            //Necesitamos el valor agregar ("X", "O")
            //Comparar que si este vacio antes de agregar valor
            if(matrix[y,x] == ' '){

            matrix[y, x] = value;

            } else{
                usedArea = true;
                InputRequest();

            }
            
        }


        /// <summary>
        /// Ask for input values to the user.
        /// </summary>
        static void InputRequest()
        {
            if(usedArea){
                Console.WriteLine("Esas coordenadas ya estan siendo usadas, selecciona otras.");
            }
            Console.WriteLine("Escribe las coordenadas de la forma [y, x] donde quieres hacer tu movimiento");
            Console.WriteLine("Y presiona Enter");
            string userInputCoordinates = Console.ReadLine();
            //Quitar espacios
            userInputCoordinates = userInputCoordinates.Replace(" ", "");
            //Separar en un arreglo de valores con ","
            string[] coordinates = userInputCoordinates.Split(",");
            //Convertir en coordenadas tipo entero
            int y = Convert.ToInt32(coordinates[0]);
            int x = Convert.ToInt32(coordinates[1]);
            AddValue('X', y, x);
        }

        /// <summary>
        /// Review values to see if a line has been completed.
        /// </summary>
        /// <returns></returns>        
        static bool CheckLines()
        {

            //Columns
            //matrix [0, 0]
            //matrix [1, 0]
            //matrix [2, 0]
            char value = ' ';
            bool sameValue = true;
            for (int y = 0; y < 3; y++) {
                value = ' ';
                sameValue = true;
                for (int x = 0; x < 3; x++ )            {
                    if (x == 0)
                    {
                    value = matrix[y,x];
                    }
                    else {
                        sameValue = sameValue && (value == matrix[y,x]);
                   }
                }
                //sameVale determina si son iguales o no
                if (sameValue && value != ' ')
                {
                    return true;
                }
            }

            //Rows
            //matrix [0, 0]
            //matrix [0, 1]
            //matrix [0, 2]
            for (int x = 0; x < 3; x++) {
                value = ' ';
                sameValue = true;
                for (int y = 0; y < 3; y++ )            {
                    if (y == 0)
                    {
                    value = matrix[y,x];
                    }
                    else {
                        sameValue = sameValue && (value == matrix[y,x]);
                   }
                }
                //sameVale determina si son iguales o no
                if (sameValue && value != ' ')
                {
                    return true;
                }
            }


            //Diagonals
            //[0,0] [1,1] [2,2]
            value = ' ';
            sameValue = true;
            for (int i= 0; i < 3; i++){

                if(i == 0) {
                    value = matrix[i,i];
                } else {
                    sameValue = sameValue && (value == matrix[i, i]);
                }

                if (i == 2 && sameValue && value != ' '){
                    return true;
                }
            }

            //Diagonals
            //[0,2] [1,1] [2,0]
             value = ' ';
             sameValue = true;
             for (int y= 0; y < 3; y++){
                 int x = 2 - y;

                if(y == 0) {
                    value = matrix[y,x];
                } else {
                    sameValue = sameValue && (value == matrix[y, x]);
                }

                if (y == 2 && sameValue && value != ' '){
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Check for value to be in Matrix.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        static bool IsValueInMatrix(int y, int x)
        {
            bool isEmpty = matrix[y,x] == ' ';
            return !isEmpty;
        }


        /// <summary>
        /// Generate an ai input into the game.
        /// </summary>
        static void AIRequest()
        {
            Random r = new Random();
            //Numero entre 0 y 2, va a ser un entero
            //El int entre parentesis transforma un coso a otro
            bool validPositionSelected = false;
            int y = 0;
            int x = 0;
            while(!validPositionSelected)
            {
                y = (int)Math.Floor(r.NextDouble() * 3);
                x = Convert.ToInt32(Math.Floor(r.NextDouble() * 3));
                bool isValueDefined = IsValueInMatrix(y,x);
                validPositionSelected = !isValueDefined;    
            }
            AddValue ('O', y, x);

        }


        /// <summary>
        /// Game core.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool gameEnded = false;
            int turns = 0;
            while(!gameEnded)
            {
                InputRequest();
                turns++;
                //Check if user won
                gameEnded = CheckLines();    
                //End after 9 turns
                if (turns >= 9)
                {
                    gameEnded = true;    
                }
                if (!gameEnded) {
                    AIRequest();
                    turns++;
                    //Check if AI won
                    gameEnded = CheckLines();    
                }                 
                PrintMatrix();

            }
            Console.WriteLine("Game over");
            PrintMatrix();
        }
    }
}
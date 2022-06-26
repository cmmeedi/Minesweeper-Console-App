using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MileStone1
{
    public class GameBoard
    {
        //The size property will be placed in both of the Grid arrays to create the Square board size
        public int size = 10;
        //This will determine how many bombs there are which will be explained later
        public double[] difficulty = {.1, .3, .5, .7, .99 };
        //This is a creation of the MultiDimensional Array
        public Cell[,] grid;

        //When creating the gameboard, "size" should be set as the size for the board
        //so when initiated in the Program.cs class an int argument will be required to set the size of the gameboard
        //for now size will be initiated as 10
        public GameBoard(int size = 10)
        {
            //Grid is initiated and uses the variable "size" as its parameters
            grid = new Cell[size, size];

        }

        public void activateBombs()
        {
            //This is a Variable that converts whatever the user input as difficulty is into a number
            int userDifficulty = Convert.ToInt32(Console.ReadLine());
            userDifficulty = userDifficulty - 1;

            //and then a blank line to seperate the difficulty settings from the gameboard
            Console.WriteLine();

            //This is the logic to implement difficulty into the number of bombs on the gameboard

            //The "userDifficulty" reference gets placed into the difficulty array and the difficulty is now set
            double difficultyCheck = difficulty[userDifficulty];

            //Find where the bomb needs to be set live.
            int numOfBombs = (int)(size * size * difficultyCheck);

            //A for loop is created to iterate over the number of bombs there must be within the row
            for (int x = 0; x < numOfBombs; x++)
            {
                //A random reference is initialized
                Random rand = new Random();

                //then a reference to rows and collumns is made
                int bombLocationX = rand.Next(0, size);
                int bombLocationY = rand.Next(0, size);

                //The Random function is a tad to slow so the program gets slowed down just a tad bit with "Thread.Sleep()"
                Thread.Sleep(1);

                //This is an if statement to test whether a cell is a bomb or not.  
                //if it is not and if there are bombs left in "numOfBombs", the "live" bool gets set to true
                if (grid[bombLocationX, bombLocationY].live == false)
                {
                    //Add bomb.. updating the cells in your grid
                    grid[bombLocationX, bombLocationY].live = true;
                }
                else
                {
                    //if there is a bomb there then the programs uses recursion to go back and take another route
                    x--;
                    continue;
                }
            }
        }

        public void calculateLiveNeighbors()
        {
            try
            {
                //Here i begin to iterate through the rows
                for (int i = 0; i <= size - 1; i++)
                {
                    //Then i iterate through the columns
                    for (int j = 0; j <= size - 1; j++)
                    {
                        //Then i test if there is a bomb
                        if (grid[i, j].live == true)
                        {
                            //a place holder is created to test the sorrounding cells rows
                            for (int m = -1; m < 2; m++)
                            {
                                //and collumns
                                for (int n = -1; n < 2; n++)
                                {
                                    //Then according to the current cell being tested, the sorrounding cells are estimated
                                    int x = i + m;
                                    int y = j + n;
                                    //if there is no cell there then the program continues
                                    if (x < 0 || y < 0 || x >= size || y >= size)
                                    {
                                        continue;
                                    }
                                    //if there is a bomb all the sorroounding cells are incremented.  neighbor is incremented
                                    grid[x, y].neighbor++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //this loop prints out the grid after all the logic is implemented
            //but iterating through the first dimension of the array
            for (int i = 0; i < size; i++)
            {
                //Here i create an iterator for the second dimension of the 2D array
                for (int j = 0; j < size; j++)
                {
                    //if the cell is a bomb
                    if (grid[i, j].live == true)
                    {
                        //it gets printed as an "*"
                        Console.Write("*" + " ");
                    }
                    else
                    {
                        //otherwise the number of neighbors is displayed and get's sent to the console
                        Console.Write(grid[i, j].neighbor + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

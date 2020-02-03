//***********************************************************************************
//Program:          Lab4 - Hangman
//Description:      The old hangman game
//Date:             Dec - 2 - 2019
//Author:           Vinh Tran
//Course:           CMPE1300
//Class:            CNTA02
//***********************************************************************************

using System;
using System.IO;
using GDIDrawer;
using DrawHangMan;
using System.Drawing;
using System.Collections.Generic;
using ReadFile;

namespace Lab4_CMPE1300_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                CreatePlayArea();
            } while (Hangman.YesNo("Play again ? (yes/no) ") == "yes");
        }

        private static void CreatePlayArea()
        {
            CDrawer drawer = new CDrawer(600, 600, false);      //create play area 600 *600
            string randString ="";                              //random string get from file 
            WRFile.ReadFromFile(ref randString);                //read from file ( for serect word ) 
            string inputString;                                 //string guess by user                                                               
            int count = 0;                                      //count how many time user guess worng answer
            List<char> inputList = new List<char>();            //list of character input by user
            char[] guessChar = new char[randString.Length];     //string get by user as char array, 
            char input;                                         //each char input by user 
            bool characterDetected = false;                     //bool value o check if the character already input


            //Print Tittle 
            Console.WriteLine("\t\t\tVinh Tran - Lap 4 - CMPE1300 - 2019 - Hangman");
            Console.WriteLine($"serect word hind: {randString}");

            //first set all character in guess array to '-' ( serect word ) 
            for (int i = 0; i < guessChar.Length; i++)
            {
                guessChar[i] = '-';
            }
            inputString = new string(guessChar);

            //do .. while loop to play game until player win or lose      
            do
            {   
                //draw the basic, stage, letter used, and secrect word 
                Hangman.DrawTheStage(drawer);
                Hangman.UsedLetter(drawer, string.Join("", inputList.ToArray()));
                Hangman.InputCharacter(drawer, inputString);
                
                //render it to the screen
                drawer.Render();

                //wait for input from user
                GetGuess(out input);

                //after user input clear the screen, and re-draw
                drawer.Clear();
                
                //check if the "input" char is the same with any chr in the secrect word "randString"
                CheckGuess(input, randString, ref inputList, ref guessChar, ref characterDetected);

                //update input string
                inputString = new string(guessChar);

                //check if the the inputstring = randomstring 
                //if yes draw you win
                if (inputString == randString)
                {
                    Hangman.YouWin(drawer);
                }

                //if not, do the switch case to draw the hang man
                else
                {
                    //if the input character is not in the serect word add 1 to count 
                    if (characterDetected == false)
                    {

                        count++;
                    }

                    //draw the hang man depend on, how many time player have input the worng character
                    switch (count)
                    {
                        case 1:
                            //draw the head
                            Hangman.DrawHead(drawer);
                            break;
                        case 2:
                            //draw the body
                            Hangman.DrawBody(drawer);
                            break;
                        case 3:
                            //draw left hand
                            Hangman.DrawLeftHand(drawer);
                            break;
                        case 4:
                            //draw right hand
                            Hangman.DrawRightHand(drawer);
                            break;
                        case 5:
                            //draw left leg
                            Hangman.DrawLeftLeg(drawer);
                            break;
                        case 6:
                            //The player lost, play all hangman and message 
                            Hangman.DrawRightLeg(drawer);
                            Hangman.YouLose(drawer);
                            Hangman.UsedLetter(drawer, string.Join("", inputList.ToArray()));
                            Hangman.InputCharacter(drawer, randString);
                            break;
                        default:
                            break;
                    }                    
                }
                
                //Render the drawing to screen 
                drawer.Render();

            //break out of do -- while when player have 6 fail or player win 
            } while (randString != inputString && count < 6);
            Console.WriteLine("\nPress anykey to conyinute");
            Console.ReadKey();
            drawer.Close();
        }

        //***********************************************************************************
        //
        //Method:       private static void GetGuess(out char input)
        //Purpose:      check if the input is character not letter 
        //Parameters:   out char input                - the character input by player        
        //Returns:      the correct input from user 
        //
        //***********************************************************************************
        private static void GetGuess(out char input)
        {
            //do while loop to ask player input character, keep running if error detect
            do
            {
                Console.Write("\nPlease enter your guess character :");
                input = Console.ReadKey().KeyChar;

                //check if input is letter 
                if ( char.IsLetter(input) == false)
                {
                    Console.WriteLine("Error input detected, \nPlease input a letter ! :");
                }
            } while (!char.IsLetter(input));
        }

        //***********************************************************************************
        //
        //Method:       private static void CheckGuess(char input, string randString, ref List<char> inputList, ref char[] guesschar, ref bool characterDetected )
        //Purpose:      compare the input char from user with the serect word 
        //Parameters:   char input                  - input character from user
        //              string randString           - random string get from the file 
        //              ref List<char> inputList    - list of character input by user
        //              ref char[] guesschar        - the serect word as char array
        //              ref bool characterDetected  - bool value to check if input character is the already input
        //Returns:      return the list of input character input by user 
        //              return the update of serectword array
        //              return the bool value of checking if character already input
        //
        //***********************************************************************************
        private static void CheckGuess(char input, string randString, ref List<char> inputList, ref char[] guesschar, ref bool characterDetected )
        {
            int indexAt = 0;                                    //index of input char in serect word if any 
            characterDetected = false;

            //check if the input is already in the list 
            if (inputList.Contains(input) == true)
            {
                Console.WriteLine("The Character already input");
                characterDetected = true;
            }
            //if not add it to the list, and check if input = 1 of the character in randString
            else
            {
                inputList.Add(input);

                //check if the input is the same in character in the randString
                foreach (char c in randString)
                {
                    //if there is set get char at that location = input , also update the inputstring
                    if (c == input)
                    {
                        guesschar[indexAt] = c;
                        characterDetected = true;
                    }
                    indexAt++;
                }
            }        
        }
    }
}

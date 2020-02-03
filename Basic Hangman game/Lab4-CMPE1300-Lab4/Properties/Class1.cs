//***********************************************************************************
//Program:          Lab4 - Hangman
//Description:      The old hangman game
//Date:             Dec - 2 - 2019
//Author:           Vinh Tran
//Course:           CMPE1300
//Class:            CNTA02
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.IO;

namespace ReadFile
{
    class WRFile
    {
        //*************************************************************************************
        //
        //Method:       public static void ReadFromFile(out string[] name, out double[] grade)
        //Pupose:       Read student information from file and store it to an Array
        //Parameters:   out string[] name       
        //              
        //Return:       Student name and grade as an Array   
        //
        //*************************************************************************************
        public static void ReadFromFile(ref string data)

        {
            StreamReader readFromFile;                            //intiall read from file           
            List<string> wordList = new List<string>();
            Random rnd = new Random();
                      
            //Try to ask user for file name
            try
            {      
                readFromFile = new StreamReader("words.txt");
                while((data = readFromFile.ReadLine()) != null)
                {
                    wordList.Add(data);
                }

                data = wordList[rnd.Next(0, wordList.Count + 1)];

            }
            catch (Exception e)
            {
                Console.WriteLine("Error was deteted ! ");
                Console.WriteLine($"Detail: {e.Message}");
            }
        }
    }
}

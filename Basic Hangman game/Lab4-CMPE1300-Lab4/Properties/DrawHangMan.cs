//***********************************************************************************
//Program:          Lab4 - Hangman
//Description:      The old hangman game
//Date:             Dec - 2 - 2019
//Author:           Vinh Tran
//Course:           CMPE1300
//Class:            CNTA02
//***********************************************************************************

using System;
using GDIDrawer;
using System.Drawing;


namespace DrawHangMan
{
    class Hangman
    {

        //***********************************************************************************
        //
        //Method:       public static void DrawTheStage(CDrawer drawer)
        //Purpose:      Draw the stage of gameplay area
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawTheStage(CDrawer drawer)
        {
            drawer.AddLine(200, 125, 200, 450, Color.AliceBlue, 3);
            drawer.AddLine(200, 130, 330, 130, Color.AliceBlue, 3);
            drawer.AddLine(200, 140, 210, 130, Color.AliceBlue, 3);
            drawer.AddLine(310, 130, 310, 150, Color.Red, 1);

            drawer.AddLine(200, 400, 350, 400, Color.AliceBlue, 3);
            drawer.AddLine(200, 410, 340, 440, Color.AliceBlue, 3);
            drawer.AddLine(200, 440, 340, 410, Color.AliceBlue, 3);
            drawer.AddLine(340, 400, 340, 450, Color.AliceBlue, 3);
        }

        //***********************************************************************************
        //
        //Method:       public static void DrawHead(CDrawer drawer)
        //Purpose:      Draw head of hangman 
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawHead(CDrawer drawer)
        {
            //draw stage 1st , because screen have been cleared ( from Main )
            DrawTheStage(drawer);
            drawer.AddCenteredEllipse(310, 165, 30, 30, Color.Yellow);
        }

        //***********************************************************************************
        //
        //Method:       public static void DrawBody(CDrawer drawer)
        //Purpose:      Draw body of hangman 
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawBody(CDrawer drawer)
        {
            //Draw stage and head 1st 
            DrawTheStage(drawer);
            DrawHead(drawer);
            drawer.AddCenteredEllipse(310, 220, 30, 80, Color.Yellow);
        }

        //***********************************************************************************
        //
        //Method:       public static void DrawLeftHand(CDrawer drawer)
        //Purpose:      Draw left hand of hangman
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawLeftHand(CDrawer drawer)
        {
            //draw stage, head, and body 1st
            DrawTheStage(drawer);
            DrawHead(drawer);
            DrawBody(drawer);
            drawer.AddLine(310, 180, 255, 215, Color.Yellow, 7);
        }

        //***********************************************************************************
        //
        //Method:       public static void DrawRightHand(CDrawer drawer)
        //Purpose:      Draw body of hangman 
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawRightHand(CDrawer drawer)
        {
            //draw stage, head, body, and left hand 1st
            DrawTheStage(drawer);
            DrawHead(drawer);
            DrawBody(drawer);
            DrawLeftHand(drawer);
            drawer.AddLine(310, 180, 365, 215, Color.Yellow, 7);
        }

        //***********************************************************************************
        //
        //Method:       public static void DrawLeftLeg(CDrawer drawer)
        //Purpose:      Draw left leg of hangman
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawLeftLeg(CDrawer drawer)
        {
            //draw stage, head, body, lef, right hand 1st
            DrawTheStage(drawer);
            DrawHead(drawer);
            DrawBody(drawer);
            DrawLeftHand(drawer);
            DrawRightHand(drawer);
            drawer.AddLine(310, 250, 275, 320, Color.Yellow, 7);
        }

        //***********************************************************************************
        //
        //Method:       public static void DrawRightLeg(CDrawer drawer)
        //Purpose:      Draw right leg of hangman 
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void DrawRightLeg(CDrawer drawer)
        {
            //draw stage, head, body, lef, right hand, and left feet 1st
            DrawTheStage(drawer);
            DrawHead(drawer);
            DrawBody(drawer);
            DrawLeftHand(drawer);
            DrawRightHand(drawer);
            DrawLeftLeg(drawer);
            drawer.AddLine(310, 250, 345, 320, Color.Yellow, 7);
        }

        //***********************************************************************************
        //
        //Method:       public static void YouWin(CDrawer drawer)
        //Purpose:      draw "YOU WIN"
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void YouWin(CDrawer drawer)
        {
            drawer.AddText("YOU WON !", 70, Color.Gray);
        }

        //***********************************************************************************
        //
        //Method:       public static void YouLose(CDrawer drawer)
        //Purpose:      Draw 'YOU LOSE'
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void YouLose(CDrawer drawer)
        {
            drawer.AddText("YOU LOSE !", 70, Color.Gray);
        }

        //***********************************************************************************
        //
        //Method:       public static void UsedLetter(CDrawer drawer, string letterList)
        //Purpose:      Draw history of all character input by user
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //              string letterList       -list of letter have been input by user
        //Returns:      Return nothing
        //
        //***********************************************************************************
        //print all letter use so far 
        public static void UsedLetter(CDrawer drawer, string letterList)
        {
            drawer.AddText("Letter Used: ", 15, 20, 50, 150, 30, Color.White);
            drawer.AddText(letterList, 15, 100, 50, 200, 30, Color.White);
        }

        //***********************************************************************************
        //
        //Method:       public static void InputCharacter( CDrawer drawer, string inputString)
        //Purpose:      Draw the serectword in the bottom 
        //Parameters:   CDrawer drawer          -GDI darwer from main 
        //              string inputstring      -The character in the serect word that have been enter by user
        //Returns:      Return nothing
        //
        //***********************************************************************************
        public static void InputCharacter( CDrawer drawer, string inputString)
        {
            drawer.AddText(inputString, 35, 200, 500, 200, 40, Color.Red);
        }

        //********************************************************************************************
        //Method: private static string YesNo(string message)
        //Purpose: check for user want to continute or not
        //Parameters: string message - the message to ask user 
        //Returns: string - yes or no 
        //*********************************************************************************************
        public static string YesNo(string message)
        {
            string decision;                // decision input by user

            //do .. while loop check for the input decision from user
            do
            {
                Console.WriteLine();
                Console.Write(message);
                decision = Console.ReadLine();
                decision = decision.ToLower();

                //check for the in put message is right format
                if (decision != "yes" && decision != "no")
                {
                    Console.WriteLine("You must enter yes or no ");
                }

                //check if decision is no
                if (decision == "no")
                {
                    Console.WriteLine("Bye!");
                    Console.ReadKey();
                }


            } while (decision != "yes" && decision != "no");

            return decision;
        }
    }
}

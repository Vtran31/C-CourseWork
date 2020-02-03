using System;
using System.Drawing;
using GDIDrawer;
using QEquation;
using Utilities;

namespace CMPE1300Lab3_2019
{
    class Program
    {
        public static Point a = new Point();                                        //use to connect the dot on drawer
        public static Point b = new Point();                                        //use to connect the dot on drawer
        public static int connectOrNot = 0;                                         //determine if we want to connect the 2 point 
        public static int scale = 1;                                                //set scale of drawer and use that for zoom in and out 
        static void Main()
        {
            InputEquationNumber();
        }

        //***********************************************************************************
        //Method:       private static string YesNo(string message)
        //Purpose:      check for user want to continute or not
        //Parameters:   string message      - the message to ask user 
        //Returns:      string              - yes or no 
        //
        //***********************************************************************************
        static void InputEquationNumber()
        {
            int size = 0;                                             //set size of the draw area
            CDrawer drawing;
            do
            {

                QuadraticEquation equation = new QuadraticEquation();

                Console.WriteLine("\t\t\tVinh Tran Lab 3 C# Year 1 - try 2018");

                //Get a, b, and c
                GetCoefficients(equation);

                //get upper and Lower
                // GetUpper(equation);
                GetRange(equation);

                //graph equation 
                drawing = new CDrawer(CMPE1300Lab3_2019.Properties.Resources.fixbackground2);
                size = drawing.m_ciHeight;
                DrawGraph(equation, drawing);

                //zoom in or out 
                Zoom(equation, drawing);

            } while (YesNo("Play again ? (yes/no) ", drawing) == "yes");

        }

        //***********************************************************************************
        //Method:       private static void GetCoefficients(QuadraticEquation equation)
        //Purpose:      get the cosfficient a, b, c and set it to equation
        //Parameters:   QuadraticEquation equation      - contain the quadratic equation 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        private static void GetCoefficients(QuadraticEquation equation)
        {
            double a;                       //the coefficient a
            double b;                       //the coefficient b
            double c;                       //the coefficient c
            

            //get the value for a, b, and c
            CUtility.GetValue(out a, "PLease enter the value for a: ");
            CUtility.GetValue(out b, "Please enter the value for b: ");
            CUtility.GetValue(out c, "Please enter the value for c: ");

            //set a, b, c to equation 
            equation.A = a;
            equation.B = b;
            equation.C = c;
        }

        //***********************************************************************************
        //
        //Method:       private static void GetRange(QuadraticEquation equation)
        //Purpose:      will input using GetValue() the lower and upper range values for x
        //Parameters:   QuadraticEquation equation      - contain the quadratic equation 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        private static void GetRange(QuadraticEquation equation)
        {
            double lower = 1;                           //lower limit
            double upper = 0;                           //upper limit

            //while input lower and upper limmit, and check for that 
            while( upper < lower)
            {
                CUtility.GetValue(out lower, "Enter lower limit: ");
                CUtility.GetValue(out upper, "ENter upper limit: ");

                //if statement check if lower > upper limit
                if (lower > upper)
                {
                    Console.WriteLine("Lower limit should be bigger than upper limit");
                    Console.WriteLine("Please try again! ");
                }
            }

            equation.Lower = lower;
            equation.Upper = upper;
        }


        //***********************************************************************************
        //
        //Method:       private static double Quadratic(QuadraticEquation equation, double x)
        //Purpose:      It will return (using the return value) a double that represents the value of f(x). 
        //Parameters:   QuadraticEquation equation      - contain the quadratic equation 
        //              double x                        - the current value of x 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        private static double Quadratic(QuadraticEquation equation, double x)
        {
            return (equation.A * Math.Pow(x, 2) + equation.B * x + equation.C);
        }

        //***********************************************************************************
        //Method:       private static void DrawGraph(QuadraticEquation equation)
        //Purpose:      This method will use a loop to calculate the values for f(x) for
        //              x is between the lower value and the upper value,
        //              in increments of 0.02 for x.
        //Parameters:   QuadraticEquation equation      - contain the quadratic equation element
        //                                                a. b. c, range for x 
        //Returns:      Return nothing
        //
        //***********************************************************************************
        private static void DrawGraph(QuadraticEquation equation, CDrawer drawing)
        {
            
            double x = 0;                                               //the x component of equation
            double y = 0;                                               //the y component of equation
            int k = 0;                                                  // k is position of x on drawer
            int j = 0;                                                  // j is position of y on drawer
            int size =  drawing.m_ciHeight; ;                           //set size of the draw area
            a = new Point();                                            //reset point a
            b = new Point();                                            //reset point b
            connectOrNot = 0;                                           //reset connect or not
            
            Console.WriteLine("\nNow Drawing equation : f(x) = {0}x^2 + {1}x + {2}", equation.A, equation.B, equation.C);

            //draw x axis in the middle of drawer, horizontally
            drawing.AddLine(0, size / 2, size, size / 2, Color.White, 1);

            //add the small line on the x axis, and the number of coordinate
            for (int i = 0; i < size / 50; i++)
            {
                //add the small line
                //take 50 pixel for 1 unit , x start at 50i (start at 0), y start at (middle - 5pixel * scale) 
                //x end at 50i ( start at 0), y end at (middle - 5pixel*scale);
                drawing.AddLine(50 * i, size / 2 - 5 * scale, 50 * i, size / 2 + 5 * scale, Color.White, 1);

                //add the number coordinate
                //because the middle is 0, ->> size/2 is middle then divide by another 50 for 1 unit of measure
                //->> i - size/100 ->> give me the lowest unit ->> change thhat to string and add to equation
                drawing.AddText(((i - size / 100) * scale).ToString(), 12,
                                  50 * i - 20, size / 2 + 10 * scale,
                                  50, 15, Color.Yellow);
            }

            //draw y axis in the middle vertically
            drawing.AddLine(size / 2, 0, size / 2, size, Color.White, 1);

            // "size/50" is 1 unit of messurement
            for (int i = 0; i < size / 50; i++)
            {
                drawing.AddLine(size / 2 - 5 * scale, 50 * i, size / 2 + 5 * scale, 50 * i, Color.White, 1);


                drawing.AddText(((size / 100 - i) * scale).ToString(), 12,
                                  size / 2 - 10, 50 * i + 10,
                                  50, 15, Color.Yellow);
            }

            //drawing equation 
            //size/2 is where x0, y0 
            //Quataric equation method will return answer as double 
            //for loop start at i = 0 at lower, and the range is upper - lower
            x = equation.Lower;
            for (int i = 0; i < (int)(equation.Upper - equation.Lower) / .02; i++)
            {
                //only draw point if it inside the windows
                //at i = 0 >> lower than compare to check where than range.
                //x point on x axis, i is relative to x on CDDrawer


                //  k = size/ 2 + x/.02 ,, x/.02 -> is 1 pixcel,and size /2 is the middle of drawer
                //0.2*scale -> using when changing the scale 1->50, 2->100, 3->150,...
                //-> k = the (0 ,0) + the x coordinate as pixel "k"
                //where k is x on drawer
                k = (int)(size / 2 + x / (.02 * scale));

                //y is point on y, j is ralative to y on CDDrawer
                //1st is calculate y using quadratic equation 
                //than change y to j as 1y = 50j*scaling ( normal is 1)
                //j = middle - y/.02 because in drawer y the lowest y have biggest pixel coodinate
                y = Quadratic(equation, x);
                j = (int)(size / 2 - y / (.02 * scale));

                //Console.WriteLine($"x : {x:F2} ,k : {k}, y: {y}, j:  {j}");
                //check if k , j is int range 
                if (k > 0 && j > 0 && k < size && j < size)
                {
                  //  drawing.SetBBPixel(k, j, Color.Yellow);
                    ConnectTheDot(k, j, drawing);
                }

                //increasing x by .02 ( 1 pixel ) 
                x += .02;
            }
        }

        //connect the dot
        static void ConnectTheDot(int k, int j, CDrawer drawing)
        {
            //add the 1st point to equation
            if (connectOrNot == 0)
            {
                a.X = k;
                a.Y = j;
            }
            //add the second point to equation
            //and connect the 1st line, a->b
            else if (connectOrNot == 1)
            {
                b.X = k;
                b.Y = j;
                drawing.AddLine(a.X, a.Y, b.X, b.Y, Color.White, 1);
            }
            //if connectOrNot divisible by 2, then add to a
            //then connect b to a
            else if (connectOrNot % 2 == 0)
            {
                a.X = k;
                a.Y = j;
                drawing.AddLine(b.X, b.Y, a.X, a.Y, Color.White, 1);
            }
            //if connectOrNOt not divisible by 2, add to b and connect a and b
            else if (connectOrNot % 2 == 1)
            {
                b.X = k;
                b.Y = j;
                drawing.AddLine(a.X, a.Y, b.X, b.Y, Color.White, 1);
            }

            connectOrNot++;
        }

        //********************************************************************************************
        //Method:       private static string YesNo(string message)
        //Purpose:      check for user want to continute or not
        //Parameters:   string message      - the message to ask user 
        //Returns:      string              - yes or no 
        //*********************************************************************************************
        private static string YesNo(string message, CDrawer drawer)
        {
            string decision;                // decision input by user

            //do .. while loop check for the input decision from user
            do
            {
                Console.WriteLine(message);
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

                //if yes close the current windows and clear console
                if ( decision == "yes")
                {
                    drawer.Close();
                    Console.Clear();
                }
            } while (decision != "yes" && decision != "no");

            return decision;
        }


        //********************************************************************************************
        //Method: private static string YesNo(string message)
        //Purpose: check for user want to continute or not
        //Parameters: string message - the message to ask user 
        //Returns: string - yes or no 
        //*********************************************************************************************
        private static void Zoom( QuadraticEquation equation, CDrawer drawing)
        {
            char decision;                             //decision input from user
          
                do
                {
                    Console.WriteLine("\n\t\t\t Option ");
                    Console.WriteLine("Press \" + \" to zoom in");
                    Console.WriteLine("Press \" - \" to zoom out");
                    Console.WriteLine("Press \" * \" to add another equation on top ");
                    Console.WriteLine("Press any other key to exit");
                    Console.WriteLine("Sorry the zoom in and out only wirk with the latest input equation ");

                    decision = Console.ReadKey().KeyChar;

                    if (decision == '+')
                    {
                        Console.WriteLine("\nBegin to Zoon out !\n");
                        scale++;
                        drawing.Clear();
                        DrawGraph(equation, drawing);
                    }
                    else if (decision == '-')
                    {
                        if ( scale > 1)
                        {
                            Console.WriteLine("\nBegin to Zoon in !\n");
                            scale--;
                            drawing.Clear();
                            DrawGraph(equation, drawing);
                        }
                        else
                        {
                            Console.WriteLine("\nCan not zoom in any more ! \n");
                        }
                    }
                    else if (decision == '*')
                    {
                        //Get a, b, and c
                        GetCoefficients(equation);

                        //get upper and Lower
                        GetRange(equation);

                        //draw graph
                        DrawGraph(equation, drawing);

                    }
                    
                } while (decision == '+' || decision == '-' || decision == '*');
          
        }
    }
}

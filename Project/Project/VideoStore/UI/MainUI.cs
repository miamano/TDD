using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Interfaces;
using VideoStore.BL;

namespace VideoStore.UI
{
    public class MainUI
    {
        private IVideoStore vs;

        public MainUI(IVideoStore vs)
        {
            this.vs = vs;

            bool isContinue = true;
            while (isContinue)
            {
                DrawMenu();

                bool isValidChoice = false;
                int choice = 0;
                while (!isValidChoice)
                {
                    Console.Write("Select an option: ");
                    isValidChoice = int.TryParse(Console.ReadLine(), out choice);
                    isValidChoice = (isValidChoice && choice > 0 && choice < 6);

                    if (!isValidChoice)
                        Console.WriteLine("Not a valid option.");
                }

                HandleMenuChoice(choice);

                bool isValidChar = false;
                while (!isValidChar)
                {
                    string text = "Continue y/n? ";
                    Console.WriteLine();
                    UIHelper.DrawLine(text.Length);
                    Console.Write(text);
                    string cont = Console.ReadLine();
                    isValidChar = (cont.ToUpper() == "N" || cont.ToUpper() == "Y") ? true : false;
                    isContinue = (isValidChar && cont.ToUpper() == "Y") ? true : false;
                }
            }
        }

        private void HandleMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    new NewCustomerUI(vs);
                    break;

                case 2:
                    new NewMovieUI(vs);
                    break;

                case 3:
                    new RentMovieUI(vs);
                    break;

                case 4:
                    new ReturnMovieUI(vs);
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private void DrawMenu()
        {
            Console.Clear();
            UIHelper.DrawLine(22);
            Console.WriteLine("      VIDEOSTORE");
            UIHelper.DrawLine(22);
            Console.WriteLine("(1) Register customers");
            Console.WriteLine("(2) Add new movies to the stock");
            Console.WriteLine("(3) Rent movies to customers");
            Console.WriteLine("(4) Receives rented movies from customers");
            Console.WriteLine("(5) Exit");
            UIHelper.DrawLine(22);
        }
    }
}

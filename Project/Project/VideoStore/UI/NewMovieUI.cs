using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Exceptions;
using VideoStore.Interfaces;
using VideoStore.Model;

namespace VideoStore.UI
{
    public class NewMovieUI
    {
        public NewMovieUI(IVideoStore vs)
        {
            UIHelper.DrawTitle("   ADD A NEW MOVIE   ");

            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            int year = InputYear("Year (1900-2017): ");

            try
            {   
                //TODO: without Movie instance less dependency.. send in three attributes instead
                vs.AddMovie(new Movie(title, genre, year));
                UIHelper.DrawLine(20);
                Console.WriteLine("");
                Console.WriteLine($"Confirmation: {title}, {genre}, {year} are registrated.");
            }
            catch (TooManyCopiesOfSameMovieException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotValidYearException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private int InputYear(String text)
        {
            int number = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write(text);
                isValid = int.TryParse(Console.ReadLine(), out number);
                isValid = (isValid && number > 1900 && number < 2017) ? true : false;

                if (!isValid)
                    Console.WriteLine("Not a valid YEAR.");
            }
            return number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Exceptions;
using VideoStore.Interfaces;

namespace VideoStore.UI
{
    public class ReturnMovieUI
    {
        public ReturnMovieUI(IVideoStore vs)
        {
            UIHelper.DrawTitle("   RETURN A MOVIE   ");

            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("ID number (YYYY-MM-DD): ");
            string id = Console.ReadLine();

            try
            {
                vs.ReturnMovie(title, id);
                UIHelper.DrawLine(20);
                Console.WriteLine("");
                Console.WriteLine("Confirmation: Return is registrated.");
            }
            catch (TooManyCopiesOfSameMovieException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EmptyCustomerIDException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (BadFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotRegistratedRentalException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotRegistratedCustomerException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

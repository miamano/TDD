using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Exceptions;
using VideoStore.Interfaces;

namespace VideoStore.UI
{
    public class NewCustomerUI
    {
        public NewCustomerUI(IVideoStore vs)
        {
            UIHelper.DrawTitle("   ADD A NEW CUSTOMER   ");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("ID number (YYYY-MM-DD): ");
            string id = Console.ReadLine();

            try
            {
                vs.RegisterCustomer(name, id);
                UIHelper.DrawLine(20);
                Console.WriteLine("");
                Console.WriteLine($"Confirmation: {name} is registrated.");
            }
            catch (RegistratedCustomerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (BadFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EmptyCustomerNameException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EmptyCustomerIDException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

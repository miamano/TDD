using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Model;

namespace VideoStore.Interfaces
{
    public interface IVideoStore 
    {
        void RegisterCustomer(string name, string idNumber);
        void AddMovie(Movie movie);
        void RentMovie(string movieTitle, string idNumber);
        List<Customer> GetCustomer();
        void ReturnMovie(string movieTitle, string idNumber);
        Movie GetMovie(string title);   //Extra
    }
}

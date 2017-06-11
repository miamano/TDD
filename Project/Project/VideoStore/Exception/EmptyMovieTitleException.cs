using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Exceptions
{
    public class TooManyCopiesOfSameMovieException : Exception
    {
        public TooManyCopiesOfSameMovieException(string message) : base(message)
        { }
    }

    public class EmptyCustomerNameException : Exception
    {
        public EmptyCustomerNameException(string message) : base(message)
        { }
    }

    public class EmptyCustomerIDException : Exception
    {
        public EmptyCustomerIDException(string message) : base(message)
        { }
    }

    public class RegistratedCustomerException : Exception
    {
        public RegistratedCustomerException(string message) : base(message)
        { }
    }

    public class BadFormatException : Exception
    {
        public BadFormatException(string message) : base(message)
        { }
    }

    public class NotRegistratedCustomerException : Exception
    {
        public NotRegistratedCustomerException(string message) : base(message)
        { }
    }

    public class NotRegistratedMovieException : Exception
    {
        public NotRegistratedMovieException(string message) : base(message)
        { }
    }

    public class NotRegistratedRentalException : Exception
    {
        public NotRegistratedRentalException(string message) : base(message)
        { }
    }

    public class NotValidYearException : Exception
    {
        public NotValidYearException(string message) : base(message)
        { }
    }

    public class NoMoreCopiesInStoreException : Exception
    {
        public NoMoreCopiesInStoreException(string message) : base(message)
        { }
    }

    public class NoMoreCopiesToRentException : Exception
    {
        public NoMoreCopiesToRentException(string message) : base(message)
        { }
    }

    public class EmptyMovieTitleException : Exception
    {
        public EmptyMovieTitleException(string message) : base(message)
        { }
    }

    public class NotAllowedToRentException : Exception
    {
        public NotAllowedToRentException(string message) : base(message)
        { }
    }
}

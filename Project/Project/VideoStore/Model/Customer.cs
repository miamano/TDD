using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Exceptions;

namespace VideoStore.Model
{
    public class Customer
    {
        private string name;
        private string idNumber;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new EmptyCustomerNameException("Missing name.");

                this.name = value;
            }
        }

        public string IdNumber
        {
            get
            {
                return this.idNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new EmptyCustomerIDException("Missing id.");

                this.idNumber = value;
            }
        }

        public Customer(string name, string id)
        {
            Name = name;
            IdNumber = id;
        }

        //TODO: CompareTo or operator overloading
    }
}

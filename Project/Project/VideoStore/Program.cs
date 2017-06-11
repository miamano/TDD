using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.UI;
using VideoStore.BL;

namespace VideoStore
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoStoreClass vs = new VideoStoreClass(new Rentals());
            new MainUI(vs);
        }
    }
}

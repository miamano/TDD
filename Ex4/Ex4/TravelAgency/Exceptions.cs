﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourAllocationException : Exception
    {
        public TourAllocationException()
        {
        }
    }

    public class NotExistingTourException : Exception
    {
        public NotExistingTourException()
        {
        }
    }

    public class FullbokedTourException : Exception
    {
        public FullbokedTourException()
        {
        }
    }
}

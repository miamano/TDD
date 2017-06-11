using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Exceptions;

namespace VideoStore.Model
{
    public class Movie
    {
        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new TooManyCopiesOfSameMovieException("Missing title.");

                this.title = value;
            }
        }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Movie(string title, string genre, int year)
        {
            this.title = title;
            this.Genre = genre;
            this.Year = year;
        }
    }
}

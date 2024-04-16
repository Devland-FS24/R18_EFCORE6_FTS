using System;
using System.Collections.Generic;

namespace ReactNC6FTS_Full.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieCasts = new HashSet<MovieCast>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ReactNC6FTS_Full.Models
{
    public partial class Cast
    {
        public Cast()
        {
            MovieCasts = new HashSet<MovieCast>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? KnownBy { get; set; }
        public string? LatestAppearance { get; set; }
        public double? Imdbrate { get; set; }
        public string? ManagerContact { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}

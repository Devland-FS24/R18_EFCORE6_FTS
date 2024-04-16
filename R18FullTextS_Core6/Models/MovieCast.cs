using System;
using System.Collections.Generic;

namespace ReactNC6FTS_Full.Models
{
    public partial class MovieCast
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? CastId { get; set; }

        public virtual Cast? Cast { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}

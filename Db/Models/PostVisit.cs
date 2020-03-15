using System;
using System.ComponentModel.DataAnnotations;

namespace Db.Models
{
    public class PostVisit
    {
        public int Id { get; set; }

        [Required]
        public DateTime Registered { get; set; }

        public int Points { get; set; }


        public int PersonId { get; set; }
        public Person Person { get; set; }


        public int PostId { get; set; }
        public Post Poster { get; set; }

    }
}

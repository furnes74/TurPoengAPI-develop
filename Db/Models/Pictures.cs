using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Models
{
    public class Pictures
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        
        [MaxLength(400)]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public bool PrivatePicture { get; set; }

        public DateTime Created { get; set; }
        
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int PostId { get; set; }
        public Post Poster { get; set; }

    }
}

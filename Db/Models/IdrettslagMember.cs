namespace Db.Models
{
    public class IdrettslagMember
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int IdrettslagId { get; set; }
        public Idrettslag Idrettslag { get; set; }
    }
}

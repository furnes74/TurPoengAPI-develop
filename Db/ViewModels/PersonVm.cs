namespace Db.ViewModels
{
    public class PersonVm
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public byte[] Picture { get; set; }

        // public int ChoosenIdrettslag { get; set; }

        public IdrettslagVm[] Idrettslag { get; set; }

    }
}

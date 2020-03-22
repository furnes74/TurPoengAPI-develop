namespace Db.ViewModels
{
    public class PostVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CallingName { get; set; }

        public int PostHeight { get; set; }

        public int PostStartHeight { get; set; }

        public int PostWalkDistance { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int DefaultPoints { get; set; }
    }
}

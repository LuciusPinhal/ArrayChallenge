namespace APISquare.Models
{
    public class SquareContent
    {

        public SquareContent()
        {
            this.dateCreated = DateTime.Now;
            this.color = "0000";
            this.width = 0;
            this.height = 0;

        }
        public SquareContent(string Color, int Width, int Height)
        {
            this.dateCreated = DateTime.Now;
            this.color = Color;
            this.width = Width;
            this.height = Height;
        }

        public int id { get; set; }
        public string? color { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public DateTime dateCreated { get; set; }
     
    }
}

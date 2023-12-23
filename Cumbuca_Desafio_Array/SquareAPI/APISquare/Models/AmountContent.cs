namespace APISquare.Models
{
    public class AmountContent
    {
        public AmountContent()
        {
            this.quantidade = 0;
            this.squares = new List<SquareContent>();
            this.name = "";
        }
        public AmountContent(int Quantidade, string name)
        {
            this.quantidade = Quantidade;
            this.squares = new List<SquareContent>();
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int? quantidade { get; set; }
        public List<SquareContent> squares { get; set; }

    }
    
}

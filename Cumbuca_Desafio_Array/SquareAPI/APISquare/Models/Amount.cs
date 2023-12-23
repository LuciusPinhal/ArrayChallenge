using System.Collections.Generic;



namespace APISquare.Models
{
    public class Amount
    {
        public Amount()
        {
            this.quantidade = 0;
            this.squares = new List<Square>();
            this.name = "";
        }
        public Amount(int Quantidade, string name)
        {
            this.quantidade = Quantidade;
            this.squares = new List<Square>();
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int? quantidade { get; set; }
        public List<Square> squares { get; set; }
   
    }
}


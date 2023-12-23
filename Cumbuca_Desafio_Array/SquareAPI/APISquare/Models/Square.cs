
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APISquare.Models;

public class Square
{

    public Square()
    {
        this.dateCreated = DateTime.Now;
        this.color = "0000";
        this.width = 0;
        this.height = 0;
         
    }
    public Square(string Color, int Width, int Height)
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
    public int amountId { get; set; }

    //toda vez que for fazer relacionamento de um para muitos, N p/ N
    //alem de eu referencia o Id eu tenho que carregar o obj do Id
    //anotações por dados - ele qr que ele ignora o json e nao seja mapeado

    [JsonIgnore]
    [NotMapped]
    public Amount Amount { get; set; }
    


   
}

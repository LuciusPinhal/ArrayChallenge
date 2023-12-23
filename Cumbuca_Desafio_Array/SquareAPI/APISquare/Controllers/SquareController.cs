using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using APISquare.Persistence;
using APISquare.Models;
using System.Net;
using System.Xml.Linq;
using System.Drawing;

namespace APISquare.Controllers;

[ApiController]
[Route("[controller]")]
public class SquareController : Controller
{
   private SquareContext _context { get; set; }

    public SquareController(SquareContext context)
    {
        _context = context;
    }

    [HttpGet("ReciveSquares")]

    public ActionResult<List<Amount>> Get()
    {
        var result = _context.Amounts.Include(s => s.squares).ToList();
      
        
        if (!result.Any())
        {
            return NoContent();
        }
        return Ok(result);
    }


    // Quero que insira no banco o mount
    // A Fyncção perngunta o que ele quer salvar e o tipo
    // E tmb o retorno
    [HttpPost("addSquares")]
    // parametro: referencia o que eu quero salvar 
    public ActionResult<Amount> SalvandoAmount([FromBody]AmountContent amount)
    //visibilidade tipoREtorno nomeFunção (parametros(tipo / do / nome)) ==> assinatura
    {
        try
        {
            int maxID = _context.Amounts.ToList().Count();
            // Instanciação de Objeto
            //Definri:
            //TIpo do obj | nome do objeto| instancia | tipo (parametros?)
            // Isso em baixo nao tem nada a ver com o retorno
            Amount amountDB = new Amount((int)amount.quantidade, amount.name);
            amountDB.id = maxID++;
            _context.Amounts.Add(amountDB);
            _context.SaveChanges();
            // [.] ==> acessar uma propRIEDADE DEU UM OBJ;
            // amount.content => Lista de SquareConte != Square
            // Cada item é um SquareContent
            
            foreach (var item in amount.squares)
            {
                Square square = new Square(item.color, item.width, item.height);
                square.amountId = amountDB.id;
                square.dateCreated = item.dateCreated;

                _context.Squares.Add(square);
                _context.SaveChanges();
                  
            }

            amount.id = amountDB.id;

        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                msg = "Erro " + ex,
                status = HttpStatusCode.BadRequest
            });
        }

        return Created("Criado", amount);
    }

    [HttpPut("AlterSquares")]
    public ActionResult<Object> Update([FromRoute] int id, Amount amount)
    {

        var result = _context.Amounts.SingleOrDefault(p => p.id == id);

        if (result is null)
        {
            return NotFound(new
            {
                msg = "Id " + id + " nao encontrado, verifique o id",
                status = HttpStatusCode.NotFound
            });
        }

        try
        {
            _context.Amounts.Update(amount);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "Erro ao Atualizar o ID " + id + " Verifique se o id esta correto",
                status = HttpStatusCode.BadRequest
            });
        }

        return Ok(new
        {
            msg = "Dados do id " + id + " atualizados",
            status = HttpStatusCode.OK
        });
    }

    [HttpGet("DeleteSquares/{id}")]
    public ActionResult<Object> Delete(int id)
    {
        var result = _context.Amounts.SingleOrDefault(p => p.id == id);

        if (result is null)
        {
            //return BadRequest("Id " + id + " Inexistente");
            return BadRequest(new
            {
                msg = "Id " + id + " Inexistente",
                status = HttpStatusCode.BadRequest,
            });
        }
        _context.Amounts.Remove(result);
        _context.SaveChanges();

       
        return Ok(new
        {
            msg = "Deletado Id =" + id,
            status = HttpStatusCode.OK
        });
    }
}

using ControleProdutos.Data;
using ControleProdutos.Generic;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        public static List<Venda> listaVendas = new List<Venda>();
        //Variavel controladora da execução da conexao com BD
        private readonly ControleProdutosContext _context;

        public VendaController(ControleProdutosContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<Venda> GetIdVenda(int id)
        {
            var vendasOld = new Venda();
            try
            {
                var lista = await _context.tbvenda.ToListAsync();
                vendasOld = lista.Where(e => e.id == id).First();
            } catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message }");
            }
            return vendasOld;
        }

        [HttpGet("maiorID")]
        public async Task<int> GetMaxVenda()
        {
            var lista = new List<Venda>();
            int maiorID = 0;
            try
            {
                lista = await _context.tbvenda.ToListAsync();
                if (lista.Count > 0)
                {
                    maiorID = _context.tbproduto.Max(e => e.id);
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro("Erro ao buscar venda", ex.InnerException.ToString(), "GetVenda");
            }
            return maiorID;
        }

        [HttpGet]
        public List<Venda> GetVenda()
        {
            return _context.tbvenda.ToList();
        }
        
        [HttpPost]
        public async Task<string> PostVenda(Venda newVenda)
        {
            string res = "Erro ao incluir venda";
            try
            {
                await _context.tbvenda.AddAsync(newVenda);
                var valor = await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Venda cadastrado!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PostVenda");
            }

            return res;
        }

        [HttpPut]
        public async Task<string> PutVenda(Venda newVenda)
        {
            string res = "Erro ao alterar cadastro do venda!";
            try
            {
                _context.tbvenda.Update(newVenda);
                var valor = await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Cadastro venda alterado!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PutVenda");
            }

            return res;
        }

        [HttpDelete("Delete/{id}")]
        public string DeleteVenda(int id)
        {
            string res = "Venda não excluído!";
            try
            {
                // zero produto ainda não foi excluido
                var valor = 0;
                var venda = _context.tbvenda.Find(id);
                if (venda != null)
                {
                    _context.tbvenda.Remove(venda);
                    valor = _context.SaveChanges();
                }

                if (valor == 1)
                {
                    res = "Venda excluído";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "DeleteVenda");
            }

            return res;
        }

    }
}

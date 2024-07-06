using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleProdutos.Generic;
using System.Data;

namespace ControleProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
 
    public class ProdutoController : ControllerBase
    {
        private readonly ControleProdutosContext _context;
       
        public ProdutoController(ControleProdutosContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<Produto> GetIdProduto(int id)
        {
            var produtoOld = new Produto();
            try
            {
                var lista = await _context.tbproduto.ToListAsync();
                produtoOld = lista.Where(e => e.id == id).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return produtoOld;
        }

        [HttpGet("maiorID")]
        public async Task<int> GetMaxProdutos()
        {
            var lista = new List<Produto>();
            int maiorID = 0;
            try
            {
                lista = await _context.tbproduto.ToListAsync();
                if (lista.Count > 0)
                {
                    maiorID = _context.tbproduto.Max(e => e.id);
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro("Erro ao buscar produtos", ex.InnerException.ToString(), "GetProdutos");
            }
            return maiorID;
        }

        [HttpGet]
        public async Task<List<Produto>> GetProdutos()
        {
            var lista = new List<Produto>();
            try
            {
                lista = await _context.tbproduto.ToListAsync();
            }catch (Exception ex)
            {
                new Log().GravarErro("Erro ao buscar produtos", ex.InnerException.ToString(), "GetProdutos");
            }

            return lista;
        }


        [HttpPost]
        public async Task<string> PostProduto(Produto newProduto)
        {
            string res = "Erro ao incluir produto";
            try
            {
                await _context.tbproduto.AddAsync(newProduto);
                var valor = await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Produto incluido!";
                }
            }
            catch(Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PostProduto");
            }

            return res;
        }


        [HttpPut]
        public async Task<string> PutProduto(Produto newProduto)
        {
            string res = "Erro ao alterar produto não alterado!";
            try
            {
                _context.tbproduto.Update(newProduto);
                var valor = await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Produto alterado!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PutProduto");
            }

            return res;
        }


        [HttpDelete("Delete/{id}")]
        public string DeleteProduto(int id)
        {
            string res = "Produto não excluído!";
            try
            {
                // zero produto ainda não foi excluido
                var valor = 0;
                var produto = _context.tbproduto.Find(id);
                if (produto != null)
                {
                    _context.tbproduto.Remove(produto);
                    valor = _context.SaveChanges();
                }
                
                if (valor == 1)
                {
                    res = "Produto excluído";
                }
            }
            catch(Exception ex) {
                new Log().GravarErro(res, ex.InnerException.ToString(), "DeleteProduto");
            }

            return res;
        }

    }
}

using ControleProdutos.Data;
using ControleProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleProdutos.Generic;

namespace ControleProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        //cria instancia para conexão com o banco de dados
        private readonly ControleProdutosContext _context;
        public UnidadeController(ControleProdutosContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<Unidade> GetIdUnidade(int id)
        {
            var unidadeOld = new Unidade();
            try
            {
                var lista = await _context.tbunidade.ToListAsync();
                unidadeOld = lista.Where(e => e.id == id).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return unidadeOld;
        }

        [HttpGet("maiorID")]
        public async Task<int> GetMaxUnidade()
        {
            var lista = new List<Unidade>();
            int maiorID = 0;
            try
            {
                lista = await _context.tbunidade.ToListAsync();
                if (lista.Count > 0)
                {
                    maiorID = _context.tbunidade.Max(e => e.id);
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro("Erro ao buscar unidades", ex.InnerException.ToString(), "GetUnidade");
            }
            return maiorID;
        }

        //retorna uma lista de todas as unidades da tabela unidade
        [HttpGet]
        public async Task<List<Unidade>> GetUnidades()
        {
            var lista = new List<Unidade>();
            try
            {
                lista = await _context.tbunidade.ToListAsync();
            }catch (Exception ex)
            {
                new Log().GravarErro("Erro ao buscar unidade", ex.InnerException.ToString(), "GetUnidades");
            }
            return lista;
        }

        [HttpPost]
        public async Task<string> PostUnidade(Unidade newUnidade)
        {
            string res = "Erro ao incluir unidade";
            try
            {
                await _context.tbunidade.AddAsync(newUnidade);
                var valor = await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Unidade incluido!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PostUnidade");
            }

            return res;
        }

        [HttpPut]
        public async Task<string> PutUnidade(Unidade newUnidade)
        {
            string res = "Erro ao alterar unidade!";
            try
            {
                _context.tbunidade.Update(newUnidade);
                var valor = await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Unidade alterado!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PutUnidade");
            }

            return res;
        }


        [HttpDelete("Delete/{id}")]
        public string DeleteUnidade(int id)
        {
            string res = "Unidade não excluído!";
            try
            {
                // zero produto ainda não foi excluido
                var valor = 0;
                var unidade = _context.tbunidade.Find(id);
                if (unidade != null)
                {
                    _context.tbunidade.Remove(unidade);
                    valor = _context.SaveChanges();
                }

                if (valor == 1)
                {
                    res = "Unidade excluído";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "DeleteUnidade");
            }

            return res;
        }

    }
}

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
    public class ClienteController : ControllerBase
    {
        public static List<Cliente> listaCliente = new List<Cliente>();
        //Variavel controladora da execução da conexao com BD
        private readonly ControleProdutosContext _context;

        public ClienteController(ControleProdutosContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<Cliente> GetIdCliente(int id)
        {
            var clienteOld = new Cliente();
            try
            {
                var lista = await _context.tbcliente.ToListAsync();
                clienteOld = lista.Where(e => e.id == id).First();
            } catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message }");
            }
            return clienteOld;
        }

        [HttpGet("maiorID")]
        public async Task<int> GetMaxClientes()
        {
            return _context.tbcliente.Max(e => e.id);
        }

        [HttpGet]
        public List<Cliente> GetClientes()
        {
            return _context.tbcliente.ToList();
        }
        
        [HttpPost]
        public async Task<string> PostCliente(Cliente newCliente)
        {
            string res = "Erro ao incluir cliente";
            try
            {
                await _context.tbcliente.AddAsync(newCliente);
                var valor = await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Cliente cadastrado!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PostCliente");
            }

            return res;
        }

        [HttpPut]
        public async Task<string> PutCliente(Cliente newCliente)
        {
            string res = "Erro ao alterar cadastro do cliente!";
            try
            {
                _context.tbcliente.Update(newCliente);
                var valor = await _context.SaveChangesAsync();
                if (valor == 1)
                {
                    res = "Cadastro cliente alterado!";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "PutCliente");
            }

            return res;
        }

        [HttpDelete("Delete/{id}")]
        public string DeleteCliente(int id)
        {
            string res = "Cliente não excluído!";
            try
            {
                // zero produto ainda não foi excluido
                var valor = 0;
                var cliente = _context.tbcliente.Find(id);
                if (cliente != null)
                {
                    _context.tbcliente.Remove(cliente);
                    valor = _context.SaveChanges();
                }

                if (valor == 1)
                {
                    res = "Cliente excluído";
                }
            }
            catch (Exception ex)
            {
                new Log().GravarErro(res, ex.InnerException.ToString(), "DeleteProduto");
            }

            return res;
        }

    }
}

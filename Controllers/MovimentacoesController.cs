using GERESTOQUE.Models;
using Microsoft.AspNetCore.Mvc;

namespace GERESTOQUE.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly Contexto _contexto;

        public MovimentacoesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult NovaMovimentacao(int produtoId)
        {
            Movimentacao movimentacao = new Movimentacao { ProdutoId = produtoId };

            return View(movimentacao);
        }

        [HttpPost]
        public async Task<IActionResult> NovaMovimentacao(Movimentacao movimentacao)
        {
            movimentacao.DataMovimentacao = DateTime.Now.ToString();

            if(movimentacao != null)
            {
                await _contexto.Movimentacoes.AddAsync(movimentacao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("DetalhesProduto", "Produtos" ,new Produto { ProdutoId = movimentacao.ProdutoId});
            }

            return View(movimentacao);
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarMovimentacao(int movimentacaoId)
        {
            Movimentacao movimentacao = await _contexto.Movimentacoes.FindAsync(movimentacaoId);
            return View(movimentacao);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarMovimentacao(Movimentacao movimentacao)
        {
            if(movimentacao != null)
            {
                _contexto.Movimentacoes.Update(movimentacao);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("DetalhesProduto", "Produtos", new Produto { ProdutoId = movimentacao.ProdutoId });
            }

            return View(movimentacao);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirMovimentacao(int movimentacaoId)
        {
            Movimentacao movimentacao = await _contexto.Movimentacoes.FindAsync(movimentacaoId);
            _contexto.Movimentacoes.Remove(movimentacao);
            _contexto.SaveChangesAsync();
            return RedirectToAction("DetalhesProduto", "Produtos", new Produto { ProdutoId = movimentacao.ProdutoId });

        }
    }
}

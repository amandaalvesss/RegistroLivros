using LivrosApp.Models;
using LivrosApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApp.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio) 
        { 
            _livroRepositorio = livroRepositorio;
        }
        public IActionResult Index()
        {
            var livros = _livroRepositorio.ListarTodos();
            return View(livros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            LivroModel livro = _livroRepositorio.ListarPorId(id);

            return View(livro);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            LivroModel livro = _livroRepositorio.ListarPorId(id);
             return View(livro);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _livroRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Livro apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não conseguimos apagar o registro.";
                }
                return RedirectToAction("Index");

            } catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar o livro.Mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(LivroModel livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livroRepositorio.Adicionar(livro);
                    TempData["MensagemSucesso"] = "Livro cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(livro);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu livro. Tente novamente.Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Alterar(LivroModel livro)
        {
            try
            {
                {
                    _livroRepositorio.Atualizar(livro);
                    TempData["MensagemSucesso"] = "Livro alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", livro);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar o registro. Tente novamente.Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}

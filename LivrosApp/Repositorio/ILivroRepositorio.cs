using LivrosApp.Models;

namespace LivrosApp.Repositorio
{
    public interface ILivroRepositorio
    {
        List<LivroModel> ListarTodos();
        LivroModel Adicionar(LivroModel livro);

        LivroModel ListarPorId(int id);

        LivroModel Atualizar(LivroModel livro);

        bool Apagar(int id);
    }
}

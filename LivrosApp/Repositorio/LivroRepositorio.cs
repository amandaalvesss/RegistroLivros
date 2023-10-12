using LivrosApp.Data;
using LivrosApp.Models;

namespace LivrosApp.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BancoContext _bancoContext;
        public LivroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public LivroModel Adicionar(LivroModel livro)
        {
            _bancoContext.Livros.Add(livro);
            _bancoContext.SaveChanges();
             return livro;
        }

        public bool Apagar(int id)
        {
            LivroModel livroDB = ListarPorId(id);

            if (livroDB == null) throw new System.Exception("Houve um erro na deleção do livro");

            _bancoContext.Livros.Remove(livroDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public LivroModel Atualizar(LivroModel livro)
        {
            LivroModel livroDB = ListarPorId(livro.Id);

            if (livroDB == null) throw new System.Exception("Houve um erro na atualização.Tente novamente");
            livroDB.Nome = livro.Nome;
            livroDB.Autor = livro.Autor;
            livroDB.Categoria = livro.Categoria;
            livroDB.DataPublicacao = livro.DataPublicacao;
            livroDB.Status = livro.Status;

            _bancoContext.Livros.Update(livroDB);
            _bancoContext.SaveChanges();

            return livroDB;


        }

        public LivroModel ListarPorId(int id)
        {
            return _bancoContext.Livros.FirstOrDefault(x => x.Id == id);
        }

        public List<LivroModel> ListarTodos()
        {
            return _bancoContext.Livros.ToList();
        }

    }
}

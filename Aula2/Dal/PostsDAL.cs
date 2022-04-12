using Aula2.Data;
using Aula2.Model;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Aula2.Dal
{
    internal class PostsDAL
    {
        IConfiguration _configuration;
        DefaultConnection _connection;
        public PostsDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new DefaultConnection(_configuration);
        }

        public void Insert(Post post)
        {
            string query = "INSERT INTO posts (titulo, descricao,data) ";
            query += $"VALUES('{post.Titulo}', '{post.Descricao}','{post.Data}')";
            _connection.ExecuteCommand(query);
        }

        public void Update(Post post)
        {
            string query = $"UPDATE posts SET titulo='{post.Titulo}', descricao='{post.Descricao}',data='{post.Data}' WHERE id=" + post.Id;
            _connection.ExecuteCommand(query);
        }

        public void Delete(int Id)
        {
            string query = "DELETE FROM posts WHERE id=" + Id;
            _connection.ExecuteCommand(query);
        }

        public List<Post> GetAll()
        {
            var posts = new List<Post>();
            var result = _connection.ExecuteQuery("SELECT * FROM posts"); //join comentarios on (posts.id=comentarios.postid)
            while (result.Read())
            {
                DateTime data_formatada = DateTime.Parse(result["data"].ToString(), CultureInfo.CreateSpecificCulture("pt-BR"));

                posts.Add(new Post
                {
                    

                    Id = int.Parse(result["id"].ToString()),
                    Titulo      = result["titulo"].ToString(),
                    Descricao   = result["descricao"].ToString(),
                    Data        = data_formatada != null ? data_formatada : null,
                  
                });
            }
            return posts;
        }

        public Post GetById(int id)
        {
            var posts = new Post();
            var result = _connection.ExecuteQuery("SELECT * FROM posts where id="+id);
            while (result.Read())
            {
                DateTime data_formatada = DateTime.Parse(result["data"].ToString(), CultureInfo.CreateSpecificCulture("pt-BR"));

                posts = new Post
                {
                    Id = int.Parse(result["id"].ToString()),
                    Titulo = result["titulo"].ToString(),
                    Descricao = result["descricao"].ToString(),
                    Data = data_formatada != null ? data_formatada : null
                };
            }
            return posts;
        }
    }
}

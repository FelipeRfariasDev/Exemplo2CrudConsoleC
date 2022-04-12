using Aula2.Dal;
using Aula2.Model;
using Microsoft.Extensions.Configuration;

namespace Aula2
{
    internal class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            ConfigureAppSettings();
            //Console.WriteLine("ola mundo");
            //InsertPost("teste felipe", "hoje");


            /*
            int i = 1;
            while (i <= 10)
            {
                InsertPost("titulo" + i, "descricao" + i, DateTime.Now);
                i++;
            }*/

            //GetlAll();
            var post = GetPostById(1);
            InsertComentario("mais 1 comentario post 1", post.Id);
        }

        private static void InsertComentario(string comentario, int posts_id)
        {
            var comentarioDal = new ComentarioDal(_configuration);
            comentarioDal.Insert(new Comentarios { Comentario = comentario, PostsId = posts_id });
        }

        private static void GetlAll()
        {
            var postDal = new PostsDAL(_configuration);
            var posts = postDal.GetAll();
            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " - " + post.Titulo + " - " + post.Descricao + " - " + ((DateTime) post.Data).ToShortDateString());
            }
        }

        public static Post GetPostById(int id)
        {
            var postDal = new PostsDAL(_configuration);
            var posts = postDal.GetById(id);

            return posts;
        }

        private static void InsertPost(string titulo, string descricao, DateTime data)
        {
            var postDal = new PostsDAL(_configuration);
            postDal.Insert(new Post { Descricao = descricao, Titulo = titulo, Data = data });
        }

        private static void UpdatePost(int id, string titulo, string descricao, DateTime data)
        {
            var postDal = new PostsDAL(_configuration);
            postDal.Update(new Post { Id = id, Descricao = descricao, Titulo = titulo, Data = data });
        }

        private static void DeletePost(int Id)
        {
            var postDal = new PostsDAL(_configuration);
            postDal.Delete(Id);
        }

        private static void ConfigureAppSettings()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }
    }
}
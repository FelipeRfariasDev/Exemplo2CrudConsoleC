using Aula2.Data;
using Aula2.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2.Dal
{
    internal class ComentarioDal
    {
        IConfiguration _configuration;
        DefaultConnection _connection;
        public ComentarioDal(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new DefaultConnection(_configuration);
        }

        public void Insert(Comentarios comentario)
        {
            string query = "INSERT INTO comentarios (comentario, posts_id) ";
            query += $"VALUES('{comentario.Comentario}', '{comentario.PostsId}')";
            _connection.ExecuteCommand(query);
        }
    }
}

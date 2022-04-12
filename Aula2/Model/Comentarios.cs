using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2.Model
{
    internal class Comentarios
    {
        public int Id { get; set; }

        public string Comentario { get; set; }

        public int PostsId { get; set; }
    }
}

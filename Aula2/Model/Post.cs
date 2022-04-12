namespace Aula2.Model
{
    internal class Post
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime? Data { get; set; }

        public ICollection<Comentarios> Comentarios { get; set; }
        //public List<Comentarios> Comentarios { get; set; }
    }
}

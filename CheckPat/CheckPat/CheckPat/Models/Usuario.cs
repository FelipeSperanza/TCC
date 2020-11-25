using System.ComponentModel.DataAnnotations.Schema;


namespace CheckPat.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
    }
}
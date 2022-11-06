namespace C__API.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nome { get; set; } 
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public DateTime dataNacimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

    }
}
namespace WebApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public char Progresso { get; set; }

        public DateTime? DtPrazo { get; set; }
    }
}

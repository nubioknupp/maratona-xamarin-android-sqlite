using SQLite;

namespace SQLiteDemo.Model
{
    public class Funcionario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Nome { get; set; }

        [MaxLength(30)]
        public string Cargo { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

    }
}
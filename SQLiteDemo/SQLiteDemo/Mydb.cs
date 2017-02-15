using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using SQLiteDemo.Model;

namespace SQLiteDemo
{
    public class Mydb : IDisposable
    {
        private readonly SQLiteConnection _conexao;

        public Mydb()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _conexao = new SQLiteConnection(Path.Combine(path, "SQLiteDemo.db3"));

            _conexao.CreateTable<Funcionario>();
        }

        public void Insert(Funcionario funcionario)
        {
            _conexao.Insert(funcionario);
        }

        public void Delete(Funcionario funcionario)
        {
            _conexao.Delete(funcionario);
        }

        public Funcionario ObterPorId(int id)
        {
            return _conexao.Table<Funcionario>().FirstOrDefault(c => c.Id == id);
        }

        public void Update(Funcionario funcionario)
        {
            _conexao.Update(funcionario);
        }

        public List<Funcionario> Listar()
        {
            return _conexao.Table<Funcionario>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
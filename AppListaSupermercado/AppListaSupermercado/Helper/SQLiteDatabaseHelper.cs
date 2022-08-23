using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using AppListaSupermercado.Model;

namespace AppListaSupermercado.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET NomeProduto=?, Quantidade=?, PrecoUnitario=?, PrecoTotal=? WHERE id= ?";
            return _conn.QueryAsync<Produto>(sql, p.NomeProduto, p.Quantidade, p.PrecoUnitario, p.PrecoTotal, p.Id);

        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        public void insert(Produto p)
        {

        }

        public void getAllRows()
        {

        }

        public void delete(int id)
        {

        }

        public void update(Produto p)
        {

        }
    }
}

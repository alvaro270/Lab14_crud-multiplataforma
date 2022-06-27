using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Crudlab.Model;

namespace Crudlab
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<AlumnoModel>();
        }
        public Task<int> CreateAlumno(AlumnoModel Alumno)
        {
            return db.InsertAsync(Alumno);
        }
        public Task<List<AlumnoModel>> ReadAlumnos()
        {
            return db.Table<AlumnoModel>().ToListAsync();
        }
        public Task<int> UpdateAlumno(AlumnoModel Alumno)
        {
            return db.UpdateAsync(Alumno);
        }
        public Task<int> DeleteAlumno(AlumnoModel Alumno)
        {
            return db.DeleteAsync(Alumno);
        }
        public Task<List<AlumnoModel>> Search(string search)
        {
            return db.Table<AlumnoModel>().Where(p => p.Nombre.StartsWith(search)).ToListAsync();
        }
    }
}

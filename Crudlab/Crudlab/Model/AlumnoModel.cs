using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Crudlab.Model
{
    public class AlumnoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public DateTime Cumple { get; set; }
        public int Nota { get; set; }
        public bool Aprobado { get; set; }
    }
}

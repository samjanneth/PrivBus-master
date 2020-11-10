using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PrivBus.Clases
{
    class Usuario
    {
        [Table("Users")]
        public class User
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [MaxLength(150), NotNull]
            public String Names { get; set; }
            [MaxLength(100), NotNull]
            public String Email { get; set; }
            [MaxLength(150), NotNull]
            public String UserName { get; set; }
            public string Password { get; set; }
            public String EmpNumber { get; set; }
            [NotNull]
            public DateTime DOB { get; set; }
            [NotNull]
            public DateTime DOC { get; set; }

        }
    }
}

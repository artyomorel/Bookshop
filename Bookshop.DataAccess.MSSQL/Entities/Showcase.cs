using System;
using System.Collections.Generic;

namespace Bookshop.DataAccess.MSSQL.Entities
{
    public class Showcase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSize { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime DeleteTime { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
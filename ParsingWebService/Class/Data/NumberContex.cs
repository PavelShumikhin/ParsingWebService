using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ParsingWebService.Class
{
    public class NumberContext:DbContext
    {
        public NumberContext(): base("DbConnection")
        { }

        public DbSet<NumberData> Numbers { get; set; }
    }
}

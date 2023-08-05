using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFile
{
    public class Users
    {
        public Users(int id, string name) 
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
    }
}

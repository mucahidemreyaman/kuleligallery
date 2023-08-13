using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuleli.Shop.Application.Exceptions
{
    public class NotFoundException : Exception

    {
        public int Id { get; set; }

        public NotFoundException(string message):base(message) 
        { 

        }
        public NotFoundException() : base()
        {
        
        }
       
    }
}

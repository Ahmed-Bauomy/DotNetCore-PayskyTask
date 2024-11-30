using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Application.Exceptions
{
    public class CustomNotFoundException : Exception
    {
        public CustomNotFoundException(string name, string key)
            :base($"Entity \" { name }\" with Key { key } not found")
        { }
    }
}

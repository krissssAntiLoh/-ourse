using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorbitWpf.Entities
{
    public partial class Worker 
    {
        public string FullName { get { return $"{Name} {Surname}"; } }
    }
}

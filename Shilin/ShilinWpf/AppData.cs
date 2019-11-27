using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShilinWpf
{
    class AppData
    {
        public static Frame MainFrame;

        public static Entities.ShilinSupportEntities Context = new Entities.ShilinSupportEntities();
    }
}

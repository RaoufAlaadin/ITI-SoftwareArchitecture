using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindConsoleAPP.Entites
{
    /* NOTES:
     using this partial class will allow me to add code to the genereted class
     by EF power tools.
    The point is, this class will stay even if we re run DBcontext, while other code will
    be edited. */
    partial class Product
    {
        public override string ToString() => ProductName;
        
    }
}

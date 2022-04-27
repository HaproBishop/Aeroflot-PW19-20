using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeroflot
{
    public static class DBContext
    {
        static AeroflotEntities _context;
        public static AeroflotEntities GetContext()
        {
            if (_context == null) return _context = new AeroflotEntities();
            else return _context;
        }
    }
}

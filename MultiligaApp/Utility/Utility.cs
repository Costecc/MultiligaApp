using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiligaApp
{
    class Utility
    {
        static protected multiligaEntities db;

        public static void setDBContext(multiligaEntities context)
        {
            db = context;
        }
    }
}

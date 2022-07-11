using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace DalXML
{
    public partial class DalXML : IDal
    {
        internal static DalXML Instance;

        private DalXML() { }
        public static DalXML GetInstance()
        {
            if (Instance == null)
                Instance = new DalXML();
            return Instance;
        }
    }
}

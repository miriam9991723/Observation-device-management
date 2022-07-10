using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace DalObject
{
    public partial class DalObject : IDal
    {
        internal static DalObject Instance;

        private DalObject() { }
        public static DalObject GetInstance()
        {
            if (Instance == null)
                Instance = new DalObject();
            return Instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DalApi;

namespace BL
{
    public partial class BL : IBL
    {
        internal static BL Instance;
        private IDal dal = DalFactory.GetDal();
        private BL() { }
        public static BL GetInstance()
        {
            if (Instance == null)
                Instance = new BL();
            return Instance;
        }

    }
}

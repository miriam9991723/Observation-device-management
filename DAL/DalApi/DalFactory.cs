using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalObject;

namespace DalApi
{
    class DalFactory
    {
        public IDal GetDal()
        {
            return DalObject.DalObject.GetInstance();

        }
    }
}

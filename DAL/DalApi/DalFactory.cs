using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalObject;

namespace DalApi
{
    public class DalFactory
    {
        public static IDal GetDal()
        {
            return DalXML.DalXML.GetInstance();

        }
    }
}

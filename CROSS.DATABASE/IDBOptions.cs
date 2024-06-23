using CROSS.DATABASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.SLK.DATABASE
{
    public interface IDBOptions
    {
        DBOptionItems getItemOptions(string name);
    }
}

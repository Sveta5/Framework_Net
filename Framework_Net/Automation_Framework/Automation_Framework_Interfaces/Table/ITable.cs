using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Interfaces.Table
{
    public interface ITable<Row>
    {
        IEnumerable<Row> GetRows();
    }
}

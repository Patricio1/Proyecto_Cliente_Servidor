using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SMC.BusinessObjects
{
    public interface IForm
    {
        bool LoadDataGridView(DataTable dataTableParam);
    }
}

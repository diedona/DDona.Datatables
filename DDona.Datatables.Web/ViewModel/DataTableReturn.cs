using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.Datatables.Web.ViewModel
{
    public class DataTableReturn
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object[] data { get; set; }
    }
}
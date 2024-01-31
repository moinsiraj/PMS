using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Chart
/// </summary>
public class ChartJsCls
{
    public class Get_Month_Production
    {
        public string CutQty { get; set; }
        public string InputQty { get; set; }
        public string SQCQty { get; set; }
        public string FinQty { get; set; }
        public string PakQty { get; set; }
        public string ExpQty { get; set; }
    }

   

  

    public class SaleValue
    {

        public string SalesDate { get; set; }
        public string Salespaid { get; set; }
        public string Salesvalue { get; set; }       
        public string QCOut { get; set; }
        public string FiQty { get; set; }
        public string PakQty { get; set; }
        public string ExpQty { get; set; }
    
    }
}
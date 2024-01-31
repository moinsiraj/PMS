using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
            new DataColumn("B_ID"),
            new DataColumn("B_Name"),
            new DataColumn("B_QTY"),
            new DataColumn("Rate")
        });
            dt.Rows.Add(1, "12 liter", "2", 60);
            dt.Rows.Add(2, "19 liter", "2", 40);
            GVFood.DataSource = dt;
            GVFood.DataBind();
        }

    }

  
}
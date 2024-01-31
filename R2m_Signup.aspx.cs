using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
public partial class R2m_Signup : System.Web.UI.Page
{
    moruDLL RADIDLL = new moruDLL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
    }



    protected void txtsupplierid_TextChanged(object sender, System.EventArgs e)
    {
        //TextBox2.Text = TextBox1.Text;
    }


    protected void SupplierName()
    {

        DataTable RADIDT = RADIDLL.get_SpecfoInventoryDataTable("SELECT cSupName FROM Smt_Suppliers where ");
        if (RADIDT.Rows.Count > 0)
        {

            txtsupname.Text = RADIDT.Rows[0]["cGmetDis"].ToString();


        }

        else
        {
            txtsupname.Text = "";

        }

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class R2m_Master_Setup : System.Web.UI.Page
{
    SqlConnection cn = moruGetway.SpecFo;
    SqlConnection scm_cnn = moruGetway.moru_SCM;
    SqlConnection cnn = moruGetway.SpecfoInventory;
    moruDLL RADIDLL = new moruDLL();
    moruBLL RADIBLL = new moruBLL();
    private string message = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Redirect("R2m_Login.aspx", false);
            return;
        }

        if (!IsPostBack)
        {
            LabelCompany();
            CountryofOrigin();
            BindGVSUPPLIER();         
            SupplierCode();
            BindCOMPANY();
            BtnSupUpdate.Visible = false;      
            BtnComUpdate.Visible = false;
        }


    }


    #region Notification
    // Active Company
    public void LabelCompany()
    {
        DataTable dsGetCompany = RADIDLL.get_SpecfodataTable("select COUNT(cCmpName) AS comapany from Smt_Company where Active_Com=1");
        if (dsGetCompany.Rows.Count > 0)
        {
            lblcompany.Text = dsGetCompany.Rows[0]["comapany"].ToString();
        }
    }

    // Active Users
    public void LabelUsers()
    {
        //DataTable dsGetCompany = RADIDLL.get_InformationdataTable("SELECT COUNT(dbo.Mr_UserInfo.full_nm) AS Users FROM dbo.Mr_UserInfo INNER JOIN dbo.Mr_Company ON dbo.Mr_UserInfo.com_nm = dbo.Mr_Company.com_id WHERE  (dbo.Mr_UserInfo.user_act_inact = 'Active')");
        //if (dsGetCompany.Rows.Count > 0)
        //{
        //    lblUsers.Text = dsGetCompany.Rows[0]["Users"].ToString();
        //}
    }

    // Total Users Group
    public void LabelUsersGroup()
    {
        //DataTable dsGetCompany = RADIDLL.get_InformationdataTable("SELECT COUNT(nUgroup) AS GP from Mr_UserGroups");
        //if (dsGetCompany.Rows.Count > 0)
        //{
        //    lblUG.Text = dsGetCompany.Rows[0]["GP"].ToString();
        //}
    }

    #endregion Notification

    #region Company


    protected void BtnComSave_Click(object sender, EventArgs e)
    {

        cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_CompanySave", cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@com_nm", txtCom.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@com_prop", txtprop.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@com_mobile", txtmobile.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@com_mail", txtcmmobile.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@com_addrs1", txtcomadd.Text.Trim());       
        Mrcmd.Parameters.AddWithValue("@cmpt", 0);
        Mrcmd.Parameters.AddWithValue("@com_crt_nm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@com_crt_date", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cnn.Close();

        lbl1.Text = message;
        {
            txtCom.Text = "";
            txtmobile.Text = "";
            //txtprop.Text = "";
            txtcomadd.Text = "";
            //txtcmmobile.Text = "";




        }
        BindCOMPANY();
    }






    private void BindCOMPANY()
    {
        GVCOMPANY.DataSource = RADIDLL.get_SpecfodataTable("SELECT * FROM Smt_Company where Active_Com=1 order by cCmpName");
        GVCOMPANY.DataBind();

    }


    protected void GVCOMPANY_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GVCOMPANY.PageIndex = e.NewPageIndex;
        //BindCOMPANY();
    }


    protected void GVCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
    {

        //GridViewRow row = GVSRINFO.SelectedRow;

        //txtcl_id.Text = row.Cells[1].Text;
        //txtFullNm.Text = row.Cells[2].Text;
        //txtmobile.Text = row.Cells[3].Text;
        //txtNID.Text = row.Cells[4].Text;
        //txtpresntaddr.Text = row.Cells[5].Text;
        //txtpermntaddr.Text = row.Cells[6].Text;
        //btnsave.Visible = false;
        //btnupdt.Visible = true;
        //lbl1.Text = "";
    }

    protected void BtnComUpdate_Click(object sender, EventArgs e)
    {


        cnn.Open();

        string id = txtcom_id.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_CompanyUpdate", cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@com_id", id);
        //Mrcmd.Parameters.AddWithValue("@com_nm", txtCom.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@com_prop", txtprop.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@com_mobile", txtmobile.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@com_mail", txtcmmobile.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@com_addrs1", txtcomadd.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@com_crt_nm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@com_crt_date", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cnn.Close();

        lbl1.Text = message;
        {

            BtnComSave.Visible = true;
            BtnComUpdate.Visible = false;
            BindCOMPANY();
            txtCom.Text = "";
            txtmobile.Text = "";
            //txtprop.Text = "";
            txtcomadd.Text = "";
            txtcom_id.Text = "";
            //txtcmmobile.Text = "";
            //lbl1.Text = "";
        }
    }
    protected void GVCOMPANY_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVCOMPANY.Rows[indx].FindControl("Label1");
            string Selectstatment = "SELECT  FROM [dbo].[Smt_Company] where nCompanyID='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_SpecfodataTable(Selectstatment);
            txtcom_id.Text = dt.Rows[0]["nCompanyID"].ToString();
            txtCom.Text = dt.Rows[0]["cCmpName"].ToString();
            //txtcmmobile.Text = dt.Rows[0]["com_mail"].ToString();
            //txtmobile.Text = dt.Rows[0]["com_mobile"].ToString();
            //txtprop.Text = dt.Rows[0]["com_prop"].ToString();
            txtcomadd.Text = dt.Rows[0]["cAdd1"].ToString();

            txtCom.Enabled = false;

            BtnComSave.Visible = false;
            BtnComUpdate.Visible = true;

        }
    }

    protected void BtnComClear_Click(object sender, EventArgs e)
    {

        //BtnComSave.Visible = true;
        //BtnComUpdate.Visible = false;
        //BindCOMPANY();
        //txtCom.Text = "";
        //txtmobile.Text = "";
        //txtprop.Text = "";
        //txtcomadd.Text = "";
        //txtcom_id.Text = "";
        //txtcmmobile.Text = "";
        //txtCom.Enabled = true;

    }

    #endregion


    #region New User

    public void BindCompany()
    {
        //ddcomnm.DataSource = RADIDLL.get_InformationdataTable("select distinct com_id, com_nm from Mr_Company order by com_nm");
        //ddcomnm.DataTextField = "com_nm";
        //ddcomnm.DataValueField = "com_id";
        //ddcomnm.DataBind();
        //ddcomnm.Items.Insert(0, "");
    }




    public void BindUSERGROUP()
    {
        //ddGroup.DataSource = RADIDLL.get_InformationdataTable("select nUgroup, cGrpDescription from Mr_UserGroups order by cGrpDescription");
        //ddGroup.DataTextField = "cGrpDescription";
        //ddGroup.DataValueField = "nUgroup";
        //ddGroup.DataBind();
        //ddGroup.Items.Insert(0, "");
    }








    protected void BtnNewUser_Click(object sender, EventArgs e)
    {
        //String userstatus = String.Empty;
        ////String rs = String.Empty;
        //if (rbA.Checked == true)
        //{
        //    userstatus = "Active";
        //}
        //else if (rbIA.Checked == true)
        //{
        //    userstatus = "InActive";

        //}


        //if (txtPW.Text == txtCPW.Text)
        //{

        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand("Mr_UserInfoSave", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@full_nm", txtfull.Text.Trim());
        //    cmd.Parameters.AddWithValue("@midd_nm", txtuid.Text.Trim());
        //    cmd.Parameters.AddWithValue("@passw", txtPW.Text.Trim());
        //    cmd.Parameters.AddWithValue("@cnf_passw", txtCPW.Text.Trim());
        //    cmd.Parameters.AddWithValue("@user_act_inact", userstatus);
        //    cmd.Parameters.AddWithValue("@user_st", 'G');
        //    cmd.Parameters.AddWithValue("@mobile", txtCN.Text.Trim());
        //    cmd.Parameters.AddWithValue("@com_nm", ddcomnm.SelectedValue);
        //    cmd.Parameters.AddWithValue("@usergp_id", ddGroup.SelectedValue);
        //    cmd.Parameters.AddWithValue("@Inputdate", DateTime.Now);
        //    cmd.Parameters.AddWithValue("@ent_un", Session["UID"]);
        //    cmd.Parameters.Add("@error", SqlDbType.Char, 500);
        //    cmd.Parameters["@error"].Direction = ParameterDirection.Output;
        //    cmd.ExecuteNonQuery();
        //    message = (string)cmd.Parameters["@error"].Value;
        //    cn.Close();
        //    //message = "Save Successfully";
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //}


        //txtuid.Text = "";
        //txtfull.Text = "";
        //txtPW.Text = "";
        //txtCN.Text = "";
        //txtCPW.Text = "";
        ////Response.Redirect("CreateUserAccount.aspx");
        //BindUserInfo();

    }



    private void BindUserInfo()
    {
        //gvuserinfo.DataSource = RADIDLL.get_InformationdataTable("Select*from Mr_UserInfoView order by midd_nm ASC,full_nm ASC");
        //gvuserinfo.DataBind();
    }




    protected void gvuserinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //if (e.CommandName == "Select")
        //{

        //    //TabContainer1.ActiveTab = TabPanel1;

        //    lbl1.Text = "";
        //    txtuid.Enabled = false;

        //    int indx = int.Parse(e.CommandArgument.ToString());
        //    Label x = (Label)gvuserinfo.Rows[indx].Cells[1].FindControl("lbluid");
        //    DataSet ds = getUser(x.Text);
        //    lblui.Text = ds.Tables[0].Rows[0]["id"].ToString();
        //    txtuid.Text = ds.Tables[0].Rows[0]["midd_nm"].ToString();
        //    txtfull.Text = ds.Tables[0].Rows[0]["full_nm"].ToString();
        //    txtPW.Attributes["value"] = ds.Tables[0].Rows[0]["passw"].ToString();
        //    txtCPW.Attributes["value"] = ds.Tables[0].Rows[0]["cnf_passw"].ToString();
        //    txtCN.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
        //    ddcomnm.SelectedValue = ds.Tables[0].Rows[0]["com_nm"].ToString();

        //    ddGroup.SelectedValue = ds.Tables[0].Rows[0]["usergp_id"].ToString();
        //    string activity = ds.Tables[0].Rows[0]["user_act_inact"].ToString();
        //    if (activity == "Active")
        //    {
        //        rbA.Checked = true;
        //        rbIA.Checked = false;
        //    }
        //    else
        //    {
        //        rbIA.Checked = true;
        //        rbA.Checked = false;
        //    }




        //}




        //btnupdate.Visible = true;
        //BtnNewUser.Visible = false;



    }

    private DataSet GetCom(string p)
    {

        SqlDataAdapter da = new SqlDataAdapter("select com_id, com_nm from Mr_Company where com_id='" + p + "' ", cn);
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return ds;

    }


    public DataSet getUser(string userid)
    {
        SqlDataAdapter da = new SqlDataAdapter("select*from Mr_UserInfo where midd_nm='" + userid + "'", cn);
        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }
        return ds;

    }

    protected void gvuserinfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvuserinfo.PageIndex = e.NewPageIndex;
        //BindUserInfo();
    }


    protected void gvuserinfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.previous_color=this.style.backgroundColor;this.style.backgroundColor='#E1E1E1'");


            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.previous_color;");
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //String userstatus = String.Empty;
        ////String rs = String.Empty;
        //if (rbA.Checked == true)
        //{
        //    userstatus = "Active";
        //}
        //else if (rbIA.Checked == true)
        //{
        //    userstatus = "InActive";

        //}


        //if (txtPW.Text == txtCPW.Text)
        //{
        //    cn.Open();

        //    string id = lblui.Text;
        //    SqlCommand Mrcmd = new SqlCommand("Mr_UserInfoUpdate", cn);
        //    Mrcmd.CommandType = CommandType.StoredProcedure;
        //    Mrcmd.Parameters.AddWithValue("@id", lblui.Text);
        //    Mrcmd.Parameters.AddWithValue("@full_nm", txtfull.Text.Trim());
        //    Mrcmd.Parameters.AddWithValue("@midd_nm", txtuid.Text.Trim());
        //    Mrcmd.Parameters.AddWithValue("@passw", txtPW.Text.Trim());
        //    Mrcmd.Parameters.AddWithValue("@cnf_passw", txtCPW.Text.Trim());
        //    Mrcmd.Parameters.AddWithValue("@user_act_inact", userstatus);
        //    Mrcmd.Parameters.AddWithValue("@user_st", 'G');
        //    Mrcmd.Parameters.AddWithValue("@mobile", txtCN.Text.Trim());
        //    Mrcmd.Parameters.AddWithValue("@com_nm", ddcomnm.SelectedValue);
        //    Mrcmd.Parameters.AddWithValue("@usergp_id", ddGroup.SelectedValue);
        //    Mrcmd.Parameters.AddWithValue("@Inputdate", DateTime.Now);
        //    Mrcmd.Parameters.AddWithValue("@ent_un", Session["UID"]);
        //    Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //    Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //    Mrcmd.ExecuteNonQuery();
        //    message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //    cn.Close();

        //    //message = "Save Successfully";
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //    {


        //    }

        //}
        //BtnNewUser.Visible = true;
        //btnupdate.Visible = false;
        ////Response.Redirect("CreateUserAccount.aspx");
        //BindUserInfo();
    }


    protected void btnClr_Click(object sender, EventArgs e)
    {
        //BtnNewUser.Visible = true;
        //btnupdate.Visible = false;
        //txtCN.Text = "";
        //txtuid.Text = "";
        //txtfull.Text = "";
        //txtuid.Enabled = true;
        //txtCPW.Attributes["value"] = "";
        //txtPW.Attributes["value"] = "";

        //rbA.Checked = false;
        //rbIA.Checked = false;
        //ddcomnm.Items.Clear();
        //BindCompany();

        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }


    #endregion


    #region User Group

    public void bindgrid()
    {
        //grdPermission.DataSource = RADIDLL.get_InformationdataTable("SELECT [Form_Name],Url, [Form_Desc], [Module_Name], [slno] FROM [Mr_Userpermission] ORDER BY [Module_Name], [Form_Name]");
        //grdPermission.DataBind();

    }
    public void bindsv()
    {
        //GridView2.DataSource = RADIDLL.get_InformationdataTable("SELECT [nUgroup], [cGrpDescription], [cEntUser], [dEntdt] FROM [Mr_UserGroups] ORDER BY [cGrpDescription]");
        //GridView2.DataBind();
    }
    public static void MergeRows(GridView gridView)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];
            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                             previousRow.Cells[0].RowSpan + 1;
                previousRow.Cells[0].Visible = false;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(lblgrpid.Text))
        //{
        //    RADIDLL.Save_Usergroup(txtGroup.Text.Trim(), Session["Uid"].ToString());
        //    DataSet ds = RADIDLL.get_InformationDataSet("select nUgroup from Mr_UserGroups where cGrpDescription='" + txtGroup.Text.Trim() + "'");
        //    lblgrpid.Text = ds.Tables[0].Rows[0]["nUgroup"].ToString();
        //    txtGroup.Text = "";
        //    message = "Save Successfully";
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //}
        //else
        //{
        //    RADIDLL.Update_Usergroup(int.Parse(lblgrpid.Text), txtGroup.Text.Trim(), Session["Uid"].ToString());
        //    txtGroup.Text = "";
        //    message = "Update Successfully";
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);
        //}
        //RADIDLL.Delete_grouppermission(int.Parse(lblgrpid.Text));
        //for (int i = 0; i < grdPermission.Rows.Count; i++)
        //{
        //    CheckBox ck = (CheckBox)grdPermission.Rows[i].FindControl("chkselect");
        //    string formname = grdPermission.Rows[i].Cells[1].Text;
        //    Label lblurl = (Label)grdPermission.Rows[i].FindControl("lblformurl");
        //    if (ck.Checked == true)
        //    {
        //        RADIDLL.Save_grouppermission(lblgrpid.Text, formname, lblurl.Text.Trim(), "G", Session["Uid"].ToString());
        //    }
        //}
        //lblgrpid.Text = "";
        //btnSave.Text = "Save";
        //bindgrid();
        //bindsv();
        //txtGroup.Focus();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        //lblErrormsg.Text = "";
        //txtGroup.Text = "";
        //txtGroup.Focus();
        //lblgrpid.Text = "";
        //lblErrormsg.Text = "";
        //btnSave.Text = "Save";
        //btnSave.Enabled = true;
        //bindgrid();
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Select")
        //{
        //    int indx = int.Parse(e.CommandArgument.ToString());
        //    Label x = (Label)GridView2.Rows[indx].FindControl("lblid");
        //    //DataTable dt = RADIDLL.get_Usergroupbyid(int.Parse(x.Text));
        //    //txtGroup.Text = dt.Rows[0]["cGrpDescription"].ToString();
        //    //lblgrpid.Text = dt.Rows[0]["nUgroup"].ToString();
        //    btnSave.Text = "Update";
        //    DataTable dtable = RADIDLL.get_InformationdataTable("select Form_Name from Mr_UserPermittedform where nUgroup='" + int.Parse(lblgrpid.Text) + "'");
        //    if (txtGroup.Text == "Admin")
        //    {
        //        btnSave.Enabled = false;
        //    }
        //    else
        //    {
        //        btnSave.Enabled = true;
        //    }
        //    foreach (GridViewRow rows in grdPermission.Rows)
        //    {
        //        CheckBox checkbox = (CheckBox)rows.FindControl("chkselect");
        //        checkbox.Checked = false;
        //    }
        //    foreach (DataRow drr in dtable.Rows)
        //    {
        //        foreach (GridViewRow rows in grdPermission.Rows)
        //        {
        //            string ss = rows.Cells[1].Text;
        //            if (ss == drr[0].ToString())
        //            {
        //                CheckBox checkbox = (CheckBox)rows.FindControl("chkselect");
        //                checkbox.Checked = true;
        //            }
        //        }
        //    }

        //}
    }
    protected void grdPermission_PreRender(object sender, EventArgs e)
    {
        //MergeRows(grdPermission);
    }
    protected void grdPermission_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes.Add("style", "text-align:center");
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView2.PageIndex = e.NewPageIndex;
        //bindsv();
    }


    #endregion

    #region items-Main Category


    public void BindCompany1()
    {
        //DDCOM1.DataSource = RADIDLL.get_InformationdataTable("select com_id,com_nm from Mr_Company where cmpt=1 and com_nm='" + Session["CompanyID"] + "'");
        //DDCOM1.DataTextField = "com_nm";
        //DDCOM1.DataValueField = "com_id";
        //DDCOM1.DataBind();
        //DDCOM1.Items.Insert(0, "");

    }

    protected void BtnItems_Click(object sender, EventArgs e)
    {
        ////Label lbl = (Label)this.Master.FindControl("lbltotalinfo");
        //cn.Open();
        //SqlCommand Mrcmd = new SqlCommand("Mr_MainCategorySave", cn);
        //Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@mc_com", DDCOM1.SelectedValue);
        //Mrcmd.Parameters.AddWithValue("@mc_nm", txtMainCat.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@mc_ct_unm", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("@mc_ct_dt", DateTime.Now);
        //Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //Mrcmd.ExecuteNonQuery();
        //message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //cn.Close();

        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //{
        //    txtMainCat.Text = "";
        //}

        //BindGVITEMS();
    }

    protected void ddmcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVITEMS();
    }
    private void BindGVITEMS()
    {
        //GVITEMS.DataSource = RADIDLL.get_InformationdataTable("SELECT*FROM Mr_MainCategory where mc_com='" + DDCOM1.SelectedValue + "'");
        //GVITEMS.DataBind();
    }


    protected void GVITEMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GVITEMS.PageIndex = e.NewPageIndex;
        //BindGVITEMS();
    }

    protected void GVITEMS_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Select")
        //{
        //    int indx = int.Parse(e.CommandArgument.ToString());
        //    Label ext = (Label)GVITEMS.Rows[indx].FindControl("lblbid");
        //    string Selectstatment = "select mc_id,mc_nm from Mr_MainCategory where mc_id='" + ext.Text + "'";
        //    DataTable dt = RADIDLL.get_InformationdataTable(Selectstatment);
        //    txtb_id.Text = dt.Rows[0]["mc_id"].ToString();
        //    txtMainCat.Text = dt.Rows[0]["mc_nm"].ToString();
        //    BtnItems.Visible = false;
        //    btnItemsUpdate.Visible = true;


        //}
    }


    protected void btnItemsUpdate_Click(object sender, EventArgs e)
    {

        //cn.Open();
        ////Label lbl = (Label)this.Master.FindControl("lbltotalinfo");
        //string id = txtb_id.Text;
        //SqlCommand moru = new SqlCommand("Mr_MainCategoryUpdate", cn);
        //moru.CommandType = CommandType.StoredProcedure;
        //moru.Parameters.AddWithValue("@mc_id", id);
        //moru.Parameters.AddWithValue("@mc_nm", txtMainCat.Text.Trim());
        //moru.Parameters.AddWithValue("@mc_ct_dt", DateTime.Now);
        //moru.Parameters.AddWithValue("@mc_ct_unm", Session["UID"]);
        //moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //moru.ExecuteNonQuery();
        //message = (string)moru.Parameters["@ERROR"].Value;
        //cn.Close();
        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //{

        //    txtMainCat.Text = "";
        //    BtnItems.Visible = true;
        //    btnItemsUpdate.Visible = false;
        //    BindGVITEMS();

        //}
    }

    protected void btnItemsClr_Click(object sender, EventArgs e)
    {
        //txtMainCat.Text = "";
        //BindCompany1();
        message = "Clear Data Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion End Main Category


    #region Supplier Add

    #region Country of Origin
    public void CountryofOrigin()
    {
        ddctnm.DataSource = RADIDLL.get_SCMDataSet("SELECT cor_id,cor_description FROM Mr_Country_Of_Origin Order by cor_description");
        ddctnm.DataTextField = "cor_description";
        ddctnm.DataValueField = "cor_id";
        ddctnm.DataBind();
        ddctnm.Items.Insert(0, "");

    }

    #endregion



    protected void BtnSupSave_Click(object sender, EventArgs e)
    {

        SqlCommand Mrcmd = new SqlCommand("Mr_Supplier_Name_Save", scm_cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@sn_name", txtsnm.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@sn_atten", txtatt.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@sn_att_mobile", txtattM.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@sn_email", txtemil.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@sn_country", ddctnm.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@sn_address", txtaddr.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@sn_crt_nm", Session["UID"]);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        scm_cnn.Open();
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        Mrcmd.Connection = scm_cnn;
        scm_cnn.Close();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        BindGVSUPPLIER();
        txtaddr.Text = "";
        txtatt.Text = "";
        txtattM.Text = "";
        txtemil.Text = "";
        txtsnm.Text = "";

    }

    protected void DDCOM2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVSUPPLIER();
    }



    protected void GVSUPPLIER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSUPPLIER.PageIndex = e.NewPageIndex;
        BindGVSUPPLIER();
    }

    protected void GVSUPPLIER_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int indx = int.Parse(e.CommandArgument.ToString());
            Label ext = (Label)GVSUPPLIER.Rows[indx].FindControl("lblbid");
            string Selectstatment = "select * from  Mr_Supplier_Name where sn_id='" + ext.Text + "'";
            DataTable dt = RADIDLL.get_SCMDataTable(Selectstatment);
            lbl2.Text = dt.Rows[0]["sn_id"].ToString();
            txtsnm.Text = dt.Rows[0]["sn_name"].ToString();
            txtatt.Text = dt.Rows[0]["sn_atten"].ToString();
            txtattM.Text = dt.Rows[0]["sn_att_mobile"].ToString();
            txtemil.Text = dt.Rows[0]["sn_email"].ToString();
            ddctnm.SelectedValue = dt.Rows[0]["sn_country"].ToString();
            txtaddr.Text = dt.Rows[0]["sn_address"].ToString();
            txtsnm.Enabled = false;
            BtnSupSave.Visible = false;
            BtnSupUpdate.Visible = true;


        }
    }


    protected void BtnSupUpdate_Click(object sender, EventArgs e)
    {

        scm_cnn.Open();
        //Label lbl = (Label)this.Master.FindControl("lbltotalinfo");
        string id = lbl2.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_SupplierName_Update", scm_cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@sup_id", id);

        //Mrcmd.Parameters.AddWithValue("@sup_nm", txtsnm.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@mob_num", txtmn.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@count_id", ddctnm.SelectedItem.Text);
        Mrcmd.Parameters.AddWithValue("@email", txtemil.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@sup_addr", txtaddr.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@atten", txtatt.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@att_mobile", txtattM.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@updt_unm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@upt_dt", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;

        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        Mrcmd.Connection = scm_cnn;
        scm_cnn.Close();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


        {

            txtaddr.Text = "";
            txtatt.Text = "";
            txtattM.Text = "";
            txtemil.Text = "";
            //txtmn.Text = "";
            txtsnm.Text = "";
            BtnSupSave.Visible = true;
            BtnSupUpdate.Visible = false;
            BindGVSUPPLIER();


        }
    }



    protected void BtnSupClear_Click(object sender, EventArgs e)
    {
        //DDCOM.Items.Clear();      
        ddctnm.Text = "";
        txtaddr.Text = "";
        txtatt.Text = "";
        txtattM.Text = "";
        txtemil.Text = "";
        //txtmn.Text = "";
        txtsnm.Text = "";
        message = "Clear Data Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    protected void txtSup_TextChanged(object sender, EventArgs e)
    {
        BindGVSUPPLIER();
    }
    private void BindGVSUPPLIER()
    {

        scm_cnn.Open();
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT*FROM Mr_Supplier_Name where  sn_name LIKE '%'+ @SUP + '%'";
            cmd.Connection = scm_cnn;
            cmd.Parameters.AddWithValue("SUP", txtSup.Text.Trim());
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
                GVSUPPLIER.DataSource = dt;
                GVSUPPLIER.DataBind();
            }
        }

        scm_cnn.Close();
    }
    protected void GVSUPPLIER_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Text = Regex.Replace(e.Row.Cells[3].Text, txtSup.Text.Trim(), delegate(Match match)
            {
                return string.Format("<span style = 'background-color:#ff0000'>{0}</span>", match.Value);
            }, RegexOptions.IgnoreCase);
        }
    }

    #endregion

    #region Item-Description-Subcategory

    protected void Bindddmcat1()
    {
        //ddmcat1.DataSource = RADIDLL.get_InformationdataTable("Select mc_id,mc_nm FROM Mr_MainCategory where mc_com='" + Session["ComID"] + "' order by mc_nm ");
        //ddmcat1.DataTextField = "mc_nm";
        //ddmcat1.DataValueField = "mc_id";
        //ddmcat1.DataBind();
        //ddmcat1.Items.Insert(0, "");
        //Bindgvsubcat();
    }

    protected void Bindddunit()
    {
        //ddunit.DataSource = RADIDLL.get_InformationdataTable("Select u_id,unit_nm FROM Mr_Unit");
        //ddunit.DataTextField = "unit_nm";
        //ddunit.DataValueField = "u_id";
        //ddunit.DataBind();
        //ddunit.Items.Insert(0, "");
    }

    protected void BtnItemDesSave_Click(object sender, EventArgs e)
    {

        cn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_SubCategorySave", cn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@mc_id", ddmcat1.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@sc_nm", txtscat.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ct_dt", DateTime.Now);
        Mrcmd.Parameters.AddWithValue("@ct_unm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@unit_code", ddunit.SelectedValue);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cn.Close();
        Bindgvsubcat();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {

            txtscat.Text = "";
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterSetup.aspx");
    }

    private void Bindgvsubcat()
    {
        //gvsubcat.DataSource = RADIDLL.get_InformationdataTable("SELECT*FROM Mr_SubCategoryView where mc_nm='" + ddmcat1.SelectedItem + "'order by sc_nm");
        //gvsubcat.DataBind();

        //GridView_Row_Merger(gvmaincat);
    }
    protected void ddmcat1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindgvsubcat();
    }
    protected void gvsubcat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvsubcat.PageIndex = e.NewPageIndex;
        Bindgvsubcat();
    }
    protected void BtnItemDesClear_Click(object sender, EventArgs e)
    {

        //ddmcat1.SelectedValue = "";
        //ddunit.SelectedValue = "";
        //txtscat.Text = "";
        //BtnItemDesUpdate.Visible = false;
        //BtnItemDesSave.Visible = true;
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    protected void gvsubcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow row = gvsubcat.SelectedRow;

        //txtid.Text = row.Cells[2].Text;
        //txtscat.Text = row.Cells[4].Text;
        //Label lblScat = (Label)row.FindControl("lblunit_id");
        //ddunit.SelectedValue = lblScat.Text;
        //Label lblmcat = (Label)row.FindControl("lblmc_id");
        //ddmcat1.SelectedValue = lblmcat.Text;
        //BtnItemDesSave.Visible = false;
        //BtnItemDesUpdate.Visible = true;

    }
    protected void BtnItemDesUpdate_Click(object sender, EventArgs e)
    {
        //cn.Open();

        //string id = txtid.Text;
        //SqlCommand moru = new SqlCommand("Mr_SubCategoryUpdate", cn);
        //moru.CommandType = CommandType.StoredProcedure;
        //moru.Parameters.AddWithValue("@sc_id", id);
        //moru.Parameters.AddWithValue("@mc_id", ddmcat1.SelectedValue);
        //moru.Parameters.AddWithValue("@sc_nm", txtscat.Text.Trim());
        //moru.Parameters.AddWithValue("@unit_code", ddunit.SelectedValue);
        //moru.Parameters.AddWithValue("@ct_dt", DateTime.Now);
        //moru.Parameters.AddWithValue("@ct_unm", Session["UID"]);
        //moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //moru.ExecuteNonQuery();
        //message = (string)moru.Parameters["@ERROR"].Value;
        //cn.Close();
        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //{

        //}
        //Bindgvsubcat();
        //BtnItemDesSave.Visible = true;
        //BtnItemDesUpdate.Visible = false;
        //ddmcat1.SelectedValue = "";
        //ddunit.SelectedValue = "";
        //txtscat.Text = "";

    }

    #endregion

    #region Size
    public void BindMainCat()
    {
        //DDITEMS.DataSource = RADIDLL.get_InformationdataTable("select mc_id, mc_nm from Mr_MainCategory where mc_com='" + Session["ComID"] + "' order by mc_nm");
        //DDITEMS.DataTextField = "mc_nm";
        //DDITEMS.DataValueField = "mc_id";
        //DDITEMS.DataBind();
        //DDITEMS.Items.Insert(0, "");
    }



    protected void DDITEMS_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Bindgvitemdes();
        //ddscat.DataSource = RADIDLL.get_InformationdataTable("select sc_id, sc_nm from Mr_SubCategory where mc_id='" + DDITEMS.SelectedValue + "' order by sc_nm");
        //ddscat.DataTextField = "sc_nm";
        //ddscat.DataValueField = "sc_id";
        //ddscat.DataBind();
        //ddscat.Items.Insert(0, "");
        //Bindgvitemdes();
        //BindTiles();


        if (DDITEMS.SelectedItem.Text == "Tiles")
        {
            txtL.Visible = true;
            txtW.Visible = true;
            txtSQF.Visible = true;
            lblL.Visible = true;
            lblSQF.Visible = true;
            lblW.Visible = true;
            //lbld.Visible = true;
            gvitemdes.Visible = false;
            GVTILES.Visible = true;
            BtnSizeSaveExt.Visible = false;
            BtnSizeSave.Visible = true;
            BtnSizeUpdateExt.Visible = false;
            txtides.Text = "";
            txtL.Text = "";
            txtW.Text = "";
            txtSQF.Text = "";


        }

        else
        {
            txtL.Visible = false;
            txtW.Visible = false;
            txtSQF.Visible = false;
            lblL.Visible = false;
            lblSQF.Visible = false;
            lblW.Visible = false;
            //lbld.Visible = false;
            gvitemdes.Visible = true;
            GVTILES.Visible = false;
            BtnSizeSaveExt.Visible = true;
            BtnSizeSave.Visible = false;
            BtnSizeUpdate.Visible = false;
            txtides.Text = "";


        }
    }

    protected void ddscat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    // Without Tiles View
    private void Bindgvitemdes()
    {
        gvitemdes.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT dbo.Mr_ItemDescription.des_id, dbo.Mr_ItemDescription.item_nm, Mr_Textile.dbo.Mr_MainCategory.mc_id, Mr_Textile.dbo.Mr_MainCategory.mc_nm, Mr_Textile.dbo.Mr_SubCategory.sc_id, Mr_Textile.dbo.Mr_SubCategory.sc_nm, dbo.Mr_ItemDescription.slength, dbo.Mr_ItemDescription.swidth, dbo.Mr_ItemDescription.ssqf, dbo.Mr_ItemDescription.crt_nm, dbo.Mr_ItemDescription.crt_dt FROM dbo.Mr_ItemDescription INNER JOIN Mr_Textile.dbo.Mr_MainCategory ON dbo.Mr_ItemDescription.mc_id = Mr_Textile.dbo.Mr_MainCategory.mc_id INNER JOIN Mr_Textile.dbo.Mr_SubCategory ON dbo.Mr_ItemDescription.sc_id = Mr_Textile.dbo.Mr_SubCategory.sc_id where Mr_Textile.dbo.Mr_MainCategory.mc_id='" + DDITEMS.SelectedValue + "'");
        gvitemdes.DataBind();

    }
    // Tiles View
    private void BindTiles()
    {

        GVTILES.DataSource = RADIDLL.get_SpecfoInventoryDataTable("SELECT dbo.Mr_ItemDescription.des_id, dbo.Mr_ItemDescription.item_nm, Mr_Textile.dbo.Mr_MainCategory.mc_id, Mr_Textile.dbo.Mr_MainCategory.mc_nm, Mr_Textile.dbo.Mr_SubCategory.sc_id, Mr_Textile.dbo.Mr_SubCategory.sc_nm, dbo.Mr_ItemDescription.slength, dbo.Mr_ItemDescription.swidth, dbo.Mr_ItemDescription.ssqf, dbo.Mr_ItemDescription.crt_nm, dbo.Mr_ItemDescription.crt_dt FROM dbo.Mr_ItemDescription INNER JOIN Mr_Textile.dbo.Mr_MainCategory ON dbo.Mr_ItemDescription.mc_id = Mr_Textile.dbo.Mr_MainCategory.mc_id INNER JOIN Mr_Textile.dbo.Mr_SubCategory ON dbo.Mr_ItemDescription.sc_id = Mr_Textile.dbo.Mr_SubCategory.sc_id where Mr_Textile.dbo.Mr_MainCategory.mc_nm='" + DDITEMS.SelectedItem + "'");
        GVTILES.DataBind();

    }

    // for tiles
    protected void BtnSizeSave_Click(object sender, EventArgs e)
    {
        cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_ItemDesSave", cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.CommandText = "Mr_DepartmentSave";

        Mrcmd.Parameters.AddWithValue("@mc_id", DDITEMS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@sc_id", ddscat.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@item_nm", txtides.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@slength", txtL.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@swidth", txtW.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ssqf", txtSQF.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@crt_nm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@crt_dt", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cnn.Close();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {

            txtides.Text = "";
        }

        BindTiles();
        BtnSizeUpdate.Visible = false;
        BtnSizeUpdateExt.Visible = false;

    }

    // for Others
    protected void BtnSizeSaveEx_Click(object sender, EventArgs e)
    {
        cnn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_ItemDesSave", cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.CommandText = "Mr_DepartmentSave";

        Mrcmd.Parameters.AddWithValue("@mc_id", DDITEMS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@sc_id", ddscat.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@item_nm", txtides.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@slength", 1);
        Mrcmd.Parameters.AddWithValue("@swidth", 1);
        Mrcmd.Parameters.AddWithValue("@ssqf", 1);
        Mrcmd.Parameters.AddWithValue("@crt_nm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@crt_dt", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cnn.Close();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {

            txtides.Text = "";
        }

        Bindgvitemdes();
        BtnSizeUpdateExt.Visible = false;
        //BtnSizeSave.Visible = false;
    }



    protected void BtnSizeClear_Click(object sender, EventArgs e)
    {
        txtides.Text = "";
        DDITEMS.SelectedValue = "";
        ddscat.SelectedValue = "";
        BtnSizeSave.Visible = true;
        BtnSizeUpdate.Visible = false;
        BtnSizeUpdateExt.Visible = false;
        BtnSizeSaveExt.Visible = false;
        message = "Clear Data Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void gvitemdes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvitemdes.PageIndex = e.NewPageIndex;
        Bindgvitemdes();

    }

    // Others Items
    protected void gvitemdes_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvitemdes.SelectedRow;
        txtSizeID.Text = row.Cells[2].Text;

        Label lblMainCate = (Label)row.FindControl("lbl_mc_id");
        DDITEMS.SelectedValue = lblMainCate.Text;

        Label lblSubCate = (Label)row.FindControl("lbl_Sub_cat");
        ddscat.SelectedValue = lblSubCate.Text;

        txtides.Text = row.Cells[5].Text;

        BtnSizeUpdate.Visible = false;
        BtnSizeSave.Visible = false;
        BtnSizeSaveExt.Visible = false;
        BtnSizeUpdateExt.Visible = true;
    }

    // for Tiles
    protected void GVTILES_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GVTILES.SelectedRow;
        txtid.Text = row.Cells[2].Text;

        Label lblMainCate = (Label)row.FindControl("lbl_mc_id");
        DDITEMS.SelectedValue = lblMainCate.Text;

        Label lblSubCate = (Label)row.FindControl("lbl_Sub_cat");
        ddscat.SelectedValue = lblSubCate.Text;

        txtides.Text = row.Cells[5].Text;
        txtL.Text = row.Cells[8].Text;
        txtW.Text = row.Cells[9].Text;
        txtSQF.Text = row.Cells[10].Text;

        BtnSizeUpdate.Visible = true;
        BtnSizeSave.Visible = false;
        BtnSizeSaveExt.Visible = false;
        BtnSizeUpdateExt.Visible = false;
    }

    // for tiles
    protected void BtnSizeUpdate_Click(object sender, EventArgs e)
    {
        cnn.Open();
        string id = txtSizeID.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_ItemDesUpdate", cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@des_id", id);
        Mrcmd.Parameters.AddWithValue("@mc_id", DDITEMS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@sc_id", ddscat.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@item_nm", txtides.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@slength", txtL.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@swidth", txtW.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@ssqf", txtSQF.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@crt_nm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@crt_dt", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cnn.Close();
        Bindgvitemdes();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {

            txtides.Text = "";
            BtnSizeUpdate.Visible = false;
            BtnSizeSave.Visible = true;
        }

        BindTiles();
    }

    // for other item

    protected void BtnSizeUpdateExt_Click(object sender, EventArgs e)
    {
        cnn.Open();
        string id = txtSizeID.Text;
        SqlCommand Mrcmd = new SqlCommand("Mr_ItemDesUpdate", cnn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@des_id", id);
        Mrcmd.Parameters.AddWithValue("@mc_id", DDITEMS.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@sc_id", ddscat.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@item_nm", txtides.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@slength", 1);
        Mrcmd.Parameters.AddWithValue("@swidth", 1);
        Mrcmd.Parameters.AddWithValue("@ssqf", 1);
        Mrcmd.Parameters.AddWithValue("@crt_nm", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@crt_dt", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cnn.Close();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        Bindgvitemdes();

        {

            txtides.Text = "";
            BtnSizeUpdate.Visible = false;
            BtnSizeSave.Visible = true;
            BtnSizeUpdateExt.Visible = false;
        }

        Bindgvitemdes();
    }


    protected void GVTILES_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVTILES.PageIndex = e.NewPageIndex;
        BindTiles();
    }

    #endregion

    #region Brand

    public void BindCOMPANY3()
    {
        //DDCOM3.DataSource = RADIDLL.get_InformationdataTable("select com_id,com_nm from Mr_Company where cmpt=1 and com_nm='" + Session["CompanyID"] + "'");
        //DDCOM3.DataTextField = "com_nm";
        //DDCOM3.DataValueField = "com_id";
        //DDCOM3.DataBind();
        //DDCOM3.Items.Insert(0, "");

    }
    protected void BtnBrandSave_Click(object sender, EventArgs e)
    {
        //Label lbl = (Label)this.Master.FindControl("lbltotalinfo");
        cn.Open();
        SqlCommand Mrcmd = new SqlCommand("Mr_BandSave", cn);
        Mrcmd.CommandType = CommandType.StoredProcedure;
        Mrcmd.Parameters.AddWithValue("@b_com", DDCOM3.SelectedValue);
        Mrcmd.Parameters.AddWithValue("@b_nm", textband.Text.Trim());
        Mrcmd.Parameters.AddWithValue("@b_ct_um", Session["UID"]);
        Mrcmd.Parameters.AddWithValue("@b_ct_dt", DateTime.Now);
        Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        Mrcmd.ExecuteNonQuery();
        message = (string)Mrcmd.Parameters["@ERROR"].Value;
        cn.Close();

        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {
            textband.Text = "";
        }

        Bindgvband();
    }
    protected void DDCOM3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindgvband();
    }
    private void Bindgvband()
    {
        //gvband.DataSource = RADIDLL.get_InformationdataTable("SELECT*FROM Mr_Band where b_com='" + Session["ComID"] + "'");
        //gvband.DataBind();
    }


    protected void gvband_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvband.PageIndex = e.NewPageIndex;
        //Bindgvband();
    }

    protected void gvband_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Select")
        //{
        //    int indx = int.Parse(e.CommandArgument.ToString());
        //    Label ext = (Label)gvband.Rows[indx].FindControl("lblbid");
        //    string Selectstatment = "select b_id,b_nm,b_com from Mr_Band where b_id='" + ext.Text + "'";
        //    DataTable dt = RADIDLL.get_InformationdataTable(Selectstatment);
        //    txtbrandid.Text = dt.Rows[0]["b_id"].ToString();
        //    textband.Text = dt.Rows[0]["b_nm"].ToString();
        //    DDCOM3.SelectedValue = dt.Rows[0]["b_com"].ToString();
        //    BtnBrandSave.Visible = false;
        //    BtnBrandUpdate.Visible = true;

        //}
    }


    protected void BtnBrandUpdate_Click(object sender, EventArgs e)
    {

        //cn.Open();
        ////Label lbl = (Label)this.Master.FindControl("lbltotalinfo");
        //string id = txtbrandid.Text;
        //SqlCommand moru = new SqlCommand("Mr_BandUpdate", cn);
        //moru.CommandType = CommandType.StoredProcedure;
        //moru.Parameters.AddWithValue("@b_id", id);
        //moru.Parameters.AddWithValue("@b_nm", textband.Text.Trim());
        //moru.Parameters.AddWithValue("@b_ct_dt", DateTime.Now);
        //moru.Parameters.AddWithValue("@b_ct_um", Session["UID"]);
        //moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //moru.ExecuteNonQuery();
        //message = (string)moru.Parameters["@ERROR"].Value;
        //cn.Close();
        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //{

        //    textband.Text = "";
        //    BtnBrandSave.Visible = true;
        //    BtnBrandUpdate.Visible = false;
        //    Bindgvband();

        //}
    }

    protected void BtnBrandClear_Click(object sender, EventArgs e)
    {
        //DDCOM3.SelectedValue = "";
        //textband.Text = "";
        //txtbrandid.Text = "";
        //BtnBrandUpdate.Visible = false;
        //BtnBrandSave.Visible = true;
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }
    #endregion

    #region Supplier Code

    public void SupplierCode()
    {
        ddsupplierc.DataSource = RADIDLL.get_SCMDataTable("select sup_id,SupName from Mr_Suppliers_Name_Code where sup_code_gen=0 Order by SupName");
        ddsupplierc.DataTextField = "SupName";
        ddsupplierc.DataValueField = "sup_id";
        ddsupplierc.DataBind();
        ddsupplierc.Items.Insert(0, "");

    }

    protected void ddsupplierc_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(ddsupplierc.SelectedValue))
        {
            string j, k;
            DataSet ds = RADIDLL.get_SCMDataSet("select sup_id from Mr_Suppliers_Name_Code where sup_id='" + ddsupplierc.SelectedValue + "'");
            string s = ds.Tables[0].Rows[0]["sup_id"].ToString();
            k = (int.Parse(s) + 3*13).ToString();
            if (k.Length < 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    j = "0" + k;
                    k = j;
                    if (j.Length == 5)
                    {
                        txtsupcode.Text = "DG" + ddsupplierc.SelectedValue + k;
                    }
                }
            }
        }
        else
        {
            txtsupcode.Text = "";
        }
    }
    protected void BtnsupcodSave_Click(object sender, EventArgs e)
    {

        scm_cnn.Open();
        string id = ddsupplierc.SelectedValue;
        SqlCommand moru = new SqlCommand("Mr_Suppliers_Name_Code_Update", scm_cnn);
        moru.CommandType = CommandType.StoredProcedure;
        moru.Parameters.AddWithValue("@sup_id", id);
        moru.Parameters.AddWithValue("@SupCode", txtsupcode.Text.Trim());
        moru.Parameters.AddWithValue("@sup_crt_dt", DateTime.Now);
        moru.Parameters.AddWithValue("@sup_crt_user", Session["UID"]);
        moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        moru.ExecuteNonQuery();
        message = (string)moru.Parameters["@ERROR"].Value;
        scm_cnn.Close();
        //message = "Save Successfully";
        ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void BtnsupcodClear_Click(object sender, EventArgs e)
    {
        txtsupcode.Text = "";
        ddsupplierc.Text = "";

    }
 
    #endregion

    #region Unit
    protected void BtnUnitSave_Click(object sender, EventArgs e)
    {

        //cn.Open();
        //SqlCommand Mrcmd = new SqlCommand("Mr_UnitSave", cn);
        //Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@unit_nm", textdia.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@u_ct_unm", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("@u_ct_dt", DateTime.Now);
        //Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //Mrcmd.ExecuteNonQuery();
        //message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //cn.Close();

        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


        //{
        //    textdia.Text = "";
        //}
        //BindUnit();
    }



    private void BindUnit()
    {
        //gvdia.DataSource = RADIDLL.get_InformationdataTable("SELECT*FROM Mr_Unit order by unit_nm");
        //gvdia.DataBind();

    }


    protected void gvdia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvdia.PageIndex = e.NewPageIndex;
        //BindUnit();

    }


    protected void BtnUnitUpdate_Click(object sender, EventArgs e)
    {

        //cn.Open();

        //string id = txtdiaid.Text;
        //SqlCommand moru = new SqlCommand("Mr_UnitUpdate", cn);
        //moru.CommandType = CommandType.StoredProcedure;
        //moru.Parameters.AddWithValue("@u_id", id);
        //moru.Parameters.AddWithValue("@unit_nm", textdia.Text.Trim());
        //moru.Parameters.AddWithValue("@u_ct_dt", DateTime.Now);
        //moru.Parameters.AddWithValue("@u_ct_unm", Session["UID"]);
        //moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //moru.ExecuteNonQuery();
        //message = (string)moru.Parameters["@ERROR"].Value;
        //cn.Close();
        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //{

        //    textdia.Text = "";
        //    BtnUnitSave.Visible = true;
        //    BtnUnitUpdate.Visible = false;
        //    BindUnit();

        //}
    }
    protected void gvdia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Select")
        //{
        //    int indx = int.Parse(e.CommandArgument.ToString());
        //    Label ext = (Label)gvdia.Rows[indx].FindControl("lblDid");
        //    string Selectstatment = "select u_id,unit_nm from Mr_Unit where u_id='" + ext.Text + "'";
        //    DataTable dt = RADIDLL.get_InformationdataTable(Selectstatment);
        //    txtdiaid.Text = dt.Rows[0]["u_id"].ToString();
        //    textdia.Text = dt.Rows[0]["unit_nm"].ToString();
        //    BtnUnitSave.Visible = false;
        //    BtnUnitUpdate.Visible = true;

        //}
    }
    protected void BtnUnitClear_Click(object sender, EventArgs e)
    {
        //BtnUnitUpdate.Visible = false;
        //BtnUnitSave.Visible = true;
        //txtdiaid.Text = "";
        //textdia.Text = "";
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


    }

    #endregion


    #region Button Permission

    public void bind()
    {
        //DropDownList1.DataSource = RADIDLL.get_InformationdataTable("select midd_nm,full_nm from Mr_UserInfo where user_act_inact='Active' order by full_nm");
        //DropDownList1.DataTextField = "full_nm";
        //DropDownList1.DataValueField = "midd_nm";
        //DropDownList1.DataBind();
        //DropDownList1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
        //DropDownList1.SelectedIndex = 0;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ////lblBtPerSave.Enabled = false;
        ////lblBtPerSave.CssClass = "form-control form-control-sm";
        //GridView1.DataSource = null;
        //GridView1.DataBind();
        //if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
        //{

        //    DataTable dtgetStatus = RADIDLL.get_InformationdataTable("select user_st,usergp_id from Mr_UserInfo where midd_nm='" + DropDownList1.SelectedValue + "' and user_act_inact='Active'");
        //    string Userwise = dtgetStatus.Rows[0]["user_st"].ToString();
        //    string grp = dtgetStatus.Rows[0]["usergp_id"].ToString();
        //    lblbtp1.Text = Userwise;
        //    lblbtp2.Text = grp;
        //    if (!string.IsNullOrEmpty(Userwise))
        //    {
        //        DataTable dtmodule = RADIDLL.get_InformationdataTable("Sp_Mr_Userpermissionbtn '" + DropDownList1.SelectedValue + "'," + grp + ",'" + Userwise + "'");
        //        GridView1.DataSource = dtmodule;
        //        GridView1.DataBind();
        //        if (GridView1.Rows.Count > 0)
        //        {
        //            foreach (DataRow drr in dtmodule.Rows)
        //            {
        //                foreach (GridViewRow rows in GridView1.Rows)
        //                {
        //                    Label lblModule = (Label)rows.FindControl("lblModule");
        //                    string ss = lblModule.Text.Trim();
        //                    if (ss == drr[0].ToString())
        //                    {
        //                        CheckBox chkModule = (CheckBox)rows.FindControl("chkModule");
        //                        chkModule.Checked = true;
        //                        GridView grdFormName = (GridView)rows.FindControl("grdFormName");
        //                        DataTable dtform = RADIDLL.get_InformationdataTable("Sp_Mr_Userpermissionbtnformname '" + DropDownList1.SelectedValue + "'," + lblbtp2.Text + ",'" + lblbtp1.Text + "','" + lblModule.Text + "'");
        //                        grdFormName.DataSource = dtform;
        //                        grdFormName.DataBind();
        //                        foreach (DataRow drform in dtmodule.Rows)
        //                        {
        //                            foreach (GridViewRow rowsform in grdFormName.Rows)
        //                            {
        //                                CheckBox chkForm = (CheckBox)rowsform.FindControl("chkForm");
        //                                chkForm.Checked = true;
        //                                GridView grdButton = (GridView)rowsform.FindControl("grdButton");
        //                                Label lblformurl = (Label)rowsform.FindControl("lblformurl");
        //                                DataTable dtgetButton = RADIDLL.get_InformationdataTable("select Btn_Name,Btn_Text from Mr_Button where Form_Name='" + lblformurl.Text.Trim() + "' order by Btn_Text");
        //                                grdButton.DataSource = dtgetButton;
        //                                grdButton.DataBind();

        //                                DataTable dtgetusr = RADIDLL.get_InformationdataTable("select UserName from Mr_permitterbtn where UserName='" + DropDownList1.SelectedValue + "'");
        //                                if (dtgetusr.Rows.Count > 0)
        //                                {
        //                                    DataTable getPermittedbutton = RADIDLL.get_InformationdataTable("select ButtonName from Mr_permitterbtn where FormName='" + lblformurl.Text + "' and UserName='" + DropDownList1.SelectedValue + "'");
        //                                    if (getPermittedbutton.Rows.Count > 0)
        //                                    {
        //                                        foreach (DataRow drbtn in getPermittedbutton.Rows)
        //                                        {
        //                                            foreach (GridViewRow rowsbtn in grdButton.Rows)
        //                                            {
        //                                                Label lblbtn = (Label)rowsbtn.FindControl("lblbtn");
        //                                                string btnnm = lblbtn.Text.Trim();
        //                                                if (btnnm == drbtn[0].ToString())
        //                                                {
        //                                                    CheckBox chkButton = (CheckBox)rowsbtn.FindControl("chkButton");
        //                                                    chkButton.Checked = true;
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    foreach (GridViewRow rowsbtn in grdButton.Rows)
        //                                    {
        //                                        CheckBox chkButton = (CheckBox)rowsbtn.FindControl("chkButton");
        //                                        chkButton.Checked = true;
        //                                    }
        //                                }

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //}
        //if (GridView1.Rows.Count > 0)
        //{
        //    //lblBtPerSave.Enabled = true;
        //    //lblBtPerSave.CssClass = "form-control form-control-sm";
        //}
    }
    protected void chkModule_CheckedChanged(object sender, EventArgs e)
    {
        //GridViewRow row = ((CheckBox)sender).Parent.Parent as GridViewRow;
        //CheckBox chkModule = (CheckBox)row.FindControl("chkModule");
        //Label lblModule = (Label)row.FindControl("lblModule");
        //GridView grdform = (GridView)row.FindControl("grdFormName");
        //grdform.DataSource = null;
        //grdform.DataBind();
        //if (chkModule.Checked == true)
        //{
        //    DataSet ds = RADIDLL.get_InformationDataSet("Sp_Mr_Userpermissionbtnformname '" + DropDownList1.SelectedValue + "'," + lblbtp2.Text + ",'" + lblbtp1.Text + "','" + lblModule.Text + "'");
        //    grdform.DataSource = ds;
        //    grdform.DataBind();
        //}
    }
    protected void chkForm_CheckedChanged(object sender, EventArgs e)
    {
        //GridViewRow row = ((CheckBox)sender).Parent.Parent as GridViewRow;
        //CheckBox chkModule = (CheckBox)row.FindControl("chkForm");
        //Label lblformurl = (Label)row.FindControl("lblformurl");
        //GridView grdform = (GridView)row.FindControl("grdButton");
        //grdform.DataSource = null;
        //grdform.DataBind();
        //if (chkModule.Checked == true)
        //{
        //    DataSet ds = RADIDLL.get_InformationDataSet("select Btn_Name,Btn_Text from Mr_Button where Form_Name='" + lblformurl.Text.Trim() + "' order by Btn_Text");
        //    grdform.DataSource = ds;
        //    grdform.DataBind();
        //}
    }
    protected void lblBtPerSave_Click(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
        //{
        //    //RADIDLL.Delete_btnperm(DropDownList1.SelectedValue);
        //    if (GridView1.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < GridView1.Rows.Count; i++)
        //        {
        //            CheckBox chkModule = (CheckBox)GridView1.Rows[i].FindControl("chkModule");
        //            if (chkModule.Checked == true)
        //            {
        //                Label lblModule = (Label)GridView1.Rows[i].FindControl("lblModule");
        //                GridView grdFormName = (GridView)GridView1.Rows[i].FindControl("grdFormName");
        //                for (int j = 0; j < grdFormName.Rows.Count; j++)
        //                {
        //                    CheckBox chkForm = (CheckBox)grdFormName.Rows[j].FindControl("chkForm");
        //                    if (chkForm.Checked == true)
        //                    {
        //                        Label lblform = (Label)grdFormName.Rows[j].FindControl("lblformurl");
        //                        GridView grdButton = (GridView)grdFormName.Rows[j].FindControl("grdButton");
        //                        for (int k = 0; k < grdButton.Rows.Count; k++)
        //                        {
        //                            CheckBox chkButton = (CheckBox)grdButton.Rows[k].FindControl("chkButton");
        //                            if (chkButton.Checked == true)
        //                            {
        //                                Label lblbtn = (Label)grdButton.Rows[k].FindControl("lblbtn");
        //                                //RADIDLL.Save_btnperm(DropDownList1.SelectedValue, lblform.Text, lblbtn.Text, "", "1", lblModule.Text, lblErrormsg);

        //                                message = "Save Successfully";
        //                                ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //                            }

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

            //GridView1.DataSource = null;
            //GridView1.DataBind();
            //DropDownList1.SelectedIndex = 0;
            //lblbtp1.Text = "";
            //lblbtp2.Text = "";
            //// DropDownList1_SelectedIndexChanged(null, null);

        //}
    }
    protected void grdFormName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Width = 25;
            e.Row.Cells[1].Width = 175;
        }
    }
    protected void grdButton_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Width = 25;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Width = 30;
            e.Row.Cells[1].Width = 130;
        }
    }
    protected void lblBtPerClear_Click(object sender, EventArgs e)
    {
        //GridView1.DataSource = null;
        //GridView1.DataBind();
        //DropDownList1.SelectedIndex = 0;

        //lblbtp1.Text = "";
        //lblbtp2.Text = "";
        ////lblBtPerSave.Enabled = false;
        ////lblBtPerSave.CssClass = "form-control form-control-sm";
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    #endregion

    #region Accounts ID

    protected void Transectiontype()
    {
        //DDTT.DataSource = RADIDLL.get_InformationdataTableInventory("Select DISTINCT tr_id,tr_descrip FROM Mr_Acc_Transection_Type order by tr_descrip");
        //DDTT.DataTextField = "tr_descrip";
        //DDTT.DataValueField = "tr_id";
        //DDTT.DataBind();
        //DDTT.Items.Insert(0, "");

    }

    protected void DDTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        Accountstype();
    }

    protected void Accountstype()
    {
        //DDAT.DataSource = RADIDLL.get_InformationdataTableInventory("Select DISTINCT acct_id,acct_des FROM Mr_Accounts_Type where acct_tr_type='" + DDTT.SelectedValue + "' order by acct_des");
        //DDAT.DataTextField = "acct_des";
        //DDAT.DataValueField = "acct_id";
        //DDAT.DataBind();
        //DDAT.Items.Insert(0, "");
        //BINDGVTT();
    }


    protected void BtnAccountIDSave_Click(object sender, EventArgs e)
    {

        //cnn.Open();
        //SqlCommand Mrcmd = new SqlCommand("Mr_Accounts_ID_Save", cnn);
        //Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@offc_desc", txtAID.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@offc_acc_type", DDAT.SelectedItem.Text);
        //Mrcmd.Parameters.AddWithValue("@offc_tr_type", DDTT.SelectedValue);
        //Mrcmd.Parameters.AddWithValue("@offc_crt_nm", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("@offc_com_id", Session["ComID"]);
        //Mrcmd.Parameters.AddWithValue("@offc_dt", DateTime.Now);
        //Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //Mrcmd.ExecuteNonQuery();
        //message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //cnn.Close();
        //BINDGVTT();
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        //{

        //    txtAID.Text = "";
        //}
    }


    private void BINDGVTT()
    {
        //GVTT.DataSource = RADIDLL.get_InformationdataTableInventory("SELECT  dbo.Mr_Acc_Transection_Type.tr_id, dbo.Mr_Acc_Transection_Type.tr_descrip, dbo.Mr_Accounts_Type.acct_id, dbo.Mr_Accounts_Type.acct_des, dbo.Mr_Officel_Cost.offc_id, dbo.Mr_Officel_Cost.offc_desc,dbo.Mr_Officel_Cost.offc_crt_nm, dbo.Mr_Officel_Cost.offc_dt FROM  dbo.Mr_Acc_Transection_Type INNER JOIN dbo.Mr_Accounts_Type ON dbo.Mr_Acc_Transection_Type.tr_id = dbo.Mr_Accounts_Type.acct_tr_type INNER JOIN dbo.Mr_Officel_Cost ON dbo.Mr_Accounts_Type.acct_des = dbo.Mr_Officel_Cost.offc_acc_type AND dbo.Mr_Acc_Transection_Type.tr_id = dbo.Mr_Officel_Cost.offc_tr_type where offc_com_id='" + Session["ComID"] + "' GROUP BY dbo.Mr_Acc_Transection_Type.tr_id, dbo.Mr_Acc_Transection_Type.tr_descrip, dbo.Mr_Accounts_Type.acct_id, dbo.Mr_Accounts_Type.acct_des, dbo.Mr_Officel_Cost.offc_id, dbo.Mr_Officel_Cost.offc_desc,dbo.Mr_Officel_Cost.offc_crt_nm, dbo.Mr_Officel_Cost.offc_dt ORDER BY dbo.Mr_Acc_Transection_Type.tr_id");
        //GVTT.DataBind();
    }

    protected void DDAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BINDGVTT();
    }

    protected void GVTT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GVTT.PageIndex = e.NewPageIndex;
        //BINDGVTT();
    }

    protected void BtnAccountIDClear_Click(object sender, EventArgs e)
    {
        //DDTT.SelectedValue = "";
        //DDAT.SelectedValue = "";
        //txtAID.Text = "";
        //BtnAccountIDUpdate.Visible = false;
        //BtnAccountIDSave.Visible = true;
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }

    protected void GVTT_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow row = GVTT.SelectedRow;
        //txtacid.Text = row.Cells[2].Text;
        //Label TrType = (Label)row.FindControl("lbltr");
        //DDTT.SelectedValue = TrType.Text;
        //DDTT_SelectedIndexChanged(null, null);
        //Label AccountID = (Label)row.FindControl("lblacc_id");
        //DDAT.SelectedValue = AccountID.Text;
        //txtAID.Text = row.Cells[5].Text;
        //BtnAccountIDSave.Visible = false;
        //BtnAccountIDUpdate.Visible = true;

    }

    protected void BtnAccountIDUpdate_Click(object sender, EventArgs e)
    {
        //cnn.Open();

        //string id = txtacid.Text;
        //SqlCommand moru = new SqlCommand("Mr_Accounts_ID_Update", cnn);
        //moru.CommandType = CommandType.StoredProcedure;
        //moru.Parameters.AddWithValue("@offc_id", id);
        //moru.Parameters.AddWithValue("@offc_desc", txtAID.Text.Trim());
        //moru.Parameters.AddWithValue("@offc_acc_type", DDAT.SelectedItem.Text);
        //moru.Parameters.AddWithValue("@offc_tr_type", DDTT.SelectedValue);
        //moru.Parameters.AddWithValue("@offc_crt_nm", Session["UID"]);
        //moru.Parameters.AddWithValue("@offc_com_id", Session["ComID"]);
        //moru.Parameters.AddWithValue("@offc_dt", DateTime.Now);
        //moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //moru.ExecuteNonQuery();
        //message = (string)moru.Parameters["@ERROR"].Value;
        //cnn.Close();

        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {
            //BINDGVTT();
            //BtnAccountIDSave.Visible = true;
            //BtnAccountIDUpdate.Visible = false;
            //DDAT.SelectedValue = "";
            //txtAID.Text = "";

        }


    }

    #endregion

    #region Bank

    public void BindCOMPANY4()
    {
        //DDCOM4.DataSource = RADIDLL.get_InformationdataTable("select com_id,com_nm from Mr_Company where cmpt=1 and com_nm='" + Session["CompanyID"] + "'");
        //DDCOM4.DataTextField = "com_nm";
        //DDCOM4.DataValueField = "com_id";
        //DDCOM4.DataBind();
        //DDCOM4.Items.Insert(0, "");

    }

    protected void BtnBankSave_Click(object sender, EventArgs e)
    {

        //cn.Open();
        //SqlCommand Mrcmd = new SqlCommand("Mr_BankNamesSave", cn);
        //Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@bk_com", DDCOM4.SelectedValue);
        //Mrcmd.Parameters.AddWithValue("@bk_acc_name", txtaccName.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_name", txtbank.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_branch", txtbranch.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_ac_no", txtacno.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_ac_type", txtact.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_cus_id", txtCid.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_limit", txtlimit.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_interest", txtint.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_t_year", txtyr.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@bk_t_interest", txtttinterest.Text.Trim());

        //Mrcmd.Parameters.AddWithValue("@bk_user", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("@bk_crt_date", DateTime.Now);
        //Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //Mrcmd.ExecuteNonQuery();
        //message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //cn.Close();

        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {
            //txtaccName.Text = "";
            //txtacno.Text = "";
            //txtact.Text = "";
            //txtbank_id.Text = "";
            //txtbank.Text = "";
            //txtbranch.Text = "";
            //txtCid.Text = "";
            //txtlimit.Text = "";
            //txtint.Text = "";
            //txtyr.Text = "";
            //txtttinterest.Text = "";
        }

        BindGVBANK();
    }

    protected void DDCOM4_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGVBANK();
    }

    private void BindGVBANK()
    {
        //GVBANK.DataSource = RADIDLL.get_InformationdataTable("SELECT*FROM Mr_BankNames where bk_com='" + Session["ComID"] + "'");
        //GVBANK.DataBind();
    }


    protected void GVBANK_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GVBANK.PageIndex = e.NewPageIndex;
        //BindGVBANK();
    }

    protected void GVBANK_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int indx = int.Parse(e.CommandArgument.ToString());
            //Label ext = (Label)GVBANK.Rows[indx].FindControl("lblbid");
            //string Selectstatment = "select bk_id,bk_acc_name,bk_name,bk_branch,bk_ac_no,bk_ac_type,bk_cus_id,bk_limit,bk_interest,bk_t_year,bk_t_interest from Mr_BankNames where bk_id='" + ext.Text + "'";
            //DataTable dt = RADIDLL.get_InformationdataTable(Selectstatment);
            //txtbank_id.Text = dt.Rows[0]["bk_id"].ToString();
            //txtaccName.Text = dt.Rows[0]["bk_acc_name"].ToString();
            //txtbank.Text = dt.Rows[0]["bk_name"].ToString();
            //txtbranch.Text = dt.Rows[0]["bk_branch"].ToString();
            //txtacno.Text = dt.Rows[0]["bk_ac_no"].ToString();
            //txtact.Text = dt.Rows[0]["bk_ac_type"].ToString();
            //txtCid.Text = dt.Rows[0]["bk_cus_id"].ToString();
            //txtlimit.Text = dt.Rows[0]["bk_limit"].ToString();
            //txtint.Text = dt.Rows[0]["bk_interest"].ToString();
            //txtyr.Text = dt.Rows[0]["bk_t_year"].ToString();
            //txtttinterest.Text = dt.Rows[0]["bk_t_interest"].ToString();
            //BtnBankSave.Visible = false;
            //BtnBankUpdate.Visible = true;


        }
    }


    protected void BtnBankUpdate_Click(object sender, EventArgs e)
    {

        //cn.Open();
        //string id = txtbank_id.Text;
        //SqlCommand moru = new SqlCommand("Mr_BankNamesUpdate", cn);
        //moru.CommandType = CommandType.StoredProcedure;
        //moru.Parameters.AddWithValue("@bk_id", id);
        //moru.Parameters.AddWithValue("@bk_acc_name", txtaccName.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_name", txtbank.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_branch", txtbranch.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_ac_no", txtacno.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_ac_type", txtact.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_cus_id", txtCid.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_limit", txtlimit.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_interest", txtint.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_t_year", txtyr.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_t_interest", txtttinterest.Text.Trim());
        //moru.Parameters.AddWithValue("@bk_crt_date", DateTime.Now);
        //moru.Parameters.AddWithValue("@bk_user", Session["UID"]);
        //moru.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //moru.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //moru.ExecuteNonQuery();
        //message = (string)moru.Parameters["@ERROR"].Value;
        //cn.Close();
        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {
            //txtaccName.Text = "";
            //txtacno.Text = "";
            //txtact.Text = "";
            //txtbank_id.Text = "";
            //txtbank.Text = "";
            //txtbranch.Text = "";
            //txtCid.Text = "";
            //txtlimit.Text = "";
            //txtint.Text = "";
            //txtyr.Text = "";
            //txtttinterest.Text = "";
            //BtnBankSave.Visible = true;
            //BtnBankUpdate.Visible = false;
            //BindGVBANK();

        }
    }

    protected void BtnBankClear_Click(object sender, EventArgs e)
    {
        //txtaccName.Text = "";
        //txtacno.Text = "";
        //txtact.Text = "";
        //txtbank_id.Text = "";
        //txtbank.Text = "";
        //txtbranch.Text = "";
        //txtCid.Text = "";
        //txtlimit.Text = "";
        //txtint.Text = "";
        //txtyr.Text = "";
        //txtttinterest.Text = "";
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);


    }
    #endregion

    #region Customer Info
    public void BindCOMPANY5()
    {
        //DDCOM5.DataSource = RADIDLL.get_InformationdataTable("select com_id,com_nm from Mr_Company where cmpt=1 and com_nm='" + Session["CompanyID"] + "'");
        //DDCOM5.DataTextField = "com_nm";
        //DDCOM5.DataValueField = "com_id";
        //DDCOM5.DataBind();
        //DDCOM5.Items.Insert(0, "");

    }


    protected void DDCOM5_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindGVSRINFO();
    }

    protected void BtnCusInfoSave_Click(object sender, EventArgs e)
    {

        //cnn.Open();
        //SqlCommand Mrcmd = new SqlCommand("Mr_Customer_Info_Save", cnn);
        //Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@cus_com", DDCOM5.SelectedValue);
        //Mrcmd.Parameters.AddWithValue("@cus_name", txtFullNm.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_nid", txtNID.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_mobile", txtmobile.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_page_no", txtPNo.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_mail", txtmail.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_present_addr", txtpresntaddr.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_permanent_addr", txtpermntaddr.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_ref_name", txtRef_nm.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_ref_mobile", txtRef_mo.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_crt_nm", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("@cus_crt_dt", DateTime.Now);
        //Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //Mrcmd.ExecuteNonQuery();
        //message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //cnn.Close();


        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {
            //txtFullNm.Text = "";
            //txtmobile.Text = "";
            //txtNID.Text = "";
            //txtpresntaddr.Text = "";
            //txtpermntaddr.Text = "";
            //txtRef_mo.Text = "";
            //txtRef_nm.Text = "";
            //txtPNo.Text = "";


        }

    }


    protected void txtCus_TextChanged(object sender, EventArgs e)
    {
        //BindGVSRINFO();
    }

    private void BindGVSRINFO()
    {

        //SqlConnection cnn = moruGetway.moruinvenconn;
        //if (cnn.State == ConnectionState.Closed || cnn.State == ConnectionState.Broken)
        //{
        //    cnn.Open();

        //}
        //using (SqlCommand cmd = new SqlCommand())
        //{
        //    cmd.CommandText = "SELECT [cus_id],[cus_name],[cus_nid],[cus_mobile],[cus_present_addr],[cus_permanent_addr],[cus_ref_name],[cus_ref_mobile],[cus_page_no],[cus_crt_nm],[cus_crt_dt]FROM [dbo].[Mr_Customer_Info] where cus_com='" + DDCOM5.SelectedValue + "' and cus_name LIKE '%'+ @SUP + '%' order by cus_name";
        //    cmd.Connection = cnn;
        //    cmd.Parameters.AddWithValue("SUP", txtCus.Text.Trim());
        //    DataTable dt = new DataTable();
        //    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //    {
        //        sda.Fill(dt);
        //        GVSRINFO.DataSource = dt;
        //        GVSRINFO.DataBind();
        //    }
        //}

        //if (cnn.State == ConnectionState.Open)
        //{
        //    cnn.Close();

        //}

    }

    protected void GVSRINFO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].Text = Regex.Replace(e.Row.Cells[2].Text, txtCus.Text.Trim(), delegate(Match match)
        //    {
        //        return string.Format("<span style = 'background-color:#ff0000'>{0}</span>", match.Value);
        //    }, RegexOptions.IgnoreCase);
        //}
    }


    protected void GVSRINFO_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GVSRINFO.PageIndex = e.NewPageIndex;
        //BindGVSRINFO();
    }


    protected void GVSRINFO_SelectedIndexChanged(object sender, EventArgs e)
    {

        //GridViewRow row = GVSRINFO.SelectedRow;
        //txtcl_id.Text = row.Cells[1].Text;
        //txtFullNm.Text = row.Cells[2].Text;
        //txtmobile.Text = row.Cells[3].Text;
        //txtNID.Text = row.Cells[4].Text;
        //txtpresntaddr.Text = row.Cells[5].Text;
        //txtpermntaddr.Text = row.Cells[6].Text;
        //btnsave.Visible = false;
        //btnupdt.Visible = true;
        //lbl1.Text = "";
    }

    protected void BtnCusInfoUpdate_Click(object sender, EventArgs e)
    {
        //cnn.Open();

        //string id = lblcusID.Text;
        //SqlCommand Mrcmd = new SqlCommand("Mr_Customer_Info_Update", cnn);
        //Mrcmd.CommandType = CommandType.StoredProcedure;
        //Mrcmd.Parameters.AddWithValue("@cus_id", id);
        //Mrcmd.Parameters.AddWithValue("@cus_com", DDCOM5.SelectedValue);
        //Mrcmd.Parameters.AddWithValue("@cus_name", txtFullNm.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_nid", txtNID.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_mobile", txtmobile.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_page_no", txtPNo.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_mail", txtmail.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_present_addr", txtpresntaddr.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_permanent_addr", txtpermntaddr.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_ref_name", txtRef_nm.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_ref_mobile", txtRef_mo.Text.Trim());
        //Mrcmd.Parameters.AddWithValue("@cus_crt_nm", Session["UID"]);
        //Mrcmd.Parameters.AddWithValue("@cus_crt_dt", DateTime.Now);
        //Mrcmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
        //Mrcmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
        //Mrcmd.ExecuteNonQuery();
        //message = (string)Mrcmd.Parameters["@ERROR"].Value;
        //cnn.Close();
        ////message = "Save Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.success('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

        {

            //BtnCusInfoSave.Visible = true;
            //BtnCusInfoUpdate.Visible = false;
            //BindGVSRINFO();
            //txtFullNm.Text = "";
            //txtmobile.Text = "";
            //txtNID.Text = "";
            //txtpresntaddr.Text = "";
            //txtpermntaddr.Text = "";
            //lblcusID.Text = "";
            //txtPNo.Text = "";
            ////lbl1.Text = "";
        }
    }
    protected void GVSRINFO_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //int indx = int.Parse(e.CommandArgument.ToString());
            //Label ext = (Label)GVSRINFO.Rows[indx].FindControl("Label1");
            //string Selectstatment = "SELECT top (100) [cus_id],[cus_name],[cus_nid],[cus_mobile],[cus_mail],[cus_present_addr],[cus_permanent_addr],[cus_ref_name],[cus_ref_mobile],[cus_page_no],[cus_crt_nm],[cus_crt_dt]FROM [dbo].[Mr_Customer_Info] where cus_id='" + ext.Text + "'";
            //DataTable dt = RADIDLL.get_InformationdataTableInventory(Selectstatment);
            //lblcusID.Text = dt.Rows[0]["cus_id"].ToString();
            //txtFullNm.Text = dt.Rows[0]["cus_name"].ToString();
            //txtNID.Text = dt.Rows[0]["cus_nid"].ToString();
            //txtmobile.Text = dt.Rows[0]["cus_mobile"].ToString();
            //txtPNo.Text = dt.Rows[0]["cus_page_no"].ToString();
            //txtmail.Text = dt.Rows[0]["cus_mail"].ToString();
            //txtpresntaddr.Text = dt.Rows[0]["cus_present_addr"].ToString();
            //txtpermntaddr.Text = dt.Rows[0]["cus_permanent_addr"].ToString();
            //txtRef_nm.Text = dt.Rows[0]["cus_ref_name"].ToString();
            //txtRef_mo.Text = dt.Rows[0]["cus_ref_mobile"].ToString();
            //BtnCusInfoSave.Visible = false;
            //BtnCusInfoUpdate.Visible = true;

        }
    }

    protected void BtnCusInfoClear_Click(object sender, EventArgs e)
    {
        //BindGVSRINFO();
        //lblcusID.Text = "";
        //txtFullNm.Text = "";
        //txtmail.Text = "";
        //txtmobile.Text = "";
        //txtNID.Text = "";
        //txtpermntaddr.Text = "";
        //txtpresntaddr.Text = "";
        //txtRef_mo.Text = "";
        //txtPNo.Text = "";
        //txtRef_nm.Text = "";
        //txtCus.Text = "";
        //BtnCusInfoUpdate.Visible = false;
        //BtnCusInfoSave.Visible = true;
        //message = "Clear Data Successfully";
        //ScriptManager.RegisterClientScriptBlock(this, typeof(Button), "toastr_message", "toastr.info('" + message + "', 'Success',{ closeButton: true,progressBar: true })", true);

    }



    #endregion

}

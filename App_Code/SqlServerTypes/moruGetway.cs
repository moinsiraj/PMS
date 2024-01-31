using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for moruGetway
/// </summary>
public class moruGetway
{
    private static SqlConnection _Mr_IE = null;
    private static SqlConnection _Mr_Asset = null;
    private static SqlConnection _Mr_SCM = null;
    private static SqlConnection _Mr_order_in_hand = null;
    private static SqlConnection _SpecFo = null;
    private static SqlConnection _SpecFo_Inventory = null;
    private static SqlConnection _Mr_PMS = null;
    private static SqlConnection _Barcoding = null;
    private static SqlConnection _Smartcode = null;

    public static SqlConnection moru_IE
    {

        get
        {

            if (_Mr_IE == null)
            {

                _Mr_IE = new SqlConnection(String.Format("Data Source=192.168.1.42;Initial Catalog=IE;Persist Security Info=true; User ID=sa; Password=dg@2022"));

            }

            return _Mr_IE;

        }
    }
    public static SqlConnection Mr_Asset
    {

        get
        {

            if (_Mr_Asset == null)
            {

                _Mr_Asset = new SqlConnection(String.Format("Data Source=192.168.1.42;Initial Catalog=Mr_Asset_Info;Persist Security Info=true; User ID=sa; Password=dg@2022"));
                //_Mr_Asset = new SqlConnection(String.Format("Data Source=ADMIN;Initial Catalog=Mr_Asset_Info;Persist Security Info=true; User ID=sa; Password=moin"));
               
            }

            return _Mr_Asset;

        }
    }
    public static SqlConnection moru_SCM
    {

        get
        {

            if (_Mr_SCM == null)
            {
                //Local R2M Software

                _Mr_SCM = new SqlConnection(String.Format("Data Source=192.168.1.42;Initial Catalog=Mr_SCM;Persist Security Info=true; User ID=sa; Password=dg@2022"));
                ////_Mr_order_in_hand = new SqlConnection(String.Format("Data Source=119.148.31.253;Initial Catalog=Mr_Order_In_Hand;Persist Security Info=true; User ID=sa; Password=GSG@#$%"));



            }

            return _Mr_SCM;

        }
    }
    public static SqlConnection moru_order_in_hand
    {

        get
        {

            if (_Mr_order_in_hand == null)
            {
                //Local R2M Software

                _Mr_order_in_hand = new SqlConnection(String.Format("Data Source=192.168.1.42;Initial Catalog=Mr_Order_In_Hand;Persist Security Info=true; User ID=sa; Password=dg@2022"));
                ////_Mr_order_in_hand = new SqlConnection(String.Format("Data Source=119.148.31.253;Initial Catalog=Mr_Order_In_Hand;Persist Security Info=true; User ID=sa; Password=GSG@#$%"));
           


            }

            return _Mr_order_in_hand;

        }
    }


    public static SqlConnection SpecfoInventory
    {
        get {

            if (_SpecFo_Inventory == null)
            {



                //Local R2M Software
                //_SpecFo_Inventory = new SqlConnection(String.Format("Data source=ADMIN;Initial Catalog=SpecFo_Inventory;Persist Security Info=true; User ID=sa; Password=moin"));
                _SpecFo_Inventory = new SqlConnection(String.Format("Data source=192.168.1.42;Initial Catalog=SpecFo_Inventory;Persist Security Info=true; User ID=sa; Password=dg@2022"));
                //_Mr_Inventory = new SqlConnection(String.Format("Data source=103.129.209.26;Initial Catalog=Mr_Inventory;Persist Security Info=true; User ID=sa; Password=@dmin1234"));
                //_Mr_Inventory = new SqlConnection(String.Format("Data source=DESKTOP-R40Q63T;Initial Catalog=Mr_Inventory;Persist Security Info=true; User ID=sa; Password=moin"));
                //_Mr_Inventory = new SqlConnection(String.Format("Data source=DESKTOP-BN2PGUO;Initial Catalog=Mr_Inventory;Persist Security Info=true; User ID=sa; Password=@dmin1234"));
            
            }
            return _SpecFo_Inventory;
        }
    
    
    }

    public static SqlConnection SpecFo
    {

        get
        {

            if (_SpecFo == null)
            {
                //_SpecFo = new SqlConnection(String.Format("Data Source=119.148.31.253;Initial Catalog=SpecFo;Persist Security Info=true; User ID=sa; Password=GSG@#$%"));
                //_SpecFo = new SqlConnection(String.Format("Data Source=192.168.1.230;Initial Catalog=SpecFo;Persist Security Info=true; User ID=sa; Password=L%d&dx@"));
                //_SpecFo = new SqlConnection(String.Format("Data source=ADMIN;Initial Catalog=SpecFo;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=moin"));
                //_SpecFo = new SqlConnection(String.Format("Data source=192.168.1.10;Initial Catalog=SpecFo;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=admin@123"));
                _SpecFo = new SqlConnection(String.Format("Data source=192.168.1.42;Initial Catalog=SpecFo;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=dg@2022"));
            }
            return _SpecFo;

        }


    }

    public static SqlConnection Mr_PMS
    {

        get
        {

            if (_Mr_PMS == null)
            {
                //_Mr_PMS = new SqlConnection(String.Format("Data Source=119.148.31.253;Initial Catalog=Mr_PMS;Persist Security Info=true; User ID=sa; Password=GSG@#$%"));
                //_Mr_PMS = new SqlConnection(String.Format("Data Source=192.168.1.230;Initial Catalog=Mr_PMS;Persist Security Info=true; User ID=sa; Password=L%d&dx@"));
                //_Mr_PMS = new SqlConnection(String.Format("Data source=ADMIN;Initial Catalog=Mr_PMS;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=moin"));
                //_Mr_PMS = new SqlConnection(String.Format("Data source=admin;Initial Catalog=Mr_PMS;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=moin"));
                _Mr_PMS = new SqlConnection(String.Format("Data source=192.168.1.42;Initial Catalog=Mr_PMS;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=dg@2022"));
            }
            return _Mr_PMS;

        }


    }

    public static SqlConnection Barcoding
    {

        get
        {

            if (_Barcoding == null)
            {
                //_Barcoding = new SqlConnection(String.Format("Data Source=119.148.31.253;Initial Catalog=Barcoding;Persist Security Info=true; User ID=sa; Password=GSG@#$%"));
                //_Barcoding = new SqlConnection(String.Format("Data Source=192.168.1.230;Initial Catalog=Barcoding;Persist Security Info=true; User ID=sa; Password=L%d&dx@"));
                //_Barcoding = new SqlConnection(String.Format("Data source=ADMIN;Initial Catalog=Barcoding;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=moin"));
                //_Barcoding = new SqlConnection(String.Format("Data source=192.168.1.10;Initial Catalog=Barcoding;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=admin@123"));
                _Barcoding = new SqlConnection(String.Format("Data source=192.168.1.42;Initial Catalog=Barcoding;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=dg@2022"));
            }
            return _Barcoding;

        }


    }



    public static SqlConnection Smartcode
    {

        get
        {

            if (_Smartcode == null)
            {
                //_Smartcode = new SqlConnection(String.Format("Data Source=119.148.31.253;Initial Catalog=Smartcode;Persist Security Info=true; User ID=sa; Password=GSG@#$%"));
                //_Smartcode = new SqlConnection(String.Format("Data Source=192.168.1.230;Initial Catalog=Smartcode;Persist Security Info=true; User ID=sa; Password=L%d&dx@"));
                //_Smartcode = new SqlConnection(String.Format("Data source=ADMIN;Initial Catalog=Smartcode;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=moin"));
                //_Smartcode = new SqlConnection(String.Format("Data source=192.168.1.10;Initial Catalog=Smartcode;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=admin@123"));
                _Smartcode = new SqlConnection(String.Format("Data source=192.168.1.42;Initial Catalog=Smartcode;Persist Security Info=true; Max Pool Size=10000;Enlist='true'; MultipleActiveResultSets=False; User ID=sa; Password=dg@2022"));
            }
            return _Smartcode;

        }


    }
    public moruGetway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
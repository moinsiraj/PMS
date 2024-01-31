using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class ProjectNames
{
   
    public int ProjectID { get; set; }
    public string ProjectName { get; set; }
    public string ProjectIP { get; set; }
    public string ProjectPassword { get; set; }
}
public class GetWay
{
    private static  string _ConSpecFo = null;
    private static string _ConInventory = null;
    private static string _ConIE = null;
    private static string _smrtcode = null;
    enum projectNames
    {
        Online = 0,  // 97.74.239.178----> yes
        //SUMI = 1,  //119.148.31.253----> yes
        DG = 1,  //192.168.1.230----> yes
        Kc = 2, //203.202.252.130---> yes
        Rahmath = 3, // 45.251.57.178------> no
        Sepal = 4, // 45.64.135.250------> no
        Zaman = 5, //192.168.20.35------> no
        Pioneer = 6,  //202.84.32.142----->no
        Temakaw= 7, //192.168.1.249----->no
        Panaroma = 8, //----->no
        Sigma = 9 ,//210.1.250.11  -------> yes         ,
        Zalo = 10, //203.202.245.85 ----->yes
        Russel = 11 //202.4.124.227 --------->yes
    };

    #region AppConFig
    private static  List<ProjectNames> projAddress = new List<ProjectNames>()
    {
        new ProjectNames { ProjectID=0, ProjectName= "DG", ProjectIP= "192.168.1.42", ProjectPassword= "admin@123" },
        //new ProjectNames { ProjectID=1, ProjectName= "DG", ProjectIP= "ERP-DEV", ProjectPassword= "moin" },
           //new ProjectNames { ProjectID=1, ProjectName= "DG", ProjectIP= "192.168.1.230", ProjectPassword= "L%d&dx@" },
                //new ProjectNames { ProjectID=1, ProjectName= "GoldStarGroupbd", ProjectIP= "192.168.0.130", ProjectPassword= "GSG@#$%" },
        //new ProjectNames { ProjectID=2, ProjectName= "Kc", ProjectIP= "203.202.252.130", ProjectPassword= "sltS2020" },
        //new ProjectNames { ProjectID=3, ProjectName= "Rahmath", ProjectIP= "45.251.57.178", ProjectPassword= "sp@erp#$" },
        //new ProjectNames { ProjectID=4, ProjectName= "Sepal", ProjectIP= "45.64.135.250", ProjectPassword= "$eP@l!@#$" },
        //new ProjectNames { ProjectID=5, ProjectName= "Zaman", ProjectIP= "192.168.20.35", ProjectPassword= "Z@m@n!@34" },
        //new ProjectNames { ProjectID=6, ProjectName= "Pioneer", ProjectIP= "202.84.32.142", ProjectPassword= "K$x#@dF*" },
        //new ProjectNames { ProjectID=7, ProjectName= "Temakaw", ProjectIP= "192.168.1.249", ProjectPassword= "K$x#j@&a" },         // No for this project... Find Temakaw project
        //new ProjectNames { ProjectID=8, ProjectName= "Panaroma", ProjectIP= "119.148.38.225", ProjectPassword= "D9*#gS%vG" },
        //new ProjectNames { ProjectID=9, ProjectName= "Sigma", ProjectIP= "210.1.250.11", ProjectPassword= "D3*#gSmvG" },
        //new ProjectNames { ProjectID=10, ProjectName= "Zalo", ProjectIP= "203.202.245.85", ProjectPassword= "ZL*#gSmvG" },
        //new ProjectNames { ProjectID=11, ProjectName= "Russel", ProjectIP= "202.4.124.227", ProjectPassword= "R@s#^%gv*" }
    };

    #endregion

    private static int index = (int)projectNames.DG;
    private static string strIP = projAddress[index].ProjectIP;
    private static string strPassword = projAddress[index].ProjectPassword;
    public static  string SpecFoCon
    {

        get
        {
            if (_ConSpecFo == null)
            {
               
                _ConSpecFo = String.Format("Data Source={0};Max Pool Size=10000;Enlist='true';MultipleActiveResultSets=False;Initial Catalog=SpecFo;Persist Security Info=True;User ID=sa;Password={1}", strIP, strPassword);


            }
            return _ConSpecFo;
        }
    }
    public static string SpecFo_Inventorycon
    {
        get
        {
            if (_ConInventory == null)
            {
                //--- Online
               _ConInventory = String.Format("Data Source={0};Max Pool Size=10000;Enlist='true';MultipleActiveResultSets=False;Initial Catalog=SpecFo_Inventory;Persist Security Info=True;User ID=sa;Password={1}", strIP, strPassword);

            }
            return _ConInventory;
        }
    }
    public static string SpecFo_IE
    {
        get
        {
            if (_ConIE == null)
            {
                //--- Online
                _ConIE = String.Format("Data Source={0};Max Pool Size=10000;Enlist='true';MultipleActiveResultSets=False;Initial Catalog=IE;Persist Security Info=True;User ID=sa;Password={1}", strIP, strPassword);
       
            }
            return _ConIE;
        }
    }
    public static string SpecFo_Smartcode
    {
        get
        {
            if (_smrtcode == null)
            {
                //--- Online
                _smrtcode = String.Format("Data Source={0};Max Pool Size=10000;Enlist='true';MultipleActiveResultSets=False;Initial Catalog=SmartCode;Persist Security Info=True;User ID=sa;Password={1}", strIP, strPassword);

            }
            return _smrtcode;
        }
    }
}



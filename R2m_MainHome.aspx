<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="R2m_Mainhome.aspx.cs" Inherits="R2m_Mainhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
.im
{
    border:3px solid #AED6F1;
	-webkit-border-radius: 8px;
    -moz-border-radius: 8px;
    border-radius: 8px;
    
    }
    body
    {
       /* background-color:#EAF4FF;    */
       background-color:#EAF2F8; 
       /*background-image:url(gridimage/bg_site.jpg);*/
    }

</style>
    <style>
		
		img.bg {
			/* Set rules to fill background */
			min-height: 100%;
			min-width: 1024px;
			
			/* Set up proportionate scaling */
			width: 100%;
			height: auto;
			
			/* Set up positioning */
			position: fixed;
			top: 0;
			left: 0;
		}
		
		@media screen and (max-width: 1024px){
			img.bg {
				left: 50%;
				margin-left: -512px; }
		}
		
		#page-wrap { position: relative; width: 1000px; margin: 50px auto; padding: 20px;
		              background: white;
		               -moz-box-shadow: 0 0 20px black;
		               -webkit-box-shadow: 0 0 20px black;
		                box-shadow: 0 0 20px black; }
	
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
       <table style="width: 100%;">
            <tr>
                <td valign="top">
                   
                    <table style="width:100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/gridimage/DGINFOSYSHOME.jpg" 
                                    CssClass="im" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
  
	

     

    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>


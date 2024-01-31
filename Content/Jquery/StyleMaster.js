


function CheckDeliveryQtyExceedOrdQty(gridview, ttlqty, uprice, pouprice,rowid) {
    var ttqty = document.getElementById(ttlqty).value;
    var uprice1 = document.getElementById(uprice).value;
    document.getElementById(pouprice).value = uprice1;
    var gvDrv = document.getElementById(gridview);
    var total = 0;
    for (i = 1; i < gvDrv.rows.length; i++) {
        var l00pcell = gvDrv.rows[i].cells;
        var loopcellvalue = l00pcell[2].getElementsByTagName("input")[0].value;
        var Insemqty = l00pcell[6].getElementsByTagName("input")[0].value;
        if (loopcellvalue != "") {
            total = parseFloat(loopcellvalue) + parseFloat(total);
            if (parseFloat(total) > parseFloat(ttqty)) {
                document.getElementById(ttlqty).style.border = '1px solid red';
                alert("PO Quantity can't exceed Ordered Quantity");
                l00pcell[2].getElementsByTagName("input")[0].focus();
                l00pcell[2].getElementsByTagName("input")[0].value = '';
                document.getElementById(ttlqty).style.border = '';
                break;
            }                     

        }
    }
}
function CheckduplicatePO(rowid, curval, gridview) {
    var gvDrv = document.getElementById(gridview);
    var s = parseInt(rowid);
    var cell1 = gvDrv.rows[s].cells;
    var T;
    var currentrowvalue = cell1[1].getElementsByTagName("input")[0].value;
    for (i = 1; i < gvDrv.rows.length - 1; i++) {
        var l00pcell = gvDrv.rows[i].cells;
        var loopcellvalue = l00pcell[1].getElementsByTagName("input")[0].value;
        if (currentrowvalue.length > 0) {
            if (i != rowid) {
                if (loopcellvalue.length > 0) {
                    if (loopcellvalue == currentrowvalue) {
                        l00pcell[1].getElementsByTagName("input")[0].style.background = '#E60000';
                        alert("Already exists the same value");
                        document.getElementById(curval).value = '';
                        document.getElementById(curval).focus();
                        l00pcell[1].getElementsByTagName("input")[0].style.background = '';
                    }
                }
            }
        }
    }
}
function flfld() {
    $("#ifupldfile").attr("src", "Master_Setup/frmUploadstyle.aspx");
    //  $("#hdrtxt").html("Add Expanse");
    var bid = $find('ppadditm');
    bid.show();
}

function CheckduplicateLot(rowid, curval, gridview) {
    var gvDrv = document.getElementById(gridview);
    var s = parseInt(rowid);
    var cell1 = gvDrv.rows[s].cells;
    var T;
    var currentrowvalue = cell1[0].getElementsByTagName("input")[0].value;
    for (i = 1; i < gvDrv.rows.length - 1; i++) {
        var l00pcell = gvDrv.rows[i].cells;
        var loopcellvalue = l00pcell[0].getElementsByTagName("input")[0].value;
        if (currentrowvalue.length > 0) {
            if (i != rowid) {
                if (loopcellvalue.length > 0) {
                    if (loopcellvalue == currentrowvalue) {
                        l00pcell[0].getElementsByTagName("input")[0].style.background = '#E60000';
                        alert("Already exists the same value");
                        document.getElementById(curval).value = '';
                        document.getElementById(curval).focus();
                        l00pcell[0].getElementsByTagName("input")[0].style.background = '';
                    }
                }
            }
        }
    }
}
function CheckduplicateLot1(gridview) {
    var gvDrv = document.getElementById(gridview);
    var s = parseInt(rowid);
    var cell1 = gvDrv.rows[s].cells;
    var T;
    var currentrowvalue = cell1[0].getElementsByTagName("input")[0].value;
    for (i = 1; i < gvDrv.rows.length - 1; i++) {
        var l00pcell = gvDrv.rows[i].cells;
        var loopcellvalue = l00pcell[0].getElementsByTagName("input")[0].value;
        if (currentrowvalue.length > 0) {
            if (i != rowid) {
                if (loopcellvalue.length > 0) {
                    if (loopcellvalue == currentrowvalue) {
                        l00pcell[0].getElementsByTagName("input")[0].style.background = '#E60000';
                        alert("Already exists the same value");
                        document.getElementById(curval).value = '';
                        document.getElementById(curval).focus();
                        l00pcell[0].getElementsByTagName("input")[0].style.background = '';
                    }
                }
            }
        }
    }
}
function SkSfdtshpdat1(sender, args) {
    var str1 = sender._selectedDate.format(sender._format);
    var str2 = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").value;

    var value1 = str1.split("-");
    var value2 = str2.split("-");
    var dt1 = parseInt(value1[0]);
    var mon1 = (value1[1]);
    var yr1 = parseInt(value1[2]);


    var dt2 = parseInt(value2[0]);
    var mon2 = (value2[1]);
    var yr2 = parseInt(value2[2]);

    var _month1 = get_MonthsNum(mon1);
    var _month2 = get_MonthsNum(mon2);
    var date1 = new Date(yr1, _month1, dt1);
    var date2 = new Date(yr2, _month2, dt2);
    if (str1 != '' && str2 != '') {
        if (date2 >= date1) {
            document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").style.border = '1px solid red';
            alert(" Ship date should be greater than BPCD");
            document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").style.border = '';
            sender._textbox.set_Value('');
            return false;
        }
        else {
            var s = document.getElementById("Text1").value
            var gd = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_grdDelivery");
            var Rowcell = gd.rows[s].cells;
            var ssr = new Date(_month1 + "/" + dt1 + "/" + yr1);
            var myDate = new Date(ssr);
            var dayOfMonth = myDate.getDate();
            myDate.setDate(dayOfMonth - 10);
            var d_a = myDate.getDate();
            var d_m = myDate.getMonth() + 1;
            var d_y = myDate.getFullYear();

            var monstring = get_Monthsstring(d_m);
            var fulldt = d_a + "-" + monstring + "-" + d_y;
            Rowcell[6].getElementsByTagName("input")[0].value = fulldt;
        }
    }
}

function getcontno(txtstyleid, txtcontid) {
    document.getElementById(txtstyleid).value = document.getElementById(txtcontid).value
}
function checkbpcddate(sender, args) {
    if (sender._selectedDate < new Date()) {
        alert("You cannot select a day earlier than today!");
        sender._selectedDate = new Date();
        sender._textbox.set_Value('');
    }
    
    //--Change BPCD (Lakmal)
    var newPbcd = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").value;

    var gridID = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_grdDelivery");
    for (i = 1; i < gridID.rows.length; i++) {
        gridID.rows[i].cells[4].getElementsByTagName("input")[0].value = newPbcd;
    }

    var str1 = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_txtoriginalrcvd").value;
    var str2 = document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_txtBpcd").value;
    var dt1 = parseInt(str1.substring(0, 2), 10);
    var mon1 = parseInt(str1.substring(3, 5), 10);
    var yr1 = parseInt(str1.substring(6, 10), 10);
    var dt2 = parseInt(str2.substring(0, 2), 10);
    var mon2 = parseInt(str2.substring(3, 5), 10);
    var yr2 = parseInt(str2.substring(6, 10), 10);
    var date1 = new Date(yr1, mon1, dt1);
    var date2 = new Date(yr2, mon2, dt2);
    if (str1 != '' && str2 != '') {
        if (date2 < date1) {
            alert(" BPCD cannot be smaller than  Original Order RCVD");
            document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_txtBpcd").value = '';
            return false;
        }
    }
}
function SkSfdt(sender, args) {
    var str1 = sender._selectedDate.format(sender._format);
    var str2 = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").value;
    var dt1 = parseInt(str1.substring(0, 2), 10);
    var mon1 = parseInt(str1.substring(3, 5), 10);
    var yr1 = parseInt(str1.substring(6, 10), 10);
    var dt2 = parseInt(str2.substring(0, 2), 10);
    var mon2 = parseInt(str2.substring(3, 5), 10);
    var yr2 = parseInt(str2.substring(6, 10), 10);
    var date1 = new Date(yr1, mon1, dt1);
    var date2 = new Date(yr2, mon2, dt2);
    if (str1 != '' && str2 != '') {
        if (date2 >= date1) {
            document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").style.border = '1px solid red';
            alert(" X-Factory date should be greater than BPCD");
            document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").style.border = '';
            sender._textbox.set_Value('');
            return false;
        }
        }
  
}
function SkSfdtshpdat(sender, args) {
    var str1 = sender._selectedDate.format(sender._format);
    var str2 = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").value;
    var dt1 = parseInt(str1.substring(0, 2), 10);
    var mon1 = parseInt(str1.substring(3, 5), 10);
    var yr1 = parseInt(str1.substring(6, 10), 10);
    var dt2 = parseInt(str2.substring(0, 2), 10);
    var mon2 = parseInt(str2.substring(3, 5), 10);
    var yr2 = parseInt(str2.substring(6, 10), 10);
    var date1 = new Date(yr1, mon1, dt1);
    var date2 = new Date(yr2, mon2, dt2);  
    if (str1 != '' && str2 != '') {
        if (date2 >= date1) {
            document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").style.border = '1px solid red';
            alert(" Ship date should be greater than BPCD");
            document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_txtBpcd").style.border = '';
            sender._textbox.set_Value('');
            return false;
        }
        else {
            var s = document.getElementById("Text1").value
            var gd = document.getElementById("ContentPlaceHolder1_C1TabControl1_C1TabPage1_grdDelivery");
            var Rowcell = gd.rows[s].cells;
            var ssr = new Date(mon1 + "/" + dt1 + "/" + yr1);
            var myDate = new Date(ssr);
            var dayOfMonth = myDate.getDate();
            myDate.setDate(dayOfMonth - 10);
            var d_a = myDate.getDate();
            var d_m = myDate.getMonth() + 1;
            var d_y = myDate.getFullYear();
            var fulldt = d_a + "/" + d_m + "/" + d_y;    
            Rowcell[5].getElementsByTagName("input")[0].value = fulldt;          
        }
    }
}

function oncliccick(gridview,rowindex) {
    document.getElementById("Text1").value = rowindex;
}

function CheckAcrobateReader(testbox) {
    var found = false;
    var info = '';
    try {
        acrobat4 = new ActiveXObject('PDF.PdfCtrl.1');
        if (acrobat4) {
            found = true;
            info = 'v. 4.0';
        }
    }
    catch (e) {
        //??? 
    }

    if (!found) {
        try {
            acrobat7 = new ActiveXObject('AcroPDF.PDF.1');
            if (acrobat7) {
                found = true;
                info = 'v. 7+';
            }
        }
        catch (e) {
            //??? 
        }

        if (!found && navigator.plugins && navigator.plugins.length > 0) {
            for (var i = 0; i < navigator.plugins.length; i++) {
                if (navigator.plugins[i].name.indexOf('Adobe Acrobat') > -1) {
                    found = true;
                    info = navigator.plugins[i].description + ' (' + navigator.plugins[i].filename + ')';
                    break;
                }
            }
        }
    }

    //document.write("Acrobat Reader Installed : " + found);
    document.getElementById(testbox).value =found;
}
//        document.write("<br />");
//        if (found) document.write("Info : " + info);
//        if (found) document.write("ladfklj");
//        document.getElementById('<%=TextBox1.ClientID%>').value = found;

$(document).ready(function () {
    var btntxtval = "";
    $(".btPOPUP").live("click", function () {
        $(".POPUPPanel").hide();
        var v = $(this).val();
        btntxtval = v;
        if (v == "Buyer") {
            $(".POPUPHeaderText").html("Create New Buyer");
            $("#POPUPIFrame").attr("src", "Master_Setup/frmBuyer.aspx");
        }
        if (v == "Store") {
            $(".POPUPHeaderText").html("Create New Store");
            $("#POPUPIFrame").attr("src", "Master_Setup/frmStore.aspx");
        }
        if (v == "Season") {
            $(".POPUPHeaderText").html("Create New Season");
            $("#POPUPIFrame").attr("src", "Master_Setup/frmSeason.aspx");
        }
        if (v == "Brand") {
            $(".POPUPHeaderText").html("Create New Brand");
            $("#POPUPIFrame").attr("src", "Master_Setup/frmBrand.aspx");
        }
        if (v == "Garment Dept") {
            $(".POPUPHeaderText").html("Create Garment Department");
            $("#POPUPIFrame").attr("src", "Master_Setup/frmGmtDept.aspx");
        }
        if (v == "Garment Type") {
            $(".POPUPHeaderText").html("Create Garment Type");
            $("#POPUPIFrame").attr("src", "Master_Setup/frmGmttype.aspx");
        }
              
        $(".POPUPPanel").toggle("slow");
        return false;
    });

    $(".POPUPClose").click(function () {
        //$(this).parents(".pnldv").animate({ opacity: 'hide' }, "slow");
        if (btntxtval == "Brand") {
           $("#ContentPlaceHolder1_C1TabControl1_C1TabPage1_btnLoadBrand").click();
       }
       if (btntxtval == "Buyer") {
           $("#ContentPlaceHolder1_C1TabControl1_C1TabPage1_btnLoadbyer").click();
       }
       if (btntxtval == "Store") {
           $("#ContentPlaceHolder1_C1TabControl1_C1TabPage1_btnLoadStore").click();
       }
       if (btntxtval == "Season") {
           $("#ContentPlaceHolder1_C1TabControl1_C1TabPage1_btnLoadseason").click();
       }
       if (btntxtval == "Garment Dept") {
           $("#ContentPlaceHolder1_C1TabControl1_C1TabPage1_btnLoadgmtdept").click();
       }
       if (btntxtval == "Garment Type") {
           $("#ContentPlaceHolder1_C1TabControl1_C1TabPage1_btnLoadGmttype").click();
       }
      
        $(".POPUPPanel").toggle("slow");
    });
});

//TotalPackratio Calculation
function CalculateTotalpack() {
    var q = parseInt(document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_txtTotalpack").value);
    var r = parseInt(document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_txtRatio").value);
    var s = eval(q) * eval(r);
    if (!isNaN(s)) {
        document.getElementById("ContentPlaceHolder1_TabContainer1_TabPanel1_txtOrderqty").value = q * r;
    }
}


Array.prototype.contains = function (obj) {
    var i = this.length;
    while (i--) {
        if (this[i] == obj) {
            return true;
        }
    }
    return false;
}
function trgval(gridview) {
    var arrayValues = [];
    var gvDrv = document.getElementById(gridview);
    for (i = 1; i < gvDrv.rows.length; i++) {
        var l00pcell = gvDrv.rows[i].cells;
        var loopcellvalue = l00pcell[0].getElementsByTagName("input")[0].value;
        if (loopcellvalue.length > 0) {
            var tr = arrayValues.contains(loopcellvalue.toUpperCase());
            if (tr == true) {
                alert("Already Exists");
                gvDrv.rows[i].cells[0].getElementsByTagName("input")[0].value = "";
                gvDrv.rows[i].cells[0].getElementsByTagName("input")[0].focus();
                break;
            }
            else {
                arrayValues.push(loopcellvalue.toUpperCase());
            }
        }
    }
}

function checktotQty(rowId, gridview, TotalOrd, Uprice, txtpono) {
    var gridID = document.getElementById(gridview);
    var TotalOrdQty = document.getElementById(TotalOrd).value;
//    var TotalPOQty = document.getElementById(totalPOqty).value;
    //    var InseamQty = document.getElementById(InseamSet).value;
   
        var UnitPrice = document.getElementById(Uprice).value;
        gridID.rows[rowId].cells[7].getElementsByTagName("input")[0].value = UnitPrice;
        var Total = 0;
        var pono = document.getElementById(txtpono).value;
        for (i = 1; i < gridID.rows.length; i++) {
         
                var CurrentCell = gridID.rows[i].cells;
                var CurrentCelValue = CurrentCell[5].getElementsByTagName("input")[0].value;
                var InseamQty = CurrentCell[2].getElementsByTagName("span")[0].innerText;
                if (CurrentCelValue.length > 0) {
                    Total = eval(CurrentCelValue) + Total;
                }
                
                if (parseFloat(Total) > parseFloat(TotalOrdQty)) {
                    gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].style.border = '1px solid red';
                    document.getElementById(TotalOrd).style.border = '1px solid red';
                    var OrdTotQty = gridID.rows[rowId].cells[2].getElementsByTagName("span")[0].innerText;
                    alert("PO Quantity Cann't Exceed Ordered Quantity(" + TotalOrdQty + ")");
                    gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].focus();
                    gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].value = gridID.rows[rowId].cells[2].getElementsByTagName("span")[0].innerText;
                    gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].style.border = '1px solid gray';
                    document.getElementById(TotalOrd).style.border = '1px solid gray';
                    break;
                }
                else {
                    var x = gridID.rows.length-1;
                    gridID.rows[x].cells[2].innerText = Total;
                    var bal = parseFloat(TotalOrdQty) - parseFloat(Total);
                    gridID.rows[x].cells[4].innerText =bal;

                    if (InseamQty.length > 0) {
                        if (pono.toUpperCase() != "TBC") {
                            if (parseFloat(gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].value) < parseFloat(gridID.rows[rowId].cells[2].getElementsByTagName("span")[1].innerText)) {
                                gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].style.border = '1px solid red';
                                var AssortQty = gridID.rows[rowId].cells[2].getElementsByTagName("span")[1].innerText;
                                alert("PO quantity should be more than or equal to assortment Quantity.Color/Size Wise Assortment Quantity(" + AssortQty + ")");
                                gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].focus();
                                gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].value = gridID.rows[rowId].cells[2].getElementsByTagName("span")[0].innerText;
                                gridID.rows[rowId].cells[2].getElementsByTagName("input")[0].style.border = '1px solid gray';
                                break;
                            }
                        }
                    }
                }
                

    }   
}

function SetUpriceforGrid(gridview, Uprice) {
    var gridID = document.getElementById(gridview);   
    var UnitPrice = document.getElementById(Uprice).value;
    for (i = 1; i < gridID.rows.length; i++) {
        gridID.rows[i].cells[7].getElementsByTagName("input")[0].value = UnitPrice;
    }
}

//function checktotQty(rowId, gridview,TotalOrd,totalPOqty,InseamSet,Uprice) {
//    var gridID = document.getElementById(gridview);
function ds() {
    $("input[id$='btncpy']").attr("disabled", false);
}
$(document).ready(function () {
    $("#btncpy").live("click", function () {
        //$("#ifdd").attr("src", "Master_Setup/stcp.aspx");
        var oldstyleid = $("input[id$='txtStid']").val();
        $("#ifdd").attr("src", "Master_Setup/stcp.aspx?x="+oldstyleid+"");
        $(".bbcp").toggle('medium');
        
    });
    $("#btncc").live("click", function () {
        $("#ppcp").toggle('medium');
    });

    $("input[id$='ckdd']").live('change', function () {
        if ($(this).is(':checked')) {
            // $('#ckqty').attr("disabled", "disabled");
            $("input[id$='Ckcl']").removeAttr('disabled');
        }
        else {
            $("input[id$='ckqty']").attr("disabled", "disabled");
            $("input[id$='Ckcl']").attr("disabled", "disabled");
            $("input[id$='Ckcl']").removeAttr('checked');
            $("input[id$='ckqty']").removeAttr('checked');
        }
    });

    $("input[id$='Ckcl']").live('change', function () {
        if ($(this).is(':checked')) {
            // $('#ckqty').attr("disabled", "disabled");
            $("input[id$='ckqty']").removeAttr('disabled');
        }
        else {
            $("input[id$='ckqty']").attr("disabled", "disabled");           
        }
    });
});
function Sav_copstyle() {
    var nstylenow = $("input[id$='txtcpstyle']").val();
    var oldstyleid = $("input[id$='txtStid']").val();
    var user = $("input[id$='txtsess']").val();
    var chkdl = "0";
    var chkcl = "0";
    var chkqt = "0";    
    if ($("input[id$='ckdd']").is(':checked')) {
        chkdl = 1;
    }
    if ($("input[id$='Ckcl']").is(':checked')) {
        chkcl = 1;
    }
    if ($("input[id$='ckqty']").is(':checked')) {
        chkqt = 1;
    }
    //alert(nstylenow + "--" + oldstyleid + "--" + user + "--" + chkdl + "--" + chkcl + "--" + chkqt);
    $.ajax({
        type: "POST",
        url: "WebService.asmx/StCplst",
        //data: "{ 'name': '" + name + "'}",
        data: "{ 'nStydino': '" + nstylenow + "','ostid': '" + oldstyleid + "', 'sr': '" + user + "','odlv':'" + chkdl + "','clsz':'" + chkcl + "','sqt':'" + chkqt + "'}",
        data: "{ 'nStydino': '" + nstylenow + "'}",
        contentType: "application/json",
        async: false,
        success: function (data) {
            alert(data.d);
        }
    });
}
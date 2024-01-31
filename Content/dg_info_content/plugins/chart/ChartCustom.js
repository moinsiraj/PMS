$(function () {
    LoadChart();
    getSalesData();
   

   
    $("[id*=DDCOM]").bind("change", function () {
        LoadChart();
        getSalesData();
        
  
     
    });
});


function LoadChart() {
    $.ajax({
        type: "POST",
        url: "R2m_DashBoard.aspx/Get_Po_GRNno",
        data: "{company: '" + $("[id*=DDCOM]").val() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessSts,
        error: OnErrorCallSts
    });
    function OnSuccessSts(response) {
        var aData = response.d;     
        var CutQty = [];
        var InputQty = [];
        var SQCQty = [];
        var FinQty = [];
        var PakQty = [];
        var ExpQty = [];
   
        $.each(aData, function (inx, val) {
            CutQty.push(val.CutQty);
            InputQty.push(val.InputQty);
            SQCQty.push(val.SQCQty);
            FinQty.push(val.FinQty);
            PakQty.push(val.PakQty);
            ExpQty.push(val.ExpQty);
         
         
          
        });
        var ctx = $("#MyChart2").get(0).getContext("2d");
        var config = {
            type: 'doughnut',

            data: {
                datasets: [{
                 
                    data: [CutQty, InputQty, SQCQty, FinQty, PakQty, ExpQty],
            
                    backgroundColor: ['#F72E03', '#0FDF0B', '#054AFC', '#F9E305', '#06F7F9', '#F205F9'],
                }],
                labels: ['Cutting Qty', 'Input Qty', 'Sewing Qty', 'Finishing Qty', 'Packing Qty', 'Export Qty'],
     
            },
            options: {
                maintainAspectRatio: false,
                responsive: true
            }
        };
        var donutChart = new Chart(ctx, config);
    }
    function OnErrorCallSts(response) { }
}



function getSalesData() {
    $.ajax({
        type: "POST",
        url: "R2m_DashBoard.aspx/Get_Sales_Data",
        data: "{company: '" + $("[id*=DDCOM]").val() + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });

    function OnSuccess_(response) {
        var aData = response.d;
        var SalesDate = [];
        var Salespaid = [];
        var Salesvalue = [];
     
        var QCOut = [];
        var FiQty = [];
        var PakQty = [];
        var ExpQty = [];
    
        $.each(aData, function (inx, val) {
            ;
            SalesDate.push(val.SalesDate);
            Salespaid.push(val.Salespaid);
            Salesvalue.push(val.Salesvalue);
                   
            QCOut.push(val.QCOut);
            FiQty.push(val.FiQty);
            PakQty.push(val.PakQty);
            ExpQty.push(val.ExpQty);


            
        });
        var ctx = $("#MyChart1").get(0).getContext("2d");
        var config = {
            type: 'bar',
            data: {
                datasets: [
                    
                    {
                        label: 'Cutting',
                        backgroundColor: '#F72E03',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: Salespaid
                    },
                  

                    {
                        label: 'Input',
                        backgroundColor: '#0FDF0B',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: Salesvalue
                    },
                      {
                          label: 'Sewing QC Out',
                          backgroundColor: '#054AFC',
                          borderColor: 'rgba(210, 214, 222, 1)',
                          pointRadius: false,
                          pointColor: 'rgba(210, 214, 222, 1)',
                          pointStrokeColor: '#c1c7d1',
                          pointHighlightFill: '#fff',
                          pointHighlightStroke: 'rgba(220,220,220,1)',
                          data: QCOut
                      },

                       {
                           label: 'Finishing',
                           backgroundColor: '#F9E305',
                           borderColor: 'rgba(210, 214, 222, 1)',
                           pointRadius: false,
                           pointColor: 'rgba(210, 214, 222, 1)',
                           pointStrokeColor: '#c1c7d1',
                           pointHighlightFill: '#fff',
                           pointHighlightStroke: 'rgba(220,220,220,1)',
                           data: FiQty
                       },
                        {
                            label: 'Packing',
                            backgroundColor: '#06F7F9',
                            borderColor: 'rgba(210, 214, 222, 1)',
                            pointRadius: false,
                            pointColor: 'rgba(210, 214, 222, 1)',
                            pointStrokeColor: '#c1c7d1',
                            pointHighlightFill: '#fff',
                            pointHighlightStroke: 'rgba(220,220,220,1)',
                            data: PakQty
                        },

  {
      label: 'Export',
      backgroundColor: '#F205F9',
      borderColor: 'rgba(210, 214, 222, 1)',
      pointRadius: false,
      pointColor: 'rgba(210, 214, 222, 1)',
      pointStrokeColor: '#c1c7d1',
      pointHighlightFill: '#fff',
      pointHighlightStroke: 'rgba(220,220,220,1)',
      data: ExpQty
},
                    
                    
                ],
                labels: SalesDate,
            },
            options: {
                maintainAspectRatio: false,
                responsive: true,
                datasetFill: false,
                title: {
                    display: true,
                    //text: 'Sales and Paid Amount (Last 3 Days)'
                }
            }
        };
        if (window.bar != undefined)
            window.bar.destroy();
        window.bar = new Chart(ctx, config);
    }
    function OnErrorCall_(response) { }
}


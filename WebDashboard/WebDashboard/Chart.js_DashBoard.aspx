<%@ Page Title="Chart.js_Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chart.js_DashBoard.aspx.cs" Inherits="WebDashboard.Chartjs_DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        <canvas id="myLineChart" style="height:5px; width:10px"></canvas>

        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.js"></script>

        <script type="text/javascript">

            var ctx = document.getElementById("myLineChart").getContext("2d");

                var jsonData = $.ajax({
                    type: "GET",
                    url: '<%=ResolveUrl("DashBoard.aspx/GetData")%>',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                }).done(function(Data) {

                    var tempData = {
                        labels: [],
                        datasets: [{
                            label: 'Quanity',
                            borderColor: "rgba(43,161,233,1",
                            data: [],
                            fill: false
                        },
                        {
                            label: 'Price',
                            borderColor: "rgba(233,230,43,1)",
                            data: [],
                            fill: false
                        },
                        {
                            label: 'Total',
                            borderColor: "rgba(233,135,43,1)",
                            data: [],
                            fill: false
                        }]
                    };

                    $.each(JSON.parse(Data.d), function (i, row) {
                        tempData.labels.push(row.Product);
                        tempData.datasets[0].data.push(row.Quanity);
                        tempData.datasets[1].data.push(row.Price);
                        tempData.datasets[2].data.push(row.Total);
                    });

                    var myChart = new Chart(ctx, {
                        type: 'line', data: tempData, options: {
                            title: { display: true, text: 'Product Sales', position: 'top'},
                            legend:{ position: 'right' },
                            scales: {
                                yAxes: [{
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }]
                            }
                        }
                    });

                });
       </script>
   </h1>

</asp:Content>

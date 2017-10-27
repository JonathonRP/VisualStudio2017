<%@ Page Title="Google DashBoard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="WebDashboard.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <h1>
    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
      <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
  
        <script type='text/javascript'>

            google.charts.load('current', { packages: ['corechart', 'controls'] });
            google.charts.setOnLoadCallback(drawDashboard);

            function drawDashboard() {

                $(function () {
                    $.ajax({
                        type: "GET",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: '<%=ResolveUrl("DashBoard.aspx/GetData")%>',
                    data: "{}",
                    success:
                    function (jsonData) {
                        

                    var data = new google.visualization.DataTable();
                    data.addColumn('string', 'Product');
                    data.addColumn('number', 'Quanity');
                    data.addColumn('number', 'Price');
                    data.addColumn('number', 'Total');

                    $.each(JSON.parse(jsonData.d), function (i, row) {
                        data.addRow([row.Product, row.Quanity, row.Price, row.Total]);
                    })

                    var dashboard = new google.visualization.Dashboard(document.getElementById('dashboard_div'));

                    var formatter = new google.visualization.NumberFormat({ prefix: '$' });
                    formatter.format(data, 2);
                    formatter.format(data, 3);

                    var totalRangeSlider = new google.visualization.ControlWrapper({
                        'controlType': 'NumberRangeFilter',
                        'containerId': 'filter_div',
                        'options': {
                            'filterColumnLabel': 'Total'
                        }
                    });

                    var columnChart = new google.visualization.ChartWrapper({
                        'chartType': 'ColumnChart',
                        'containerId': 'chart_div',
                        'options': {
                            'width': 500,
                            'height': 300,
                            'animation': {
                                'duration': 1000,
                                'easing': 'out',
                                'startup': 'true'
                            },
                            'isStacked': 'true',
                            'vAxis': { 'minValue': 0, 'maxValue': 10 },
                            'legend': 'right',
                            'backgroundColor': { 'fill': 'transparent' }
                        },
                        'view': { 'columns': [0, 1, 2] },
                    });

                    var status = 0;

                    var selection = google.visualization.events.addListener(columnChart, 'select', function () {
                        var sliderDefault = totalRangeSlider.getState();
                        var itemSelection = columnChart.getChart().getSelection()[0];

                        if (itemSelection) {
                            if (status == 0) {
                                var value = data.getValue(itemSelection.row, 3);
                                totalRangeSlider.setState({ 'lowValue': [value], 'highValue': [value] });

                                dashboard.bind(totalRangeSlider, [columnChart]);
                                dashboard.draw(data);
                                status = status + 1;
                            }


                            else {
                                totalRangeSlider.setState({ 'lowThumbAtMinimum': [sliderDefault.lowValue], 'highThumbAtMaximum': [sliderDefault.highValue] });
                                status = status - 1;
                                dashboard.bind(totalRangeSlider, [columnChart]);
                                dashboard.draw(data);
                            }
                        }
                    });

                var runReady = google.visualization.events.addListener(columnChart, 'ready', function () {
                    google.visualization.events.removeListener(runReady);

                    dashboard.bind(totalRangeSlider, [columnChart]);
                    dashboard.draw(data);

                });

                dashboard.bind(totalRangeSlider, columnChart);
                dashboard.draw(data);
                },

                error: function (xhr, textStatus, Jack_lametin) {
                    alert("Error loading data! Please try again. " + Jack_lametin);
                }
              });
            })
          }
     </script>
  </h1>

  <div>
    <!--Div that will hold the dashboard-->
      
    <div id="dashboard_div">
      <!--Divs that will hold each control and chart-->
      <div id="filter_div"></div>
      <div id="chart_div"></div>
    </div>
  </div>
</asp:Content>

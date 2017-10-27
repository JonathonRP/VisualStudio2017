<%@ Page Title="Google DashBoard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Test_Environment__2._0_.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <h1>
    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">

      // Load the Visualization API and the controls package.
      google.charts.load('current', {'packages':['corechart', 'controls']});

      // Set a callback to run when the Google Visualization API is loaded.
      google.charts.setOnLoadCallback(drawDashboard);

      // Callback that creates and populates a data table,
      // instantiates a dashboard, a range slider and a pie chart,
      // passes in the data and draws it.
        function drawDashboard() {

            // Create our data table.

            var data = new google.visualization.arrayToDataTable([
                ['Name', 'Donuts eaten'],
                ['Michael', 5],
                ['Elisa', 7],
                ['Robert', 3],
                ['John', 2],
                ['Jessica', 6],
                ['Aaron', 1],
                ['Margareth', 8]
            ]);

            // Create a dashboard.
            var dashboard = new google.visualization.Dashboard(
                document.getElementById('dashboard_div'));

            // Create a range slider, passing some options
            var donutRangeSlider = new google.visualization.ControlWrapper({
                'controlType': 'NumberRangeFilter',
                'containerId': 'filter_div',
                'options': {
                    'filterColumnLabel': 'Donuts eaten'
                }
            });

            // Create a pie chart, passing some options
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
          }
        });

        // Establish dependencies, declaring that 'filter' drives 'pieChart',
        // so that the pie chart will only display entries that are let through
        // given the chosen slider range.
        dashboard.bind(donutRangeSlider, columnChart);

        // Draw the dashboard.
        dashboard.draw(data);
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

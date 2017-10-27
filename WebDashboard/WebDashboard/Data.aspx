<%@ Page Title="Data DashBoard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="WebDashboard.Data" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h1>
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
            <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>

        <script type="text/javascript">

            google.charts.load('visualization', '1', { packages: ['table'] });
            google.charts.setOnLoadCallback(drawTable);

            function drawTable() {

                $(function () {
                    $.ajax({
                        type: "GET",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= ResolveUrl("DashBoard.aspx/GetData")%>',
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

                            var table = new google.visualization.Table(document.getElementById('table_div'));
                            var formatter = new google.visualization.NumberFormat({ prefix: '$' });
                            formatter.format(data, 2);
                            formatter.format(data, 3);

                            table.draw(data, { allowHtml: true, showRowNumber: true, width: '80%', height: '100%' });
                        },
                        error: function (xhr, statusText, Jack_lametin) {
                            alert("Error loading data! Please try again. " + Jack_lametin);
                        }
                    });
                })
            }
        </script>
      </h1>

    <div class="col">
        <h2>Product Sales</h2>
    <div id="table_div"></div>
    </div>
</asp:Content>

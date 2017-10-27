<%@ Page Title="d3.js_Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="d3.js_DashBoard.aspx.cs" Inherits="WebDashboard.d3js_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>

form {
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
}

label {
  display: block;
}

</style>

    <h1>
        <script src="https://d3js.org/d3.v4.min.js"></script>
        <script src='https://d3js.org/d3-queue.v3.min.js'></script>
        <script type="text/javascript">

            var queue = d3.queue();

            var request = d3.request("<%=ResolveUrl("DashBoard.aspx/GetData")%>")
                .header("Content-Type", "application/json; charset=utf-8")
                .mimeType("application/json")
                .response(function (xhr) { return JSON.parse(xhr.responseText); })

            queue
                .defer(request.get)
                .await(render);

            function render(error, data) {
                var seriesKeys = Object.keys(JSON.parse(data.d)[0]).slice(0, Object.keys(JSON.parse(data.d)[0]).length);
                console.log('Object.keys(data[0])', Object.keys(JSON.parse(data.d)[0]));
                    console.log('seriesKeys', seriesKeys);

                    var stackedData = d3.stack()
                        .keys(seriesKeys)(JSON.parse(data.d));

                    var yMaxGrouped = d3.max(JSON.parse(data.d), function (d) { return d.Total });
                    var yMaxStacked = d3.max(JSON.parse(data.d), function (d) { return d3.sum(Object.values(d)) });
                    var n = Object.keys(JSON.parse(data.d)[0]).length; // the number of series
                    var m = d3.range(data.length); // the number of values per series

                    console.log('stackedData', stackedData);
                    console.log('yMaxGrouped', yMaxGrouped);
                    console.log('yMaxStacked', yMaxStacked);
                    console.log('n, the number of series', n);
                    console.log('m, the number of values per series', m);

                    var svg = d3.select("svg"),
                        margin = { top: 40, right: 10, bottom: 20, left: 10 },
                        width = +svg.attr("width") - margin.left - margin.right,
                        height = +svg.attr("height") - margin.top - margin.bottom,
                        g = svg.append("g").attr("transform", "translate(${ margin.left}, ${margin.top})");

                    var x = d3.scaleBand()
                        .domain(m)
                        .rangeRound([0, width])
                        .padding(0.08);

                    var y = d3.scaleLinear()
                        .domain([0, yMaxStacked])
                        .range([height, 0]);

                    var color = d3.scaleOrdinal()
                        .domain(d3.range(n))
                        .range(d3.schemeCategory20c);

                    var series = g.selectAll(".series")
                        .data(stackedData)
                        .enter().append("g")
                        .attr("fill", function (d, i) { return color(i); });

                    var rect = series.selectAll("rect")
                        .data(function (d) { return d; })
                        .enter().append("rect")
                        .attr("x", function (d, i) { return x(i); })
                        .attr("y", height)
                        .attr("width", x.bandwidth())
                        .attr("height", 0);

                    rect.transition()
                        .delay(function (d, i) { return i * 10; })
                        .attr("y", function (d) { return y(d[1]); })
                        .attr("height", function (d) { return y(d[0]) - y(d[1]); });

                    g.append("g")
                        .attr("class", "axis axis--x")
                        .attr("transform", "translate(0," + height + ")")
                        .call(d3.axisBottom(x)
                            .tickSize(0)
                            .tickPadding(6));

                    d3.selectAll("input")
                        .on("change", changed);

                    var timeout = d3.timeout(function () {
                        d3.select("input[value=\"grouped\"]")
                            .property("checked", true)
                            .dispatch("change");
                    }, 2000);

                    function changed() {
                        timeout.stop();
                        if (this.value === "grouped") transitionGrouped();
                        else transitionStacked();
                    }

                    function transitionGrouped() {
                        y.domain([0, yMaxGrouped]);

                        rect.transition()
                            .duration(500)
                            .delay(function (d, i) { return i * 10; })
                            .attr("x", function (d, i) { return x(i) + x.bandwidth() / n * this.parentNode.__data__.key; })
                            .attr("width", x.bandwidth() / n)
                            .transition()
                            .attr("y", function (d) { return y(d[1] - d[0]); })
                            .attr("height", function (d) { return y(0) - y(d[1] - d[0]); });
                    }

                    function transitionStacked() {
                        y.domain([0, yMaxStacked]);

                        rect.transition()
                            .duration(500)
                            .delay(function (d, i) { return i * 10; })
                            .attr("y", function (d) { return y(d[1]); })
                            .attr("height", function (d) { return y(d[0]) - y(d[1]); })
                            .transition()
                            .attr("x", function (d, i) { return x(i); })
                            .attr("width", x.bandwidth());
                    }
                }
        </script>
    </h1>

    <asp:PlaceHolder runat="server">
          <label><input type="radio" name="mode" value="grouped"> Grouped</label>
          <label><input type="radio" name="mode" value="stacked" checked> Stacked</label>
    </asp:PlaceHolder>

        <svg width="960" height="500"></svg>

</asp:Content>

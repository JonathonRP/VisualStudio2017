<%@ Page Title="Data DashBoard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Data.aspx.cs" Inherits="Test_Environment__2._0_.Data" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="480px" Width="546px" BackColor="Transparent" Palette="EarthTones">
    <series>
        <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Legend="Legend1" Name="Amount" XValueMember="productID" YValueMembers="amount" Color="ForestGreen">
        </asp:Series>
        <asp:Series ChartArea="ChartArea1" ChartType="StackedColumn" Legend="Legend1" Name="Quality" XValueMember="productID" YValueMembers="quality" Color="DimGray">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1" BackColor="Transparent">
            <AxisY LineColor="DimGray" IsLabelAutoFit="True">
                <LabelStyle ForeColor="Silver" />
            </AxisY>
            <AxisX LineColor="DimGray" IsLabelAutoFit="True">
                <LabelStyle ForeColor="Silver" />
            </AxisX>
        </asp:ChartArea>
    </chartareas>
    <Legends>
        <asp:Legend Name="Legend1" ForeColor="DimGray" BackColor="Transparent">
        </asp:Legend>
    </Legends>
    <Titles>
        <asp:Title Name="Title1" ForeColor="DimGray" Text="Annual Spending vs Savings" Font="Microsoft Sans Serif, 20pt">
        </asp:Title>
    </Titles>
</asp:Chart>



<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ReeseDBConnectionString %>" SelectCommand="SELECT [productID], [product_Name], [quality], [amount], [total] FROM [product_trans]"></asp:SqlDataSource>



</asp:Content>

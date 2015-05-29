<%@     Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GenerateReport._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
  
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Export To PDF</h3>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Generate Report" OnClick="Button1_Click" />
       
    </div>
</asp:Content>

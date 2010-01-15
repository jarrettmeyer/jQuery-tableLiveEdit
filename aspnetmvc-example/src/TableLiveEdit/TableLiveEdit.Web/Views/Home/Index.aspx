<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>jQuery.tableLiveEdit Demo</h2>
    <p>
        To learn more about tableLiveEdit, go to the <a href="http://jarrettmeyer.com/portfolio/jQuery-tableLiveEdit/">main project page</a>
    </p>
    <p>
        Check out <%= Html.ActionLink("the demo", "Index", "Contacts") %>.
    </p>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TableLiveEdit.Core.Models.Contact>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm("Update", "Contacts", new { id = Model.ContactId }, FormMethod.Post)) { %> 
        <fieldset>
            <legend>Fields</legend>
            <input type="hidden" name="ContactId" id="ContactId" value="<%= Model.ContactId %>" />
            <p>
                <label for="FirstName">First Name:</label>
                <%= Html.TextBox("FirstName", Model.FirstName) %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
            <p>
                <label for="LastName">Last Name:</label>
                <%= Html.TextBox("LastName", Model.LastName) %>
                <%= Html.ValidationMessage("LastName", "*") %>
            </p>
            <p>
                <label for="EmailAddress">Email Address:</label>
                <%= Html.TextBox("EmailAddress", Model.EmailAddress) %>
                <%= Html.ValidationMessage("EmailAddress", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>    
    <% } %>

    <div>
        <%= Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>


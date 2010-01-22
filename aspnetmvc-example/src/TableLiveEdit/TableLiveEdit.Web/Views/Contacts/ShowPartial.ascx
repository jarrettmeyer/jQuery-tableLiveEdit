<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Contact>" %>
<tr class="contact" id="contact-<%= Model.ContactId %>">
    <td><%= Html.Encode(Model.FirstName) %></td>
    <td><%= Html.Encode(Model.LastName) %></td>
    <td><%= Html.Encode(Model.EmailAddress) %></td>
    <td>
        <%= Html.ActionLink("Edit", "Edit", new { id = Model.ContactId }, new { @class = "edit-link" }) %> |
        <form action="<%= Url.Action("Delete", new { id = Model.ContactId }) %>" method="post" style="display:inline;">
            <%= Html.AntiForgeryToken() %>
            <%= Html.ActionLink("Delete", "Delete", new { id = Model.ContactId }, new { @class = "delete-link" }) %>
        </form>
    </td>
</tr>


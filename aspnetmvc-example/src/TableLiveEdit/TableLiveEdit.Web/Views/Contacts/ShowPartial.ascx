<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Contact>" %>
<tr class="contact" id="contact-<%= Model.ContactId %>">
    <td><%= Html.Encode(Model.FirstName) %></td>
    <td><%= Html.Encode(Model.LastName) %></td>
    <td><%= Html.Encode(Model.EmailAddress) %></td>
    <td><%= Html.ActionLink("Edit", "Edit", new { id = Model.ContactId }, new { @class = "edit-link" }) %></td>
</tr>


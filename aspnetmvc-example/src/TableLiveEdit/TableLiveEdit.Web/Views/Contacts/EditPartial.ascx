<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Contact>" %>
<tr class="contact" id="contact-<%= Model.ContactId %>">
    <input type="hidden" name="ContactId" id="ContactId" value="<%= Model.ContactId %>" />
    <td><input type="text" name="FirstName" id="FirstName" value="<%= Model.FirstName %>" /></td>
    <td><input type="text" name="LastName" id="LastName" value="<%= Model.LastName %>" /></td>
    <td><input type="text" name="EmailAddress" id="EmailAddress" value="<%= Model.EmailAddress %>" /></td>
    <td>
        <input type="submit" id="live-edit-update" value="Update" />
        <input type="button" id="live-edit-cancel" value="Cancel" />
    </td>
</tr>


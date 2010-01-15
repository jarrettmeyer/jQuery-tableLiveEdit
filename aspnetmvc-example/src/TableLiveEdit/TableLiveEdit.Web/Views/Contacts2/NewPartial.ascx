<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Contact>" %>
<tr class="contact" id="contact-0">    
    <td colspan="4">
        <input type="hidden" name="ContactId" id="ContactId" value="<%= Model.ContactId %>" />
        <p>
            <label for="FirstName">First Name</label>
            <input type="text" name="FirstName" id="FirstName" value="<%= Model.FirstName %>" />
        </p>
        <p>
            <label for="LastName">Last Name</label>
            <input type="text" name="LastName" id="LastName" value="<%= Model.LastName %>" />
        </p>
        <p>
            <label for="EmailAddress">Email Address</label>
            <input type="text" name="EmailAddress" id="EmailAddress" value="<%= Model.EmailAddress %>" />
        </p>
        <p>
            <input type="submit" id="live-edit-create" value="Create" />
            <input type="button" id="live-edit-cancel" value="Cancel" />
        </p>
    </td>
</tr>


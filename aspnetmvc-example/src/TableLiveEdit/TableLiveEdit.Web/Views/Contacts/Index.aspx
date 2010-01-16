<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Contact>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Contacts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <%= Url.IncludeJs("jquery.tableLiveEdit.js") %>
    <script type="text/javascript" language="javascript">
        $(function() {
            var options = {
                modelId: "ContactId",
                rowPrefix: "contact-",
                useHighlight: true,
                createPath: '/tableLiveEdit/Contacts',
                showPath: '/tableLiveEdit/Contacts/{0}',
                updatePath: '/tableLiveEdit/Contacts/{0}',
                deleteConfirmation: 'You are about to delete a contact. This operation cannot be undone. Are you absolutely sure you wish to continue?'
            };
            $("#contacts").tableLiveEdit(options);            
        });
    </script>

    <h2>Contacts</h2>

    <table id="contacts">
        <thead>
            <tr>            
                <td style="width:28%;">First Name</td>
                <td style="width:28%;">Last Name</td>
                <td style="width:28%;">Email Address</td>
                <td style="width:15%;">&nbsp;</td>
            </tr>
        </thead>
        <tbody>
        <% foreach (var contact in Model) { %>  
            <% Html.RenderPartial("ShowPartial", contact); %>              
        <% } %>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4"><%= Html.ActionLink("Create New Contact", "New", new {}, new { id = "add-link" }) %></td>
            </tr>
        </tfoot>
    </table>
    
    <p>
        The jQuery plugin raises an event called "tableLiveEdit.formLoaded" on the wrapper
        form. (The default form is named "_tableLiveEdit", but this value can be configured.)
        You can write your javascript to listen to the event in the following manner. This
        allows you to use other tools, such a jQuery form validation.
    </p>
    <pre>
$("_tableLiveEdit").bind("tableLiveEdit.formLoaded", function() {<br />
    alert("a new form was loaded");<br />
});<br />
    </pre>

</asp:Content>


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
                useHighlight: false,
                createPath: '/Contacts',
                showPath: '/Contacts/{0}',
                updatePath: '/Contacts/{0}',
                deleteConfirmation: 'You are about to delete a contact. This operation cannot be undone. Are you absolutely sure you wish to continue?'
            };
            $("#contacts").tableLiveEdit(options);
            $(".delete-link").click(function() {
                var path = $(this).attr("href");
                var row = $(this).parents("tr");
                $.ajax({ url: path, method: "DELETE" });
            });
        });
    </script>

    <h2>Contacts</h2>

    <table id="contacts">
        <thead>
            <tr>            
                <td>First Name</td>
                <td>Last Name</td>
                <td>Email Address</td>
                <td>&nbsp;</td>
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

</asp:Content>


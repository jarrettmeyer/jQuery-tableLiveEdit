(function($) {


    $.fn.tableLiveEdit = function(settings) {
        var config = {
            formId: "_tableLiveEdit",           // ID of the form created by the plugin

            addLink: "add-link", 		        // ID for the add link
            cancelButton: "live-edit-cancel",   // ID for the cancel button (generated)
            createButton: "live-edit-create",   // ID for the create button (generated)
            editLink: "edit-link", 	            // Class for the edit links
            rowPrefix: "row-", 			        // Row prefix for each <tr id="?"> value
            updateButton: "live-edit-update",   // ID for the update button	(generated)

            getEdit: "./edit",      // GET url path to return a single row edit template
            getNew: "./new",        // GET url path to return a new row edit template
            getRow: "./show",       // GET url path to return a single row
            postCreate: "./create", // POST url path to create a new row
            postUpdate: "./udpate", // POST url path to update an existing row

            useHighlight: false
        };
        if (settings) $.extend(config, settings);
        return this.each(function() {
            var table = $(this);
            var prepConfig = function() {
                if (!config.getEdit.match(/\/$/)) config.getEdit += "/";
                if (!config.getNew.match(/\/$/)) config.getNew += "/";
                if (!config.getRow.match(/\/$/)) config.getRow += "/";
            };
            var ensureFormExists = function() {
                var forms = $(this).parents("form");
                if (forms.length == 0) {
                    table.wrap("<form action=\"\" method=\"post\" id=\"" + config.formId + "\"></form>");
                }
            };
            var registerAddLink = function() {
                $("#" + config.addLink).click(function() {
                });
            };
            var registerCancelButton = function() {
            };
            var registerCreateButton = function() {
            };
            var registerEditLinks = function() {
                $("." + config.editLink).click(function(e) {
                    e.preventDefault();
                    hideEditLinks();
                    var row = $(this).parents("tr");
                    var rowId = row[0].id.match(/(\d+)/)[1];
                    $.get(config.getEdit + rowId, {}, function(html) {
                        row.replaceWith(html);
                        registerCancelButton();
                        registerUpdateButton();
                    });
                });
            };
            var registerUpdateButton = function() {
            };
            var submitForm = function() {
            };
            var showEditLinks = function() {
                $("#" + config.addLink).parents("tr").show();
                $("." + config.editLink).show();
            };
            var hideEditLinks = function() {
                $("#" + config.addLink).parents("tr").hide();
                $("." + config.editLink).hide();
            };
            prepConfig();
            ensureFormExists();
            registerEditLinks();
        });
    };

    function registerEditLinks(config) {
        var selector = "." + config.editLink;
        $(selector).click(function(e) {
            e.preventDefault();
            hideEditLinks();
            var row = $(this).parents("tr");
            var rowId = row[0].id.match(/(\d+)/)[1];
            $.get(config.getEdit + "/" + rowId, {}, function(html) {
                row.replaceWith(html);
                registerUpdateButton();
                registerCancelButton();
            });
        });
    };

    function hideEditLinks() {
    };

    function showEditLinks() {
    };

})(jQuery);

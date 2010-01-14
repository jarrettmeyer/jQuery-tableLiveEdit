(function($) {
    $.fn.tableLiveEdit = function(settings) {
        var config = {
            formId: "_tableLiveEdit",           // ID of the form created by the plugin
            modelId: "id",                      // ID of the element being added or edited (possibly a hidden field)

            addLink: "add-link",                // ID for the add link
            cancelButton: "live-edit-cancel",   // ID for the cancel button (generated)
            createButton: "live-edit-create",   // ID for the create button (generated)
            editLink: "edit-link",              // Class for the edit links
            rowPrefix: "row-",                  // Row prefix for each <tr id="?"> value
            updateButton: "live-edit-update",   // ID for the update button	(generated)

            getEdit: "./edit",      // GET url path to return a single row edit template
            getNew: "./new",        // GET url path to return a new row edit template
            getRow: "./show",       // GET url path to return a single row
            postCreate: "./create", // POST url path to create a new row
            putUpdate: "./udpate",  // PUT url path to update an existing row
            usePostUpdate: false,   // Should the update URL be called with a POST request, instead of a PUT request

            useHighlight: false
        };
        if (settings) { $.extend(config, settings); }
        return this.each(function() {
            var table = $(this);
            (function() {
                var methods = {
                    prepConfig: function() {
                        if (!config.getEdit.match(/\/$/)) { config.getEdit += "/"; }
                        if (!config.getNew.match(/\/$/)) { config.getNew += "/"; }
                        if (!config.getRow.match(/\/$/)) { config.getRow += "/"; }
                    },
                    ensureFormExists: function() {
                        var forms = $(this).parents("form");
                        if (forms.length === 0) {
                            table.wrap("<form action=\"\" method=\"post\" id=\"" + config.formId + "\"></form>");
                        }
                    },
                    registerAddLink: function() {
                        $("#" + config.addLink).unbind("click");
                        $("#" + config.addLink).click(function(e) {
                            e.preventDefault();
                            methods.hideEditLinks();
                            $.get(config.getNew, {}, function(html) {
                                $("tbody").append(html);
                                methods.registerCreateButton();
                                methods.registerCancelButton();
                            });
                        });
                    },
                    registerCancelButton: function() {
                        $("#" + config.cancelButton).click(function(e) {
                            e.preventDefault();
                            var rowId = $("#" + config.modelId).val();
                            var selector = "#" + config.rowPrefix + rowId;
                            if (rowId > 0) {
                                $.get(config.getRow + rowId, {}, function(html) {
                                    $(selector).replaceWith(html);
                                });
                            } else {
                                $(selector).remove();
                            }
                            methods.showEditLinks();
                        });
                    },
                    registerCreateButton: function() {
                        $("#" + config.createButton).click(function(e) {
                            methods.submitForm(this, e, config.postCreate, true);
                        });
                    },
                    registerEditLinks: function() {
                        $("." + config.editLink).unbind("click");
                        $("." + config.editLink).click(function(e) {
                            e.preventDefault();
                            methods.hideEditLinks();
                            var row = $(this).parents("tr");
                            var rowId = row[0].id.match(/(\d+)/)[1];
                            $.get(config.getEdit + rowId, {}, function(html) {
                                row.replaceWith(html);
                                methods.registerCancelButton();
                                methods.registerUpdateButton();
                            });
                        });
                    },
                    registerUpdateButton: function() {
                        $("#" + config.updateButton).click(function(e) {
                            methods.submitForm(this, e, config.putUpdate, false);
                        });
                    },
                    submitForm: function(element, event, url, isNew) {
                        event.preventDefault();
                        var formData = $("#" + config.formId).serialize();
                        var rowId = $("#" + config.modelId).val();
                        var selector = "#" + config.rowPrefix + rowId;
                        var requestType = (isNew || config.usePostUpdate) ? "post" : "put";
                        $.ajax({
                            type: requestType,
                            url: url,
                            data: formData,
                            dataType: "html",
                            success: function(html) {
                                $(selector).replaceWith(html);
                                var flashRow = isNew ? "tbody tr:last" : selector;
                                if (config.useHighlight) { $(flashRow).effect("highlight", {}, 3000); }
                                methods.showEditLinks();
                                methods.registerEditLinks();
                            }
                        });
                    },
                    showEditLinks: function() {
                        $("#" + config.addLink).parents("tr").show();
                        $("." + config.editLink).show();
                    },
                    hideEditLinks: function() {
                        $("#" + config.addLink).parents("tr").hide();
                        $("." + config.editLink).hide();
                    }
                };
                methods.prepConfig();
                methods.ensureFormExists();
                methods.registerAddLink();
                methods.registerEditLinks();
            }
            )();
        });
    };
})(jQuery);

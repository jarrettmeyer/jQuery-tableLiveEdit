/* jQuery.tableLiveEdit.js
* Documentation: http://jarrettmeyer.com/portfolio/jQuery-tableLiveEdit/ 
* License: http://jarrettmeyer.com/license/
* Version: 1.0.4
*/
(function($) {
    $.fn.tableLiveEdit = function(settings) {
        var config = {
            addFormId: "tableLiveEdit-addForm",  // ID of the add form created by the plugin
            editFormId: "tableLiveEdit-editForm", // ID of the edit form created by the plugin
            modelId: "id",                      // ID of the element being added or edited (possibly a hidden field)
            addLink: "add-link",                // ID for the add link
            cancelButton: "live-edit-cancel",   // ID for the cancel button (generated)
            createButton: "live-edit-create",   // ID for the create button (generated)
            deleteLink: "delete-link",          // Class for delete links
            deleteConfirmation: "Are you sure?",
            editLink: "edit-link",              // Class for the edit links
            rowPrefix: "row-",                  // Row prefix for each <tr id="?"> value
            updateButton: "live-edit-update",   // ID for the update button	(generated)
            createPath: "./create",
            showPath: "./show/{0}",
            updatePath: "./{0}/update",
            usePostDelete: false,   // Should the delete URL be called with a POST request, instead of a DELETE request
            usePostUpdate: false,   // Should the update URL be called with a POST request, instead of a PUT request
            useHighlight: false
        };
        if (settings) { $.extend(config, settings); }
        return this.each(function() {
            var table = $(this);
            (function() {
                var formLoaded = false;
                var formSelector = '';
                var methods = {
                    createForm: function(formId) {
                        var forms = table.parents("form");
                        if (forms.length === 0) {
                            table.wrap("<form action=\"\" method=\"post\" id=\"" + formId + "\"></form>");
                            formLoaded = true;
                            formSelector = "#" + formId;
                        } else if (forms.length === 1) {
                            forms.attr("id", formId);
                            formLoaded = true;
                            formSelector = "#" + formId;
                        } else {
                            formLoaded = false;
                            formSelector = "";
                        }
                    },
                    registerAddLink: function() {
                        $("#" + config.addLink).live("click", function(e) {
                            e.preventDefault();
                            methods.createForm(config.addFormId);
                            var url = $(this).attr("href");
                            methods.hideEditLinks();
                            $.get(url, {}, function(html) {
                                $("tbody").append(html);
                                $(formSelector).trigger("tableLiveEdit.addFormLoaded");
                                formLoaded = true;
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
                                $.get(config.showPath.replace("{0}", rowId), {}, function(html) {
                                    $(selector).replaceWith(html);
                                });
                            } else {
                                $(selector).remove();
                            }
                            methods.showEditLinks();
                            $(formSelector).trigger("tableLiveEdit.formUnloaded");
                            formLoaded = false;
                        });
                    },
                    registerCreateButton: function() {
                        $("#" + config.createButton).click(function(e) {
                            methods.submitForm(this, e, config.createPath, true);
                        });
                    },
                    registerDeleteLinks: function() {
                        $("." + config.deleteLink).live("click", function(e) {
                            e.preventDefault();
                            if (config.deleteConfirmation && !window.confirm(config.deleteConfirmation)) { return false; }
                            var link = $(this);
                            var requestType = config.usePostDelete ? "post" : "delete";
                            $.ajax({
                                type: requestType,
                                url: link.attr("href")
                            });
                            link.parents("tr").remove();
                        });
                    },
                    registerEditLinks: function() {
                        $("." + config.editLink).live("click", function(e) {
                            e.preventDefault();
                            methods.createForm(config.editFormId);
                            methods.hideEditLinks();
                            var url = $(this).attr("href");
                            var row = $(this).parents("tr");
                            $.get(url, {}, function(html) {
                                row.replaceWith(html);
                                $(formSelector).trigger("tableLiveEdit.editFormLoaded");
                                formLoaded = true;
                                methods.registerCancelButton();
                                methods.registerUpdateButton();
                            });
                        });
                    },
                    registerUpdateButton: function() {
                        $("#" + config.updateButton).click(function(e) {
                            var id = $(this).parents("tr")[0].id.match(/(\d+)/)[1];
                            methods.submitForm(this, e, config.updatePath.replace("{0}", id), false);
                        });
                    },
                    submitForm: function(element, event, url, isNew) {
                        event.preventDefault();
                        var formData = $(formSelector).serialize();
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
                                $(formSelector).trigger("tableLiveEdit.formUnloaded");
                                formLoaded = false;
                            }
                        });
                    },
                    showEditLinks: function() {
                        $("#" + config.addLink).parents("tr").show();
                        $("." + config.editLink).show();
                        $("." + config.deleteLink).show();
                    },
                    hideEditLinks: function() {
                        $("#" + config.addLink).parents("tr").hide();
                        $("." + config.editLink).hide();
                        $("." + config.deleteLink).hide();
                    }
                };
                methods.registerAddLink();
                methods.registerEditLinks();
                methods.registerDeleteLinks();
            })();
        });
    };
})(jQuery);

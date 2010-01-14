/* jQuery.tableLiveEdit.js
* Documentation: http://jarrettmeyer.com/portfolio/jQuery-tableLiveEdit/ 
* License: http://jarrettmeyer.com/license/
* Version: 1.0.2
*/
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
            createPath: "./create",
            showPath: "./show/{0}",
            updatePath: "./{0}/update",
            usePostUpdate: false,   // Should the update URL be called with a POST request, instead of a PUT request
            useHighlight: false
        };
        if (settings) { $.extend(config, settings); }
        return this.each(function() {
            var table = $(this);
            (function() {
                var methods = {
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
                            var url = $(this).attr("href");
                            methods.hideEditLinks();
                            $.get(url, {}, function(html) {
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
                                $.get(config.showPath.replace("{0}", rowId), {}, function(html) {
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
                            methods.submitForm(this, e, config.createPath, true);
                        });
                    },
                    registerEditLinks: function() {
                        $("." + config.editLink).unbind("click");
                        $("." + config.editLink).click(function(e) {
                            e.preventDefault();
                            methods.hideEditLinks();
                            var url = $(this).attr("href");
                            var row = $(this).parents("tr");
                            var rowId = row[0].id.match(/(\d+)/)[1];
                            $.get(url, {}, function(html) {
                                row.replaceWith(html);
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
                methods.ensureFormExists();
                methods.registerAddLink();
                methods.registerEditLinks();
            })();
        });
    };
})(jQuery);

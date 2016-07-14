/*
 *  jquery.sortable.modal.js - v0.1.3
 *  Author @Daniel
 *  v0.1.4 - 2016/06/15 - rename 'FilePath' to 'BaseImagePath'
 *  v0.1.3 - 2016/05/05 - add setting 'displayName' & 'required'
 *  v0.1.2 - 2016/04/26 - add modal type 'Color'
 *  v0.1.1 - 2016/04/17 - add modal type 'Editor'
 *  v0.1.0 - 2016/04/16 - init
 * 
 *  =======================================================================
 *  jquery-boilerplate - v4.0.0
 *  A jump-start for jQuery plugins development.
 *  http://jqueryboilerplate.com
 *
 *  Made by Zeno Rocha
 *  Under MIT License
 * 
 */
// the semi-colon before function invocation is a safety net against concatenated
// scripts and/or other plugins which may not be closed properly.
; (function ($, window, document, undefined) {

    "use strict";

    // undefined is used here as the undefined global variable in ECMAScript 3 is
    // mutable (ie. it can be changed by someone else). undefined isn't really being
    // passed in so we can ensure the value of it is truly undefined. In ES5, undefined
    // can no longer be modified.

    // window and document are passed through as local variable rather than global
    // as this (slightly) quickens the resolution process and can be more efficiently
    // minified (especially when both are regularly referenced in your plugin).

    // Create the defaults once
    var pluginName = "SortableModal",
        defaults = {
            //propertyName: "value"
            frameSrc: "/fileman/index.html?integration=custom&txtFieldId=BaseImagePath",
            idCounter: 0,
            updateId: -1,
            imageOption: '?mode=crop&w=200&h=150', // 縮圖裁切設定
            editableList: null,
            data: [],
            model: [
                {
                    key: 'BaseImagePath',
                    type: 'Image',
                    displayName: '圖片',
                    required: true
                },
                {
                    key: 'Title',
                    type: 'Text',
                    displayName: '標題',
                    required: false
                },
            ]
        };

    // The actual plugin constructor
    function Plugin(element, options) {
        this.element = element;

        // jQuery has an extend method which merges the contents of two or
        // more objects, storing the result in the first object. The first object
        // is generally empty as we don't want to alter the default options for
        // future instances of the plugin
        this.settings = $.extend({}, defaults, options);
        this._defaults = defaults;
        this._name = pluginName;
        this.init();

        // define the public API
        var API = {};
        API.closeModal = this.closeModal;
        return API;
    }

    // Avoid Plugin.prototype conflicts
    $.extend(Plugin.prototype, {
        init: function () {
            var self = this;
            // Place initialization logic here
            // You already have access to the DOM element and
            // the options via the instance, e.g. this.element
            // and this.settings
            // you can add more functions like the one below and
            // call them like the example bellow
            //this.yourOtherFunction( "jQuery Boilerplate" );

            //console.log(this.settings);
            //console.log(this._defaults);
            //console.log(this._name);

            var $form = $('#itemModalForm');

            // Editable list
            this.settings.editableList = Sortable.create(editable, {
                animation: 150,
                filter: '.js-remove, .js-edit',
                onFilter: function (evt) {
                    var item = evt.item,
                        ctrl = evt.target;

                    /* remove item */
                    if (Sortable.utils.is(ctrl, ".js-remove")) {
                        //console.log('js-remove');
                        if (!confirm('確認刪除?')) return false;
                        var el = self.settings.editableList.closest(evt.item); // get dragged item
                        el && el.parentNode.removeChild(el);
                    }
                        /* edit item */
                    else if (Sortable.utils.is(ctrl, ".js-edit")) {
                        //console.log('js-edit');
                        self.settings.updateId = item.dataset.id;
                        bindJSON2Form(self.settings.data[self.settings.updateId]);
                        $('#create-btn').addClass('hidden');
                        $('#update-btn').removeClass('hidden');
                    }
                }
            });


            InitJSON2Form(this.settings.model);

            // init photo
            $.each(this.settings.data, function (index, value) {
                renderList(value);
            });

            $('#create-btn').on('click', createItem);
            $('#update-btn').on('click', updateItem);

            $('#BaseImagePath-btn').click(function () {
                $('#FileSelecter').modal('show');
            })

            $('#FileSelecter').on('shown.bs.modal', function (event) {      //correct here use 'shown.bs.modal' event which comes in bootstrap3
                if (!$(this).find('iframe').attr('src')) {
                    $(this).find('iframe').attr('src', self.settings.frameSrc);
                }
            })

            $('#itemModal').on('show.bs.modal', function (e) {
                //console.log('show.bs.modal');
                //console.log(e.target);
                if (e.target.id !== 'itemModal') {
                    return false;
                }
                $('#update-btn').addClass('hidden');
                $('#create-btn').removeClass('hidden');
            })

            $('#itemModal').on('hidden.bs.modal', function (e) {
                document.getElementById('itemModalForm').reset();
                // 清除顏色
                $form.find('.colorpicker-component').find('i').css('background-color', '');
            })

            function _validation(data) {

                var json = self.settings.model;

                var msg = "";
                for (var i = 0; i < json.length; i++) {

                    var item = json[i];
                    var key = item['key'];
                    var displayName = item['displayName'] || key;
                    //console.log(item, json[i]);
                    //console.log(item['required'], data[ key ]);
                    if (item['required'] && !data[key]) {
                        msg += "> The " + displayName + " field is required.\n";
                    }
                }
                return msg;
            }

            function _getItemValue() {

                var json = self.settings.model;

                var temp = {};

                for (var i = 0; i < json.length; i++) {

                    var item = json[i];
                    var key = item['key'];
                    var $input = $form.find('#' + key);

                    if ($input.is("input")) {
                        var type = $input.attr('type');
                        //console.log('Input type:', type);
                        // <input> element.

                        switch (type) {
                            case 'checkbox':
                                temp[key] = $form.find("input[name='" + key + "']").is(":checked"); break;
                            case 'text':
                            default:
                                temp[key] = $form.find("input[name='" + key + "']").val();
                        }

                    } else if ($input.is("select")) {
                        // <select> element.
                        //console.log('Input type:', 'select');

                    } else if ($input.is("textarea")) {
                        // <textarea> element.
                        //console.log('Input type:', 'textarea');
                        //temp[key] = $form.find("textarea[name='" + key + "']").val();
                        temp[key] = tinyMCE.get(key).getContent();

                    }

                    //var type = $('#' + key).attr('type');
                    //switch (type) {
                    //    case 'checkbox':
                    //        //temp[key] = document.getElementById(key).checked; break;
                    //        temp[key] = $form.find("input[name='" + key + "']").is(":checked"); break;
                    //    case 'text':
                    //    default:
                    //        //temp[key] = document.getElementById(key).value;
                    //        temp[key] = $form.find("input[name='" + key + "']").val();
                    //}
                    //console.log('Create: key->' + key + ', value->' + temp[key] + ', type->' + self.settings.model[key]);

                }

                return temp;
            }

            function createItem() {

                var item = _getItemValue();

                var err = _validation(item);
                if (err) {
                    return alert(err);
                }

                //console.log('Create Item:', item);

                // add item into data
                self.settings.data.push(item);

                // add item into list
                renderList(item);

                // close modal
                $('#itemModal').modal('hide');

            }

            function updateItem() {

                var item = _getItemValue();

                var err = _validation(item);
                if (err) {
                    return alert(err);
                }

                //console.log('Update Item:', item);

                // update data
                self.settings.data[self.settings.updateId] = item;

                // update thumbs
                $('#editable').find("[data-id='" + self.settings.updateId + "'] img")
                              .attr({
                                  'src': item['BaseImagePath'] + self.settings.imageOption,
                                  'alt': item['Title'],
                                  'title': item['Title']
                              });

                // close modal
                $('#itemModal').modal('hide');
            }

            function renderList(item) {
                var src = "http://placehold.it/200x150?text=IMAGE";
                if (item['BaseImagePath']) {
                    src = item['BaseImagePath'] + self.settings.imageOption;
                }
                var el = document.createElement('li');
                el.dataset.id = self.settings.idCounter++;
                el.className = 'col-lg-3 col-sm-4 col-xs-6';
                el.innerHTML = '<img src="' + src + '" alt="' + item['Title'] + '" title="' + item['Title'] + '" ><i class="ion-compose js-edit" title="編輯"></i><i class="ion-android-close js-remove" title="刪除"></i>';
                self.settings.editableList.el.appendChild(el);
            }

            function InitJSON2Form(json) {

                //console.log('Init SortableModal:', json);

                for (var i = 0; i < json.length; i++) {

                    //console.log('Init: key->', i, ', type->', json[i]);

                    var item = json[i];
                    var key = item['key'];
                    var displayName = item['displayName'] || key;
                    var required = item['required'] ? " required" : "";

                    if (item['key'] === 'BaseImagePath') {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<div class="input-group">' +
                                        '<input type="text" id="' + key + '" name="' + key + '" class="form-control" readonly="readonly" />' +
                                        '<span class="input-group-btn">' +
                                            '<button id="BaseImagePath-btn" class="btn btn-default" type="button"><i class="fa fa-picture-o"></i></button>' +
                                        '</span>' +
                                    '</div>' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);
                    }

                    else if (item['key'] === 'Title') {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<input type="text" id="' + key + '" name="' + key + '" class="form-control" />' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);
                    }

                    else if (item['type'] === 'Date') {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<div class="input-group date">' +
                                        '<span class="input-group-addon"><i class="fa fa-calendar-check-o"></i></span>' +
                                        '<input type="text" id="' + key + '" name="' + key + '" class="form-control date" />' +
                                    '</div>' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);
                    }

                    else if (item['type'] === 'Checkbox') {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<div class="checkbox">' +
                                        '<label>' +
                                            '<input type="checkbox" id="' + key + '" name="' + key + '" />' +
                                        '</label>' +
                                    '</div>' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);
                    }

                    else if (item['type'] === 'Color') {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<div class="input-group colorpicker-component">' +
                                        '<span class="input-group-addon"><i></i></span>' +
                                        '<input type="text" id="' + key + '" name="' + key + '" class="form-control colorpicker" />' +
                                    '</div>' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);
                    }

                    else if (item['type'] === 'Editor') {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<textarea id="' + key + '" name="' + key + '"></textarea>' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);

                        tinyMCE.init({
                            selector: '#itemModalForm #' + key,
                            language: 'zh_TW',
                            statusbar: false,
                            relative_urls: false, // 使用絕對路徑
                            //// 強制使用base_url
                            //remove_script_host: false,
                            //document_base_url: "https://www.taiwan-panorama.com/",
                            theme: "modern",
                            skin: 'custom',
                            plugins: [
                                    "advlist autoresize autolink lists link image charmap print preview anchor",
                                    "searchreplace visualblocks code fullscreen",
                                    "colorpicker textcolor insertdatetime media table contextmenu paste"
                            ],
                            toolbar: "insertfile undo redo | styleselect | bold italic | forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image media",
                            file_browser_callback: RoxyFileBrowser
                        });

                    }

                    else {
                        var tpl_text =
                            '<div class="form-group">' +
                                '<label class="control-label col-md-2' + required + '">' + displayName + '</label>' +
                                '<div class="col-md-10">' +
                                    '<input type="text" id="' + key + '" name="' + key + '" class="form-control" />' +
                                '</div>' +
                            '</div>';
                        $form.append(tpl_text);
                    }

                }

                // color
                $form.find('.colorpicker-component').colorpicker({
                    align: 'left',
                    color: false
                });

            }

            function bindJSON2Form(json) {

                //console.log('Read item:', json);

                for (var key in json) {

                    if (json.hasOwnProperty(key)) {

                        //console.log('Init: key->', key, ', type->', json[key]);

                        var $input = $form.find('#' + key);

                        if ($input.hasClass('colorpicker')) {

                            if (json[key]) {

                                $input.closest('.colorpicker-component').colorpicker('setValue', json[key]);

                            } else {

                                // 清除顏色
                                $input.closest('.colorpicker-component').find('i').css('background-color', '');

                            }


                        } else if ($input.is("input")) {

                            var type = $input.attr('type');
                            //console.log('Input type:', type);
                            // <input> element.

                            switch (type) {
                                case 'checkbox':
                                    $form.find("input[name='" + key + "']").prop("checked", json[key]); break;
                                case 'text':
                                default:
                                    $form.find("input[name='" + key + "']").val(json[key]);
                            }

                        } else if ($input.is("select")) {
                            // <select> element.
                            //console.log('Input type:', 'select');

                        } else if ($input.is("textarea")) {
                            // <textarea> element.
                            //console.log('Input type:', 'textarea');
                            // prevent null
                            tinyMCE.get(key).setContent(json[key] || '');

                        }

                        //var type = $('#' + key).attr('type');
                        //console.log(type);
                        //switch (type) {
                        //    case 'checkbox':
                        //        //form.find("#" + key).prop("checked", json[key]); break;
                        //        $form.find("input[name='" + key + "']").prop("checked", json[key]); break;
                        //    case 'text':
                        //    default:
                        //        //form.find("#" + key).val(json[key]);
                        //        $form.find("input[name='" + key + "']").val(json[key]);
                        //}
                    }
                }

                $('#itemModal').modal('show');

            }

            $('#form').submit(function () {
                // get final itemArray
                var lastOrder = self.settings.editableList.toArray();
                var temp = [];
                for (var i = 0; i < lastOrder.length; i++) {
                    temp.push(self.settings.data[lastOrder[i]]);
                }
                //console.log(temp);
                var jsonString = JSON.stringify(temp).toString();
                //console.log(jsonString);
                $('#SM_JSON').val(jsonString);
            });



        },

        closeModal: function () {
            $('#FileSelecter').modal('hide');
        }


        //yourOtherFunction: function( text ) {

        //  // some logic
        //  $( this.element ).text( text );
        //}

    });

    // A really lightweight plugin wrapper around the constructor,
    // preventing against multiple instantiations
    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, "plugin_" + pluginName)) {
                $.data(this, "plugin_" +
                    pluginName, new Plugin(this, options));
            }
        });
    };

})(jQuery, window, document);

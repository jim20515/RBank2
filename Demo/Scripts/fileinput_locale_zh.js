/*!
 * FileInput Chinese Translations
 *
 * This file must be loaded after 'fileinput.js'. Patterns in braces '{}', or
 * any HTML markup tags in the messages must not be converted or translated.
 *
 * @see http://github.com/kartik-v/bootstrap-fileinput
 * @author kangqf <kangqingfei@gmail.com>
 *
 * NOTE: this file must be saved in UTF-8 encoding.
 */
(function ($) {
    "use strict";

    $.fn.fileinput.locales.tw = {
        fileSingle: '檔案',
        filePlural: '多個檔案',
        browseLabel: '選擇 &hellip;',
        removeLabel: '移除',
        removeTitle: '清除選中檔案',
        cancelLabel: '取消',
        cancelTitle: '取消進行中的上傳',
        uploadLabel: '上傳',
        uploadTitle: '上傳選取檔案',
        msgSizeTooLarge: '檔案 "{name}" (<b>{size} KB</b>) 超過了允許大小 <b>{maxSize} KB</b>. 請重新上傳!',
        msgFilesTooLess: '你必須選擇最少 <b>{n}</b> {files} 來上傳. 請重新上傳!',
        msgFilesTooMany: '選擇的上傳檔案個數 <b>({n})</b> 超出最大檔案的限制個數 <b>{m}</b>. 請重新上傳!',
        msgFileNotFound: '檔案 "{name}" 未找到!',
        msgFileSecured: '安全限制，為了防止讀取檔案 "{name}".',
        msgFileNotReadable: '檔案 "{name}" 不可讀.',
        msgFilePreviewAborted: '取消 "{name}" 的預覽.',
        msgFilePreviewError: '讀取 "{name}" 時出現了一個錯誤.',
        msgInvalidFileType: '不正確的類型 "{name}". 只支持 "{types}" 類型的檔案.',
        msgInvalidFileExtension: '不正確的副檔名 "{name}". 只支持 "{extensions}" 的副檔名.',
        msgValidationError: '檔案上傳錯誤',
        msgLoading: '載入第 {index} 檔案 共 {files} &hellip;',
        msgProgress: '載入第 {index} 檔案 共 {files} - {name} - {percent}% 完成.',
        msgSelected: '{n} 個檔案選中',
        msgFoldersNotAllowed: '僅支援拖曳檔案! 跳過 {n} 拖曳的資料夾.',
        dropZoneTitle: '拖曳檔案到此處 &hellip;',
        slugCallback: function(text) {
            return text ? text.split(/(\\|\/)/g).pop().replace(/[^\w\u4e00-\u9fa5\-.\\\/ ]+/g, '') : '';
        }
    };

    $.extend($.fn.fileinput.defaults, $.fn.fileinput.locales.tw);
})(window.jQuery);

using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Helpers
{
    public static class CheckBoxListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="list">List&lt;CheckBoxModel&gt;</param>
        /// <param name="isInline">是否為橫式</param>
        /// <returns></returns>
        public static IHtmlString CheckBoxList(this HtmlHelper helper, string name, List<CheckBoxModel> list, bool isInline = true)
        {
            // #checkAll has change event
            string html = 
                "<div class=\"checkbox\">" +
                    "<label>" +
                        "<input type=\"checkbox\" id=\"checkAll\" /> 全選" +
                    "</label>" +
                "</div>" +
                "<hr style=\"margin: 10px 0;\" />";

            foreach (var item in list)
            {
                html += String.Format("<div class=\"{0}\"><label><input type=\"checkbox\" name=\"{1}\" value=\"{2}\" {3} /> {4}</label></div>", 
                    isInline ? "checkbox-inline" : "checkbox",
                    name, 
                    item.Id, 
                    item.IsSelected ? "checked" : "", 
                    item.Name);
            }

            return new HtmlString(html);
        }
    }
}
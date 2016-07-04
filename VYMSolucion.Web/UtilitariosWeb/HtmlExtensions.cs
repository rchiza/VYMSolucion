using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace VYMSolucion.Web.UtilitariosWeb
{
    public static class HtmlExtensions
    {
        const string READONLYCSSSTYLE = "black";
        


        public static string GetLanguage(this HtmlHelper helper)
        {
            return helper.ViewData["lng"].ToString();
        }


       

        /// <summary>
        /// Gets the New Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetNewIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-plusthick'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the NewDocument Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetNewDocumentIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-document'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the Modify Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetModifyIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-wrench'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the View Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetViewIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-person'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the New Delete image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetDeleteIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-trash'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the New Close image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetEndIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-closethick'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the New Check image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetCheckIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-check'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the New Note image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetNoteIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-note'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the New Pause image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetPauseIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-pause'>&nbsp;&nbsp;&nbsp;</span>");
        }

        
        /// <summary>
        /// Gets the New Play image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetPlayIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-play'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the Save Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetSaveIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-disk'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the Save Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetSearchIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-search'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the Return Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetReturnIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-arrowreturnthick-1-w'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the Send Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetSendIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-mail-closed'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Gets the Send Icon image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetSendAreaIco(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-mail-open'>&nbsp;&nbsp;&nbsp;</span>");
        }

        /// <summary>
        /// Mac 20150804 Gets the New Tag image. Review the JQuery css style
        /// </summary>        
        /// <returns></returns>
        public static MvcHtmlString GetTagIcon(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(@"<span class='ui-icon ui-icon-tag'>&nbsp;&nbsp;&nbsp;</span>");
        }

        #region Editors
        /// <summary>
        /// Its the same TextAreaFor but includes a css class when the element is readonly
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            if (CheckIsReadOnly(helper))
            {
                string v = "<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">" + helper.DisplayTextFor(expression).ToString() + "</p>";
                return MvcHtmlString.Create(v);
            }

            return helper.TextAreaFor(expression, htmlAttributes);
        }


        /// <summary>
        /// Its the same TextBoxFor but includes a css class when the element is readonly
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            if (CheckIsReadOnly(helper))
            {
                string v = "<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">" + helper.DisplayTextFor(expression).ToString() + "</p>";
                return MvcHtmlString.Create(v);
            }
            return helper.TextBoxFor(expression, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalCheckBoxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            if (CheckIsReadOnly(helper))
            {
                string v = "<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">" + helper.DisplayFor(expression).ToString() + "</p>";
                return MvcHtmlString.Create(v);
            }
            return helper.CheckBoxFor(expression, htmlAttributes);
        }

        /// <summary>
        /// Check con style si/no con <!--<T>--> model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalCheckBoxStyleFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            //variables a usar
            bool datoValido = true;
            StringBuilder html = new StringBuilder();

            //obtiene el valor
            Func<TModel, TProperty> res = expression.Compile();
            object viewDataObject = res(helper.ViewData.Model);

            //verifica si el valor es válido y boleano
            if (viewDataObject == null)
                datoValido = false;

            if ((viewDataObject is bool) == false)
                datoValido = false;

            if (datoValido)
            {
                //extrae el nombre y valor del campo elegido
                string name = helper.NameFor(expression).ToString();
                bool valor = (bool)viewDataObject;

                //Crea un Tag contenedor tipo div
                TagBuilder span = new TagBuilder("div");
                //al Div agrega la clase tipo switch
                span.AddCssClass("switch");
                //agrego los atributos enviados como parámetros
                if (htmlAttributes != null)
                {
                    var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                    span.MergeAttributes(attributes);
                }

                //Creo el contenedor del switch en la variable html
                html.Append(
                    "<input type = \"checkbox\" name=\"" + name + "\" class=\"cmn-toggle cmn-toggle-yes-no\" id=\"" + name +
                    "\" value = \"true\"");
                html.Append(valor ? " checked>" : "/>");
                html.Append("<label for=\"" + name + "\" data-on='Si' data-off='No'></label>");
                

                //al contenedor se le agrega el contenido del switch
                span.InnerHtml = html.ToString();

                //string final
                html = new StringBuilder(span.ToString());
            }

            return new MvcHtmlString(html.ToString());
        }

        /// <summary>
        /// Check con style si/no con <!--<T>--> model
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="nombre"></param>
        /// <param name="isChecked"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalCheckBoxStyle(this HtmlHelper htmlHelper, string nombre, bool isChecked = false, object htmlAttributes = null)
        {
            //variables a usar
            bool datoValido = true;
            StringBuilder html = new StringBuilder();

            
            
            datoValido = true;

            if (datoValido)
            {
                //extrae el nombre y valor del campo elegido
                string name = nombre;
                bool valor = isChecked;

                //Crea un Tag contenedor tipo div
                TagBuilder span = new TagBuilder("div");
                //al Div agrega la clase tipo switch
                span.AddCssClass("switch");
                //agrego los atributos enviados como parámetros
                if (htmlAttributes != null)
                {
                    var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                    span.MergeAttributes(attributes);
                }

                //Creo el contenedor del switch en la variable html
                html.Append(
                    "<input type = \"checkbox\" name=\"" + name + "\" class=\"cmn-toggle cmn-toggle-yes-no\" id=\"" + name +
                    "\" value = \"true\"");
                html.Append(valor ? " checked>" : "/>");
                html.Append("<label for=\"" + name + "\" data-on='Si' data-off='No'></label>");


                //al contenedor se le agrega el contenido del switch
                span.InnerHtml = html.ToString();

                //string final
                html = new StringBuilder(span.ToString());
            }

            return new MvcHtmlString(html.ToString());
        }


        /// <summary>
        /// Its the same TextBox helper but includes a css class when the element is readonly
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalTextBox(this HtmlHelper helper, string name, object htmlAttributes)
        {
            if (CheckIsReadOnly(helper))
            {
                string v = "<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">" + helper.DisplayText(name).ToString() + "</p>";
                return MvcHtmlString.Create(v);
            }
            return helper.TextBox(name, null, htmlAttributes);
        }

        /// <summary>
        /// Its the same DropDownListFor with support to read only mode
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="optionLabel"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, SelectList selectList, string optionLabel, object htmlAttributes)
        {
            if (CheckIsReadOnly(helper))
            {
                //Or just the selected element's label if read only               
                foreach (var item in selectList)
                {
                    if (item.Selected)
                    {
                        string v = "<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">" + item.Text + "</p>";
                        return MvcHtmlString.Create(v);
                    }

                }
                return MvcHtmlString.Empty;
            }

            return helper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes);
        }

        /// <summary>
        /// Its the same DropDownList helper but includes a css class when the element is readonly
        /// </summary>
        /// <param name="helper">The name of the form field</param>
        /// <param name="name"></param>
        /// <param name="selectList">The enumeration of SelectListItem instances used to populate the drop-down list.</param>
        /// <param name="optionLabel">Provides the text for a default empty-valued option, if it is not null.</param>
        /// <param name="htmlAttributes">An object containing the HTML attributes retrieved via reflection</param>
        /// <returns>Returns a select tag used to select a single option from a set of choices</returns>
        public static MvcHtmlString LocalDropDownList(this HtmlHelper helper, string name, SelectList selectList, string optionLabel, object htmlAttributes)
        {

            if (CheckIsReadOnly(helper))
            {
                //Or just the selected element's label if read only               
                foreach (var item in selectList)
                {
                    if (item.Selected)
                    {
                        string v = "<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">" + item.Text + "</p>";
                        return MvcHtmlString.Create(v);
                    }

                }
                return MvcHtmlString.Empty;
            }

            return helper.DropDownList(name, selectList, optionLabel, htmlAttributes);

        }

        /// <summary>
        /// Its the same ListBoxFor but includes a css class when the element is readonly
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="list"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LocalListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> list, object htmlAttributes) 
            where TProperty:IEnumerable<string>
        {
            if (CheckIsReadOnly(helper))
            {
                StringBuilder html = new StringBuilder();

                //In read-only, just show the list of selected items
                if (list != null)
                {
                    html = html.Append("<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">");
                    Func<TModel, TProperty> res = expression.Compile();
                    IEnumerable<string>  values = res(helper.ViewData.Model);
                    SelectListItem itemSelected;
                    foreach (var item in values)
                    {
                        itemSelected = list.FirstOrDefault(x => x.Value == item);
                        if (itemSelected != null)
                        {
                            html.Append(helper.Encode(itemSelected.Text));
                            html.Append("<br />");
                        }
                    }

                    html.Append("</p>");
                }

                return MvcHtmlString.Create(html.ToString());
            }

            return helper.ListBoxFor(expression, list, htmlAttributes);
        }

        /// <summary>
        /// Returns a select tag used to select a multiple options from a set of possible
        /// choices or a simple list when in read-only mode.
        /// </summary>
        /// <param name="helper">The HTML helper.</param>
        /// <param name="name">The name of the form field and used as a key to look up possible options.</param>
        /// <param name="list"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns>A select tag or a ul tag.</returns>
        public static MvcHtmlString LocalListBox(this HtmlHelper helper, string name, MultiSelectList list, object htmlAttributes)
        {

            if (CheckIsReadOnly(helper))
            {
                StringBuilder html = new StringBuilder();

                //In read-only, just show the list of selected items
                if (list != null)
                {
                    html = html.Append("<p align=\"left\" class=\"" + READONLYCSSSTYLE + "\">");

                    foreach (var item in list)
                    {
                        if (item.Selected)
                        {
                            html.Append(helper.Encode(item.Text));
                            html.Append("<br />");
                        }
                    }

                    html.Append("</p>");
                }

                return MvcHtmlString.Create(html.ToString());
            }

            return helper.ListBox(name, null, htmlAttributes);

        }

        #endregion

        /// <summary>
        /// Gets a boolean indicating if "ReadOnly" has been defined in the ViewData.
        /// </summary>
        /// <param name="helper">The HTML helper.</param>        
        /// <returns>The boolean value contained in the ViewData or false if empty</returns>
        public static bool CheckIsReadOnly(this HtmlHelper helper)
        {
            return GetBooleanValue(helper, "ReadOnly");
        }

        /// <summary>
        /// Gets the boolean value from a ViewData item.
        /// </summary>
        /// <param name="helper">The Html helper.</param>
        /// <param name="name">The name of the ViewData item.</param>
        /// <returns></returns>
        public static bool GetBooleanValue(this HtmlHelper helper, string name)
        {
            object viewDataObject = helper.ViewData[name];

            if (viewDataObject == null)
                return false;

            if (viewDataObject is bool)
                return (bool)viewDataObject;

            return false;
        }
               
    }
}
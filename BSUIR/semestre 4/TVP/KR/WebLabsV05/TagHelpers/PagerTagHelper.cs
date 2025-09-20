using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebLabsV05.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;
        IUrlHelper urlHelper;
        // номер текущей страницы
        public int PageCurrent { get; set; }
        // общее количество страниц
        public int PageTotal { get; set; }
        // дополнительный css класс пейджера
        public string PagerClass { get; set; }
        // имя action
        public string Action { get; set; } 
        // имя контроллера
        public string Controller { get; set; } 
        public int? GroupId { get; set; }

        public PagerTagHelper(IUrlHelperFactory uhf, IUrlHelper helper)
        {
            urlHelperFactory = uhf;
            urlHelper = helper;
        }
         
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
            
            // контейнер разметки пейджера
            //var result = new TagBuilder("nav");
            output.TagName ="nav";

            // пейджер
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);

            for(int i=1;i<=PageTotal; i++)
            {
                var url = urlHelper.Action(new UrlActionContext
                {
                    // формирование адреса ссылки
                    Action = Action,
                    Controller = Controller,
                    Values = new
                    {
                        pageNo = i,
                        group = GroupId == 0
                                ? null
                                : GroupId
                    }
                }); ;
                // получение разметки одной кнопки пейджера
                var item = GetPagerItem(
                        url: url, text: i.ToString(),
                        active: i == PageCurrent
                    );
                // добавить кнопку в разметку пейджера
                ulTag.InnerHtml.AppendHtml(item);
            }
            // добавить пейджер в контейнер
            output.Content.AppendHtml(ulTag);
            // поместить контейнер в окончательную разметку
            //output.Content.AppendHtml(result);
        }

        /// <summary>
        /// Генерирует разметку одной кнопки пейджера       
        /// </summary>
        /// <param name="url">адрес</param>
        /// <param name="text">текст кнопки пейджера</param>
        /// <param name="active">признак текущей страницы</param>
        /// <param name="disabled">запретить доступ к унопке</param>
        /// <returns>объект класса TagBuilder</returns>
        private TagBuilder GetPagerItem(string url, string text, 
                                        bool active = false, 
                                        bool disabled=false)
        {
            // создать тэг <li>
            var liTag = new TagBuilder("li");
            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");
            liTag.AddCssClass(disabled ? "disabled" : "");

            // создать тэг <a>
            var aTag = new TagBuilder("a");
            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);

            // добавить тэг <a> внутрь <li>
            liTag.InnerHtml.AppendHtml(aTag);
            
            return liTag;
        }
    }
}

using System.Linq;
using System.Reflection;
using FubuMVC.Core.View;
using HtmlTags;

namespace BabyFubuApp.Core
{
    public static class HtmlExtensions
    {
         public static HtmlTag BuildFormFor<T>(this IFubuPage page) where T : class
         {
             var type = typeof (T);

             var form = new FormTag("/" + typeof (T).Name.ToLower() + "s");

             var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

             foreach(var name in props.Select(prop => prop.Name))
             {
                 form.Append(new DivTag("")
                                 .Append(new HtmlTag("label").Attr("for", name).Text(name))
                                 .Append(new DivTag("")
                                             .Append(new HtmlTag("input").Id(name).Attr("name", name).Attr("type",
                                                                                                           "text"))));
             }

             form.Add("button").Attr("type", "submit").Text("Save Changes");
             form.Add("text").Text(" ");
             form.Add("button").Attr("type", "reset").Text("Clear Form");
             form.Method("POST");

             return form;
         }
    }
}
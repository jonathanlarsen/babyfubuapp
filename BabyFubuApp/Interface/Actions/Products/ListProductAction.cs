using System.Linq;
using BabyFubuApp.Core;
using BabyFubuApp.Domain;
using HtmlTags;

namespace BabyFubuApp.Interface.Actions.Products
{
    public class ListProductAction
    {
        private readonly CrudService<Product> _crudService;

        public ListProductAction(CrudService<Product> crudService)
        {
            _crudService = crudService;
        }

        public HtmlDocument List()
        {
            var products = _crudService.FindAll().OrderBy(x => x.Number).ToList();

            var document = new HtmlDocument();

            var container = new DivTag("");

            container.Append(new HtmlTag("h1").Text("Products"));

            var table = new TableTag();
            var header = new TableRowTag();
            header.Cell().Append(new HtmlTag("span").Text("Name"));
            header.Cell().Append(new HtmlTag("span").Text("Number"));
            header.Cell().Append(new HtmlTag("span").Text("Price"));
            table.Append(header);
            foreach (var product in products)
            {
                var row = new TableRowTag();
                row.Cell().Append(new LinkTag(product.Name, "/products/" + product.Id));
                row.Cell().Append(new HtmlTag("span").Text(product.Number.ToString()));
                row.Cell().Append(new HtmlTag("span").Text("$" + product.Price.ToString("F2")));
                table.Append(row);
            }
            document.Add(table);
            return document;
        }
    }
}
using System;
using BabyFubuApp.Core;
using BabyFubuApp.Domain;
using HtmlTags;

namespace BabyFubuApp.Interface.Actions.Products
{
    public class ViewProductAction
    {
        private readonly CrudService<Product> _crudService;

        public ViewProductAction(CrudService<Product> crudService)
        {
            _crudService = crudService;
        }

        public HtmlDocument Products_Id(ViewProductRequest request)
        {
            var product = _crudService.Retrieve(request.Id);

            var document = new HtmlDocument();
            var container = new DivTag("");

            container.Append(new HtmlTag("h1").Text(product.Number + " - " + product.Name));
            container.Append(new HtmlTag("h2").Text("$" + product.Price.ToString("F2")));
            container.Append(new HtmlTag("h3").Text(product.Description));

            document.Add(container);
            return document;
        }
    }

    public class ViewProductRequest
    {
        public Guid Id { get; set; }
    }
}
using BabyFubuApp.Core;
using BabyFubuApp.Domain;
using FubuMVC.Core;

namespace BabyFubuApp.Interface.Actions.Products
{
    public class CreateProductAction
    {
        private readonly CrudService<Product> _crudService;

        public CreateProductAction(CrudService<Product> crudService)
        {
            _crudService = crudService;
        }

        public JsonMessage Post(AddProductModel model)
        {
            var product = new Product(model.Name, model.Number, model.Price)
                              {
                                  Description = model.Description
                              };

            _crudService.Create(product);

            return null;
        }
    }

    public class AddProductModel
    {
        public virtual string Name { get; set; }
        public virtual int Number { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
    }
}
using BabyFubuApp.Domain;
using FubuMVC.WebForms;

namespace BabyFubuApp.Interface.Actions.Products.Add
{
    public class AddProductFormAction
    {
        public AddProductModel Add()
        {
            return new AddProductModel();
        } 
    }

    public class AddProductModel
    {
        public Product Product { get; set; }
    }

    public class AddProduct : FubuPage<AddProductModel> {}
}
<%@ Page Title="Add Product" Language="C#" Inherits="BabyFubuApp.Interface.Actions.Products.Add.AddProduct" MasterPageFile="~/Interface/Actions/Shared/Site.master" %>
<%@ Import Namespace="BabyFubuApp.Core" %>
<%@ Import Namespace="BabyFubuApp.Domain" %>
<asp:Content runat="server" ID="ContentHead" ContentPlaceHolderID="ContentHead"></asp:Content>
<asp:Content runat="server" ID="unknown" ContentPlaceHolderID="ContentPlaceHolder">
    <%= this.BuildFormFor<Product>() %>
</asp:Content>

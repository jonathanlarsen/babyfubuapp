﻿using FubuMVC.WebForms;

namespace BabyFubuApp.Interface
{
    public class HomeAction
    {
         public HomeModel Home()
         {
             return new HomeModel();
         }
    }

    public class HomeModel {}

    public class Home : FubuPage<HomeModel> {}
}
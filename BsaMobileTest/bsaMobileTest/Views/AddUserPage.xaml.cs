﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bsaMobileTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPage : ContentPage
    {
        public AddUserPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddUserViewModel();
        }
    }
}
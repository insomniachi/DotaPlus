﻿using DotaPlus.Contracts.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace DotaPlus.Helpers
{
    public static class NavigationHelper
    {
        // This helper class allows to specify the page that will be shown when you click on a NavigationViewItem
        //
        // Usage in xaml:
        // <winui:NavigationViewItem x:Uid="Shell_Main" Icon="Document" helpers:NavigationHelper.NavigateTo="AppName.ViewModels.MainViewModel" />
        //
        // Usage in code:
        // NavigationHelper.SetNavigateTo(navigationViewItem, typeof(MainViewModel).FullName);
        public static string GetNavigateTo(NavigationViewItem item)
        {
            return (string)item.GetValue(NavigateToProperty);
        }

        public static void SetNavigateTo(NavigationViewItem item, string value)
        {
            item.SetValue(NavigateToProperty, value);
        }

        public static readonly DependencyProperty NavigateToProperty =
            DependencyProperty.RegisterAttached("NavigateTo", typeof(string), typeof(NavigationHelper), new PropertyMetadata(null));


        public static void NavigateTo<T>(this INavigationService service, object parameter = null, bool clearNavigation = false)
        {
            service.NavigateTo(typeof(T).FullName, parameter, clearNavigation);
        }
    }
}

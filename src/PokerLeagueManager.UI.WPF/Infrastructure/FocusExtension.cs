﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PokerLeagueManager.UI.Wpf.Infrastructure
{
    public static class FocusExtension
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool?), typeof(FocusExtension), new FrameworkPropertyMetadata(IsFocusedChanged));

        public static bool? GetIsFocused(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            return (bool?)element.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject element, bool? value)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            element.SetValue(IsFocusedProperty, value);
        }

        private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = (FrameworkElement)d;

            if (e.OldValue == null)
            {
                fe.GotFocus += FrameworkElement_GotFocus;
                fe.LostFocus += FrameworkElement_LostFocus;
            }

            if (!fe.IsVisible)
            {
                fe.IsVisibleChanged += new DependencyPropertyChangedEventHandler(IsVisibleChanged);
            }

            if ((bool)e.NewValue)
            {
                fe.Focus();
            }
        }

        private static void IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var fe = (FrameworkElement)sender;
            if (fe.IsVisible && (bool)fe.GetValue(IsFocusedProperty))
            {
                fe.IsVisibleChanged -= IsVisibleChanged;
                fe.Focus();
            }
        }

        private static void FrameworkElement_GotFocus(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).SetValue(IsFocusedProperty, true);
        }

        private static void FrameworkElement_LostFocus(object sender, RoutedEventArgs e)
        {
            ((FrameworkElement)sender).SetValue(IsFocusedProperty, false);
        }
    }
}

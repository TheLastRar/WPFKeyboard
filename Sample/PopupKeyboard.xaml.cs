﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sample.KeyTemplates;
using WPFKeyboard;
using Point = System.Windows.Point;

namespace Sample
{
    /// <summary>
    /// Interaction logic for PopupKeyboard.xaml
    /// </summary>
    public partial class PopupKeyboard
    {
        public PopupKeyboard()
        {
            InitializeComponent();
            VirtualKeyboard.OnScreenKeyControlBuilder = new SampleKeyControlBuilder();
            VirtualKeyboard.DataContext = new KPDOnScreenKeyboardViewModel();
            var handle = ((NativeMethods.GetKeyboardLayout(0).ToInt32() >> 16) & 0xFFFF).ToString("x8");
            ((KPDOnScreenKeyboardViewModel)VirtualKeyboard.DataContext).Refresh(KeyboardHelper.InstalledKeyboardLayouts[handle], new ModiferStateManager());
        }
    }
}

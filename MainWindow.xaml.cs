﻿using System.Windows;

namespace TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DirectoryStructureViewModel();
        }
        #endregion
        
    }
}

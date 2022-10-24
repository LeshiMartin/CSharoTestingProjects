using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using XmlParsesLib.Models;

namespace XmlUi;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  private readonly MainWindowViewModel _vm;

  private IEnumerable<INode> _nodes { get; set; }
  public MainWindow ()
  {
    _vm = new MainWindowViewModel ();
    _nodes = _vm.Store.Children;
    InitializeComponent ();
  }

  protected override void OnContentRendered ( EventArgs e )
  {
    TreeViewItem store = BookStore;
    _vm.ConstructTreeView (store, _nodes);
    base.OnContentRendered (e);
  }
}

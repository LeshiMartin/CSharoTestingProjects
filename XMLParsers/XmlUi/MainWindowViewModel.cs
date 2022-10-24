using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using XmlParsesLib.Converters;
using XmlParsesLib.Models;

namespace XmlUi;
internal class MainWindowViewModel
{
  private readonly string xmlPath = @"D:\Projects\TestProjects\C#\XMLParsers\test.xml";

  public MainWindowViewModel ()
  {
    var converter = new BookStoreXmlConverter ();
    Store = converter.Convert (xmlPath);
  }
  public TreeNode Store { get; set; }

  public void ConstructTreeView(TreeViewItem treeViewItem, IEnumerable<INode> _nodes )
  {
    foreach ( var item in _nodes )
    {
      var newItem = new TreeViewItem ();
      treeViewItem.Items.Add (newItem);
      ConstructTreeView (newItem, item);
    }
  }

  private void ConstructTreeView(TreeViewItem treeViewItem, INode node )
  {
    treeViewItem.Header = node.NodeName;
    foreach ( var item in node.Children )
    {
      var newItem = new TreeViewItem ();
      treeViewItem.Items.Add (newItem);
      ConstructTreeView (newItem, item);
    }
  }
}

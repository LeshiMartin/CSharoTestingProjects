namespace XmlParsesLib.Models;
public abstract class TreeNode : INode
{
  public abstract string NodeName { get; }
  protected abstract IEnumerable<INode> _children ();
  public IEnumerable<INode> Children => _children ();
}

public interface INode
{
  string NodeName { get; }

  IEnumerable<INode> Children { get; }
}

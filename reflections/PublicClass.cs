using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflections {
  public class PublicClass {

    public PublicClass () { }

    public string PublicStr { get; set; } = "Hello";

    private string PrivateStr { get; set; } = "World";

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonBenchmarker.RootObjectDir;
public class FormVersion
{
    public int Id { get; set; }
    public string Version { get; set; }
    public string FormName { get; set; }
    public object JsonData { get; set; }
    public string Status { get; set; }
    public object RuleSetVersion { get; set; }
}

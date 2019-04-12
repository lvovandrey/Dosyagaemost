using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosyagWpf
{
    public class Model
    {
        public List<OU> OUs { get; set; }
        public OU SelectedOU { get; set; }
        public string Test { get; set; }
        public Model()
        {
            SelectedOU = new OU(0,"", "", 0, 0, 0);
            OUs = new List<OU>();
            Test = "Test 1";
        }
    }
}

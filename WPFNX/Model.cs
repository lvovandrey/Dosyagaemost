using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFNX
{
    public class Model
    {
        public ObservableCollection<OU> OUs { get; set; }
        public OU SelectedOU { get; set; }
        public string Test { get; set; }
        public Model()
        {
            SelectedOU = new OU(0,"", "", 0, 0, 0);
            OUs = new ObservableCollection<OU>();
            Test = "Test 1";
        }
    }
}

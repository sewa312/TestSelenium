using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// Encapsulates a web element id or class selector.
    /// </summary>
    class Item
    {
        public string ID;
        public string name;

        public Item(string ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        public void Enter()
        {
            Test.TestFunctions.FindItem(this).Click();
        }
    }
}

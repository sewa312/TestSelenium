using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
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

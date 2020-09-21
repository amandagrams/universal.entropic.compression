using System;
using System.Collections.Generic;
using System.Text;

namespace menu
{
    public class Option
    {
        public string Name { get; private set; }
        public Action Callback { get; private set; }

        public Option(string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

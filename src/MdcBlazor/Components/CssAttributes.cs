using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exentials.MdcBlazor
{
    public class CssAttributes
    {
        private readonly List<string> cssAttributes;

        public CssAttributes()
        {
            cssAttributes = new List<string>();
        }

        public void Add(string attribute)
        {
            cssAttributes.Add(attribute);
        }

        public void Add(params string[] attributes)
        {
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    this.cssAttributes.Add(attribute);
                }
            }
        }

        public override string ToString()
        {
            return string.Join(" ", cssAttributes);
        }
    }
}

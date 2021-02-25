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
        private readonly HashSet<string> cssAttributes;

        public CssAttributes()
        {
            cssAttributes = new HashSet<string>();
        }

        public void Add(string attribute)
        {
            if (!string.IsNullOrWhiteSpace(attribute))
            {
                var attributes = attribute.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Add(attributes);
            }
        }

        public void Add(params string[] attributes)
        {
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    _ = cssAttributes.Add(attribute);
                }
            }
        }

        public override string ToString()
        {
            return string.Join(" ", cssAttributes);
        }
    }
}

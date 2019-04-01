using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public delegate void MappingRules<D>(D To);
    public abstract class GenericMapper<D> where D : new()
    {
        private D toObj;

        public List<MappingRules<D>> MappingRule =
               new List<MappingRules<D>>();

        public void SetMapping(params MappingRules<D>[] mappingList)
        {
            MappingRule = mappingList.ToList();
        }

        public D GetMappedObject()
        {
            toObj = (D)Activator.CreateInstance(typeof(D));
            foreach (var action in MappingRule)
            {
                action.Invoke(toObj);
            }
            return toObj;
        }
    }
}

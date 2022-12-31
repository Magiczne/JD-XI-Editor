using JD_XI_Editor.Models.Patches.DrumKit.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace JD_XI_Editor.Serializing.Inspectors
{
    internal class DrumKitPartialInspector : TypeInspectorSkeleton
    {
        private readonly ITypeInspector _typeInspector;

        public DrumKitPartialInspector(ITypeInspector typeInspector)
        {
            _typeInspector = typeInspector;
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            var properties = _typeInspector.GetProperties(type, container);

            if (type.Name != typeof(Partial).Name)
            {
                return properties;
            }

            return properties.Where(property => property.Name != "Key");
        }
    }
}

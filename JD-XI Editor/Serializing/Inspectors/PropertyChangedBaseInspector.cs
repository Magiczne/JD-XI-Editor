﻿using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.TypeInspectors;

namespace JD_XI_Editor.Serializing.Inspectors
{
    internal class PropertyChangedBaseInspector : TypeInspectorSkeleton
    {
        private readonly ITypeInspector _typeInspector;

        public PropertyChangedBaseInspector(ITypeInspector typeInspector)
        {
            _typeInspector = typeInspector;
        }

        public override IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
        {
            var properties = _typeInspector.GetProperties(type, container);

            return properties.Where(property => property.Name != "IsNotifying");
        }
    }
}

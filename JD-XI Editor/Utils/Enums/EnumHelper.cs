using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace JD_XI_Editor.Utils.Enums
{
    public static class EnumHelper
    {
        /// <summary>
        ///     Get description for the enum field
        /// </summary>
        /// <param name="eValue"></param>
        /// <returns></returns>
        public static string Description(this Enum eValue)
        {
            var nAttributes = eValue.GetType().GetField(eValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (nAttributes.Any())
                return ((DescriptionAttribute) nAttributes.First()).Description;

            // If no description is found, the least we can do is replace underscores with spaces
            // You can add your own custom default formatting logic here
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(textInfo.ToLower(eValue.ToString().Replace("_", " ")));
        }

        /// <summary>
        ///     Get all values and descriptions of enum
        /// </summary>
        /// <param name="t">Type</param>
        /// <returns>Collection of pair of Value and Description</returns>
        public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException("type must be an enum type");

            return Enum.GetValues(type).Cast<Enum>()
                .Select(e => new ValueDescription
                {
                    Value = e,
                    Description = e.Description()
                }).ToList();
        }
    }
}
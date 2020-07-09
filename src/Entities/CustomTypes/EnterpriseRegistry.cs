using System;
using System.Text.RegularExpressions;

namespace Entities.CustomTypes
{
    public sealed class EnterpriseRegistry
    {
        
        private const string FORMAT = @"\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{1,2}";

        public string Value { get; private set; }

        private EnterpriseRegistry(string str)
        {
            if ( string.IsNullOrEmpty(str) )
                throw new ArgumentNullException( nameof(EnterpriseRegistry) );

            if ( !Regex.IsMatch(str, FORMAT) )
                throw new FormatException("EnterpriseRegistry format is 99.999.999/9999-99");

            Value = str;
        }

        public static implicit operator EnterpriseRegistry(string str)
        {
            return new EnterpriseRegistry(str);
        }

        public static implicit operator string(EnterpriseRegistry instance)
        {
            return instance.Value;
        }

    }
}

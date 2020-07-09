using System;
using System.Diagnostics.CodeAnalysis;

namespace Entities.CustomTypes
{
    public sealed class CompanyName
    {
        public string Value { get; private set; }

        private CompanyName(string str) 
        {

            if ( string.IsNullOrEmpty(str) ) 
                throw new ArgumentNullException( nameof (CompanyName) );

            Value = str;
        }


        public static implicit operator CompanyName(string str) 
        {
            return new CompanyName(str);
        }

        public static implicit operator string(CompanyName instance)
        {
            return instance.Value;
        }

    }
}

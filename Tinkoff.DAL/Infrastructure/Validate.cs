using System;

namespace Tinkoff.DAL.Infrastructure
{
    public class Validate
    {
        public static void NotNullOrEmpty(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("argument not be null or white space");
        }
    }
}
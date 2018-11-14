using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ootpisp.utils
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
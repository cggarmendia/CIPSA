using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_XI.Implementation.Application.MapFactory
{
    internal abstract class MappingBase
    {
        internal IEnumerable<TOutput> GetCollection<TInput, TOutput>(IEnumerable<TInput> source)
            where TInput : class
            where TOutput : class
        {
            return source.Select(item => Get<TInput, TOutput>(item));
        }

        internal abstract TOutput Get<TInput, TOutput>(TInput source)
            where TInput : class
            where TOutput : class;
    }
}

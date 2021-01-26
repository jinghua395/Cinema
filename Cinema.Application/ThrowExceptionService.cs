using System;
using System.Threading.Tasks;
using Cinema.Domain.Room;

namespace Cinema.Application
{
    public class ThrowExceptionService
    {
        public void ThrowIfNull(object obj, string prop, string key, string value)
        {
            if (obj == null)
            {
                throw new ArgumentException($"Not found {prop} with {key} is {value} ");
            }
        }
    }
}

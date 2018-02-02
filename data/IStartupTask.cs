using System;
using System.Threading.Tasks;

namespace data
{
    public interface IStartupTask
    {
        Task Run();
    }
}
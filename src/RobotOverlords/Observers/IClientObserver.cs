using System;
using System.Threading.Tasks;

namespace RobotOverlords.Observers
{
    public interface IClientObserver<T> : IDisposable
    {
        T Observable { get; }

        Task Subscribe(T observable);

        Task Unsubscribe();
    }
}
using System;
using System.Threading.Tasks;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IActions
    {
        Func<Task> Do_Nothing
            => Instances.ActionOperator.Do_Nothing;

        IActions<T> For<T>()
            => Actions<T>.Instance;

        IActions<T1, T2> For<T1, T2>()
            => Actions<T1, T2>.Instance;
    }


    [ValuesMarker]
    public partial interface IActions<T>
    {
        Action<T> Do_Nothing_Synchronous(T value)
            => Instances.ActionOperator.Do_Nothing_Synchronous;

        Func<T, Task> Do_Nothing()
            => Instances.ActionOperator.Do_Nothing;
    }

    [ValuesMarker]
    public partial interface IActions<T1, T2>
    {
        Func<T1, T2, Task> Do_Nothing()
            => Instances.ActionOperator.Do_Nothing;
    }
}

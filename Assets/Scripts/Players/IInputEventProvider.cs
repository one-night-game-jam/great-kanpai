using UniRx;

namespace Players
{
    interface IInputEventProvider
    {
        IReadOnlyReactiveProperty<bool> Jump { get; }
        IReadOnlyReactiveProperty<float> Move { get; }
    }
}

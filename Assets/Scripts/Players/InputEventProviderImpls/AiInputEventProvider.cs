using System;
using UniRx;

namespace Players.InputEventProviderImpls
{
    public class AiInputEventProvider : IInputEventProvider, IDisposable
    {
        readonly ReactiveProperty<bool> jump = new ReactiveProperty<bool>();
        readonly ReactiveProperty<float> move = new ReactiveProperty<float>();
        readonly CompositeDisposable disposable = new CompositeDisposable();

        IReadOnlyReactiveProperty<bool> IInputEventProvider.Jump => jump;
        IReadOnlyReactiveProperty<float> IInputEventProvider.Move => move;

        AiInputEventProvider()
        {
            
        }

        void IDisposable.Dispose()
        {
            disposable.Dispose();
        }
    }
}

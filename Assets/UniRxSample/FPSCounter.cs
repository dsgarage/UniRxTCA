using UnityEngine;
using System.Linq;
using UniRx;
using UniRx.Triggers;

public static class FPSCounter
{
    const int BufferSize = 5; //サンプル数を変えたい場合はここを変える
    public static IReadOnlyReactiveProperty<float> Current { get; private set; }

    static FPSCounter()
    {
        Current = Observable.EveryUpdate()
            .Select(_ => Time.deltaTime)
            .Buffer(BufferSize, 1)
            .Select(x => 1.0f / x.Average())
            .ToReadOnlyReactiveProperty();
    }
}
using System;
using System.Timers;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class UniRxOperatorRepeat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var zKeyInput = this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.Z));
        
        zKeyInput.Where(x => x)
            .Select(_ => Time.deltaTime)
            .Scan((p, c) => p + c)
            .TakeUntil(zKeyInput.Where(x => !x))
            .RepeatSafe()
            .Subscribe(x => Debug.Log(x + "秒間押されています(Safe)")).AddTo(this);

        zKeyInput.Where(x => x)
            .Select(_ => Time.deltaTime)
            .Scan((p, c) => p + c)
            .TakeUntil(zKeyInput.Where(x => !x))
            .RepeatUntilDestroy(this)
            .Subscribe(x => Debug.Log(x + "秒間押されています(UntilDestroy)"));
        
        //Zキーの状態変化
        var zKeyOnChanged = this.UpdateAsObservable()
            .Select(_ => Input.GetKey(KeyCode.Z))
            .DistinctUntilChanged()
            .Skip(1);
        
        //Zキーが1秒以上押されていたら通知
        var zKeyLongPressStart = zKeyOnChanged
            .Throttle(TimeSpan.FromSeconds(1))
                .Where(x => x);
        
        //Zキーが話された時通知
        var zKeyRelease = zKeyOnChanged.Where(x => !x);

        //1秒以上長押しされている間メソッドを呼び出す
        this.UpdateAsObservable()
            .SkipUntil(zKeyLongPressStart)
            .TakeUntil(zKeyRelease)
            .Repeat()
            .Subscribe(_ => { OnLongPress(); }).AddTo(this);


    }

    void OnLongPress()
    {
        Debug.Log("Z Key 1sec Press.");
    }


}

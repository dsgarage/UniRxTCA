using System;
using UniRx;
using UnityEngine;

public class UniRxOperatorDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Return(Unit.Default)
            .Delay(TimeSpan.FromSeconds(5))
            .Subscribe(x => Debug.Log("Subscribe Delay Second" + x));
        
        Observable.Return(Unit.Default)
            .DelayFrame(300)
            .Subscribe(x => Debug.Log("Subscribe Delay Frame." + x));
    }

}

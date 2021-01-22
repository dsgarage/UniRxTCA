using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class UniRxOperatorTake : MonoBehaviour
{
    [SerializeField]
    private Button destroy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        destroy.OnClickAsObservable().Subscribe(x => Destroy(gameObject));
        
        var array = new[] {1, 3, 4, 7, 2, 5, 9};

        //array.ToObservable().Take(1).Subscribe(
        //    x => Debug.Log(x),
        //    () => Debug.Log("ON Completed"));

        //array.ToObservable().TakeWhile(x => x < 5).Subscribe(
        //    x => Debug.Log(x),
        //    () => Debug.Log("ON Completed"));

        //Observable.Interval(TimeSpan.FromSeconds(1)).TakeUntil(this.OnDestroyAsObservable())
        //    .Subscribe(x => Debug.Log(x));

        //Observable.Interval(TimeSpan.FromSeconds(1)).TakeUntilDisable(this).Subscribe(x => Debug.Log(x),
        //() => Debug.Log("On Completed"));
        
        array.ToObservable().TakeLast(TimeSpan.FromSeconds(3)).Subscribe(
            x => Debug.Log(x),
            () => Debug.Log("ON Completed"));

    }

}

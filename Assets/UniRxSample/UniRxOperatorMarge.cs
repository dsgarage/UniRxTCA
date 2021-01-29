using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorMarge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var s1 = Observable.Range(10, 3, Scheduler.MainThread);
        //var s2 = Observable.Range(20, 3, Scheduler.MainThread);

        //s1.Merge(s2).Subscribe(x => Debug.Log($"{Time.frameCount} - {x}"));

        //IObservable<IObservable<int>> streams 
        //    = Observable.Range(1, 3, Scheduler.Immediate).Select(x =>
        //{
        //    return Observable.Range(x * 100, 3, Scheduler.Immediate);
        //});

        IEnumerable<IObservable<int>> streams = new[]
        {
            Observable.Range(100, 3),
            Observable.Range(200, 3),
            Observable.Range(300, 3)
        };

        streams.Merge().Subscribe(x => Debug.Log(x));
    }

}

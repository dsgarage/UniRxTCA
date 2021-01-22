using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UnitRxOperatorSkip : MonoBehaviour
{
    Subject<int> damage =new Subject<int>();
    // Start is called before the first frame update
    void Start()
    {
        damage.Skip(3).Subscribe(x => Debug.Log(x));

        var array = new[] {1, 3, 4, 7, 2, 5, 9};
        array.ToObservable().SkipWhile(x => x < 5).Subscribe(x => Debug.Log(x));

    }

    private void OnCollisionEnter(Collision other)
    {
        damage.OnNext(1);
    }
}

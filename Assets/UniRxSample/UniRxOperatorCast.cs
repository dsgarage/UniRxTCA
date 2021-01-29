using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var objects = new object[]
        {
            "hoge",
            "fuga",
            'a',
            -1,
            "fuga",
            'z',
            0.1
        };

        objects.ToObservable().Cast<object, string>().Subscribe(
            x => Debug.Log(x),
            ex => Debug.LogError(ex),
            () => Debug.Log("OnCompleted"));
    }  
    
}

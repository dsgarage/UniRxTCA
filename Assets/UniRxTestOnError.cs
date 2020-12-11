using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxTestOnError : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var stringSubject = new Subject<string>();
        
        stringSubject.Select(str => int.Parse((str))).OnErrorRetry((FormatException ex)=>
        {
            Debug.Log("例外が発生したので再購読します");
        })
            .Subscribe(x => Debug.Log("成功："　+ x),
            ex => Debug.Log("例外が発生：" + ex)
                );
            
        stringSubject.OnNext("1");
        stringSubject.OnNext("2");
        stringSubject.OnNext("Hello"); //こいつがエラー
        stringSubject.OnNext("4");
        stringSubject.OnCompleted();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

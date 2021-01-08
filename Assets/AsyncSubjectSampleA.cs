using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class AsyncSubjectSampleA : MonoBehaviour
{
    AsyncSubject<Unit> initializeAsyncSubject = new AsyncSubject<Unit>();

    public IObservable<Unit> OninitializedAsync
    {
        get { return initializeAsyncSubject; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("＝＝SampleAの初期化が実行されました＝＝");

        //初期化処理
        
        Debug.Log("＝＝SampleAの初期化が終わりました＝＝");

        initializeAsyncSubject.OnNext(Unit.Default);
        Debug.Log("＝＝＝＝通知しました＝＝＝＝");
        initializeAsyncSubject.OnCompleted();
        
    }
}

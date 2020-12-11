using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class GameInitializer : MonoBehaviour
{
    
    //Unit型を利用
    private Subject<Unit> initializedSubject = new Subject<Unit>();

    /// <summary>
    /// ゲームの初期化が完了したことを通知する
    /// </summary>
    public IObservable<Unit> OnInitializedAsync
    {
        get { return initializedSubject; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

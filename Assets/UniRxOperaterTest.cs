using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperaterTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ///3秒後に呼び出してくれる
        var timer = Observable.Timer( System.TimeSpan.FromSeconds( 3 ) );
        timer.Subscribe( _ => Debug.Log( "Hello! Timer." ) ); //3秒後にプリント
        
        ///マイフレーム呼び出してくれる
        var every = Observable.EveryUpdate();
        every.Subscribe( _ => Debug.Log( "Hello! EveryUpDate." ) );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

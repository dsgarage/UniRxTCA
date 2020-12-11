using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UniRxOperaterTest : MonoBehaviour
{
    [SerializeField] private Text everyUpdateText;
    [SerializeField] private int valu = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ///3秒後に呼び出してくれる
        var timer = Observable.Timer( System.TimeSpan.FromSeconds( 3 ) );
        timer.Subscribe( _ => Debug.Log( "Hello! Timer." ) ); //3秒後にプリント
        
        ///マイフレーム呼び出してくれる
        var every = Observable.EveryUpdate();
        every.Subscribe(_ =>
        {
            valu += 1;
            everyUpdateText.text = valu.ToString();
        });
        
        /// 1秒ごとに呼び出してくれる
        Observable.Timer(System.TimeSpan.FromSeconds(5), System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => Debug.Log("5秒後以降に1秒ごとに呼びだされています"))
            .AddTo(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

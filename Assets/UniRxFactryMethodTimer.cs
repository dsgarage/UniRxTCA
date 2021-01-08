using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UniRx;
using UnityEngine;

public class UniRxFactryMethodTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 5秒後に1度メッセージを発行して終わり
        Observable.Timer(System.TimeSpan.FromSeconds(5)).Subscribe(x => Debug.Log("5秒経過しました"));
        
        // 5秒後にメッセージを発行して
        // その後1秒毎に停止させない限りずっと動き続ける

        Observable.Timer(System.TimeSpan.FromSeconds(5), System.TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log("一定間隔で実行されてます"))
            .AddTo(gameObject);

    }

}

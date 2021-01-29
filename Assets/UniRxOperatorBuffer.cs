using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class UniRxOperatorBuffer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   //イベントのバッファサイズを指定
        Observable.Range(1, 6).Buffer(2)
            .Subscribe(x 
                => Debug.Log(x[0].ToString() + ":" + x[1].ToString())
            );

        //前のイベントをキャッシュしてバッファサイズを指定
        Observable.Range(1, 6).Buffer(2, 1)
            .Subscribe(x =>
            {
                if (x.Count > 1)
                {
                    Debug.Log(x[0] + ":" + x[1]);
                }
                else
                {
                    Debug.Log(x[0]);
                }
            });
        
        //マウスクリックイベントを期間を指定してバッファ
        var mouseDown = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0));

        mouseDown.Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(500)))
            .Where(x => x.Count == 2)
            .Subscribe(_ => Debug.Log("ダブルクリックされました"));
    }
}

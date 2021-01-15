using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class OperatorDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 偶数のみを許可して流す
        Observable.Range(0, 10).Where(x => x % 2 == 0).Subscribe(x => Debug.Log("Int : " + x));
        
        // string型にキャストできるもののみを通す
        object[] objects = {1, "hoge", 1.0f, 'Z', 0.1};
        objects.ToObservable().OfType<object, string>().Subscribe(x => Debug.Log(x));
        
        // OnNextを遮断するOperator
        Observable.Range(0, 10).IgnoreElements().Subscribe(x => Debug.Log(x), () => Debug.Log("OnCompleted"));
        
        // 過去に発行したことがあるメッセージは無視
        var array = new[] {1, 2, 2, 3, 1, 1, 2, 2, 3};
        array.ToObservable().Distinct().Subscribe(x => Debug.Log(x));
        
        // 過去に衝突したことのあるGameObjectを無視する
        // Collision型からGameLogicのパラメーターのみを取り出して比較
        this.OnCollisionEnterAsObservable().Distinct(go => go.gameObject).Subscribe(x => Debug.Log(x.gameObject.name));

        // 直前の値が同じだった場合遮断
        array.ToObservable().DistinctUntilChanged().Subscribe(x => Debug.Log(x));
    }
}

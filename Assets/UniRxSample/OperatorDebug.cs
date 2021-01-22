using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEditor.VersionControl;
using UnityEngine;

public class OperatorDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 偶数のみを許可して流す
        //Observable.Range(0, 10).Where(x => x % 2 == 0).Subscribe(x => Debug.Log("Int : " + x));
        
        // string型にキャストできるもののみを通す
        //object[] objects = {1, "hoge", 1.0f, 'Z', 0.1};
        //objects.ToObservable().OfType<object, string>().Subscribe(x => Debug.Log(x));
        
        // OnNextを遮断するOperator
        //Observable.Range(0, 10).IgnoreElements().Subscribe(x => Debug.Log(x), () => Debug.Log("OnCompleted"));
        
        // 過去に発行したことがあるメッセージは無視
        //var array = new[] {1, 2, 2, 3, 1, 1, 2, 2, 3};
        //array.ToObservable().Distinct().Subscribe(x => Debug.Log(x));
        
        // 過去に衝突したことのあるGameObjectを無視する
        // Collision型からGameLogicのパラメーターのみを取り出して比較
        //this.OnCollisionEnterAsObservable().Distinct(go => go.gameObject).Subscribe(x => Debug.Log(x.gameObject.name));

        // 直前の値が同じだった場合遮断
        //array.ToObservable().DistinctUntilChanged().Subscribe(x => Debug.Log(x));
        
        // 1から10個連続で数値を発行する
        // 3の約数がきたら通過させる
        //Observable.Range(1, 10).First(x => x % 3 == 0).Subscribe(
        //    x => Debug.Log(x), 
        //    () => Debug.Log("On Completed")
        //    );
        
        // 例外処理
        //Observable.Empty<int>().First().Subscribe(
        //    x => Debug.Log(x), 
        //    () => Debug.Log("On Completed")
        //    );
        
        // 例外を出さないで1度だけイベントを発行
        //Observable.Empty<int>().FirstOrDefault().Subscribe(
        //    x => Debug.Log(x),
        //    ex => Debug.Log(ex),
        //    () => Debug.Log("On Completed"));
        
        // 最後に流れてきたOnNextメッセージを取り出す
        // 取り出されるタイミングは、OnCompletedのタイミング
        //var array = new[] {1, 3, 4, 7, 8, 9};
        //array.ToObservable().Last().Subscribe(
        //    x => Debug.Log(x),
        //    ex => Debug.Log(ex),
        //    () => Debug.Log("On Completed"));
        
        // 同じ条件のものであっても1度しか発行されない
        // 2度目以降に発行されたものはエラーとなる(Exeption)
        //Observable.Range(1, 10).Single(x => x == 5).Subscribe(
        //    x => Debug.Log(x),
        //    ex => Debug.Log(ex),
        //    () => Debug.Log("On Completed"));
        
        //Observable.Range(1, 10).Single(x => x % 2 == 0).Subscribe(
        //    x => Debug.Log(x),
        //    ex => Debug.Log(ex),
        //    () => Debug.Log("On Completed"));
        
        // 指定した個数、または期間OnNextを無視する
        //Observable.Range(1, 10).Skip(3).Subscribe(X => Debug.Log(X));
        
        // 条件を満たしている場合は無視
        //Observable.Range(1, 10).SkipWhile(x => x < 5).Subscribe(x => Debug.Log(x));
        
        



    }
}
    
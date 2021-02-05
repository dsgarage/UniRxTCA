using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorZip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var stream1 = new[] {"A", "B", "C", "D"}.ToObservable();
        var stream2 = Observable.Range(0, 3).Select(x => x);

        stream1.Zip(stream2, (x1, x2) => $"{x1}:{x2}")
            .Subscribe(x => Debug.Log(x));


        var s1 = Observable.Return("A");
        var s2 = Observable.Return("B");
        var s3 = Observable.Return("C");
        var s4 = Observable.Return("D");
        var s5 = Observable.Return("E");
        var s6 = Observable.Return("F");
        var s7 = Observable.Return("G");
        var s8 = Observable.Return("H");
        var s9 = Observable.Return("I");
        var s10 = Observable.Return("J");

        s1.Zip(s2, s3,s4,s5,s6,s7,
                (x1, x2, x3,x4,x5,x6,x7) => x1 + x2 + x3)
            .Subscribe(x => Debug.Log(x));
        
        
        Observable.Zip(s1, s2, s3).Subscribe(x => Debug.Log(x.Count));
    }
}

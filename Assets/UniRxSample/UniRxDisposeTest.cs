using UniRx;
using UnityEngine;

public class UniRxDisposeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        var disposable1 = subject.Subscribe(x => Debug.Log("ストリーム1：" + x), () => Debug.Log("OnCompleted"));
        var disposable2 = subject.Subscribe(x => Debug.Log("ストリーム2：" + x), () => Debug.Log("OnCompleted"));

        subject.OnNext(1);
        subject.OnNext(2);
        
        disposable1.Dispose();
        
        subject.OnNext(3);
        subject.OnCompleted();
    }
    
}

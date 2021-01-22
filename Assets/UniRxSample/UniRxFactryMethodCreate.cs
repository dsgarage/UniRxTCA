using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxFactryMethodCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Create<int>(observer =>
        {
            Debug.Log("Start");

            for (var i = 0; i <= 100; i += 10)
            {
                observer.OnNext(i);
            }

            Debug.Log("Finished");

            observer.OnCompleted();

            return Disposable.Create(() => { Debug.Log("Despose"); });
        }).Subscribe(x => Debug.Log(x));
    }

}

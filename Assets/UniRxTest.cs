using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        subject.Subscribe(x => Debug.Log(x));
        
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnCompleted();
        
        var subjectnull = new Subject<Unit>();

        subjectnull.Subscribe(y => Debug.Log(y));
        
        subjectnull.OnNext(Unit.Default);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

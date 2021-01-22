using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxBehaviorSubjectTest : MonoBehaviour
{
    BehaviorSubject<int> subject = new BehaviorSubject<int>(5);

    private void Start()
    {
        subject.Subscribe(x => Debug.Log(x));
        StartCoroutine(SetOnNext());
    }

    IEnumerator SetOnNext()
    {
        subject.OnNext(1);
        
        yield return new WaitForSeconds(1);
        
        subject.OnNext(2);

        yield return new WaitForSeconds(1);
        
        subject.OnNext(3);
        
    }
}

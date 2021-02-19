using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UniRx;
using UnityEngine;

public class UniRxOperatorTimeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Time Count Start!!");
        Observable.Start(() => File.ReadAllText(@"date.txt"))
            .Timeout(TimeSpan.FromSeconds(1))
            .Subscribe(
                x => Debug.Log(x),
                ex => Debug.Log(ex)
                );
    }

}

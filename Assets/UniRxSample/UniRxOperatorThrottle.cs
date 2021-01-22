using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class UniRxOperatorThrottle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //transform.ObserveEveryValueChanged(p => p.position).Throttle(TimeSpan.FromSeconds(1)).Subscribe(x => Debug.Log(x));

        this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.Z)).ThrottleFirst(TimeSpan.FromSeconds(0.5f))
            .Subscribe(_ => Debug.Log("Pressed Z Key."));
    }
    
}

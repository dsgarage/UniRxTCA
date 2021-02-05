using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorStartWith : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(1, 3).StartWith(() => -1).Subscribe(x => Debug.Log(x));
        Observable.Range(1, 3).StartWith(() => Random.Range(-10, -1)).Subscribe(x => Debug.Log(x));
        Observable.Range(1, 3).StartWith(-3, -2, -1).Subscribe(x => Debug.Log(x));
    }

}

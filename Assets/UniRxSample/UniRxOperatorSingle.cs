using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorSingle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Observable.Range(1, 10).Single(x => x == 5).Subscribe(
        //    x => Debug.Log(x),
        //    ex => Debug.Log(ex),
        //    () => Debug.Log("ON Completed"));
        
        Observable.Range(1,10).Single(x => x%2 == 0).Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log(ex),
            () => Debug.Log("ON Completed"));
    }

}

using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorLast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9,};

        array.ToObservable().Last().Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log(ex),
            () => Debug.Log("ON Completed"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class FPSDebug : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        FPSCounter.Current.Subscribe( fps =>
        {
            Debug.Log(fps);
        });
    }
}

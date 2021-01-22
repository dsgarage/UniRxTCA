using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UniRxEventInputField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var inputfield = GetComponent<InputField>();
        inputfield.OnValueChangedAsObservable().Subscribe(i => Debug.Log(i));
    }
    
}

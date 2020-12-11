using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertyTest : MonoBehaviour
{
    [SerializeField] private IntReactiveProperty _intReactiveProperty 
        = new IntReactiveProperty(100);

    [SerializeField] private StringReactiveProperty _stringReactiveProperty = new StringReactiveProperty("Test");
    [SerializeField] private BoolReactiveProperty _boolReactiveProperty = new BoolReactiveProperty(true);
    
    // Start is called before the first frame update
    void Start()
    {
        var rp = new ReactiveProperty<int>(10);

        //値の代入と取り出し
        rp.Value = 20;
        var currentValu = rp.Value;

        rp.Subscribe(x => Debug.Log(x));

        rp.Dispose();
        rp.Value = 30;

        _intReactiveProperty.Subscribe(x => Debug.Log("IRP:" + x));
        _intReactiveProperty.Value = 1000;
        _intReactiveProperty.Value = 2000;

        _stringReactiveProperty.Subscribe(s => Debug.Log("String:" + s));
        _boolReactiveProperty.Subscribe(b =>
        {
            if (b)
            {
                Debug.Log("Message True.");
            }
            else
            {
                Debug.Log("Message False.");
            }
        });

    }

}

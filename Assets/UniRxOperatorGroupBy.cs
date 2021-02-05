using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UniRxOperatorGroupBy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(1, 10)
            .GroupBy(x => x % 2)
            .Subscribe(groupedObserbable =>
            {
                if (groupedObserbable.Key == 0)
                {
                    groupedObserbable.Buffer(5).Subscribe(x =>
                    {
                        var even = "";
                        foreach (var VARIABLE in x)
                        {
                            even = even + "&" + VARIABLE;
                        }
                        Debug.Log("Even:" + even);
                    });
                }
                else
                {
                    groupedObserbable.Buffer(5).Subscribe(x =>
                    {
                        var odd = "";
                        foreach (var VARIABLE in x)
                        {
                            odd = odd + "&" + VARIABLE;
                        }
                        Debug.Log("Odd:" + odd);
                    });
                }
            });
    }

}

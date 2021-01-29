using UniRx;
using UnityEngine;

public class UniRxOperatorAggregate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(0, 10)
            .Aggregate(0, (pre, cur) => pre + cur)
            .Subscribe(x => Debug.Log(x));

        Observable.Range(0, 10)
            .Scan(0, (pre, cur) => pre + cur)
            .Subscribe(x => Debug.Log(x));
    }
}

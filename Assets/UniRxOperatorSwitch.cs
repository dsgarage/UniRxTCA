using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class UniRxOperatorSwitch : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    // Start is called before the first frame update
    void Start()
    {
        IObservable<IObservable<Vector3>> targetObservable
            = this.OnCollisionEnterAsObservable().Select(x =>
            {
                var target = x.gameObject;
                return CreatePositionObservable(target);
            });
        
        targetObservable.Switch().Subscribe(target =>
        {
            // ターゲットのCubeの座標をゆっくり追いかける
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        });
    }

    IObservable<Vector3> CreatePositionObservable(GameObject target)
    {
        return target.UpdateAsObservable().Select(_ => target.transform.position);
    }

}

using UniRx;
using UniRx.Triggers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UniRxOperatorWithLatestFrom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rigidbody = GetComponent<Rigidbody>();
        var inputStream = this.UpdateAsObservable().Select(_ =>
        {
            Debug.Log("Call InputStream.");
            return new Vector3(
                x: Input.GetAxis("Horizontal"),
                y: 0,
                z: Input.GetAxis("Vertical"));
        });

        this.FixedUpdateAsObservable()
            .WithLatestFrom(inputStream, (_, input) => input)
            .Subscribe(input =>
        {
            Debug.Log("Call FixdUpdate.");
            rigidbody.AddForce(input, ForceMode.Acceleration);
        });
    }

}

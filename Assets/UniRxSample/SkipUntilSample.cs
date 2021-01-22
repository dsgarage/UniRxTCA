using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class SkipUntilSample : MonoBehaviour
{
    private Renderer targetRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRenderer = GetComponent<MeshRenderer>();
        
        var onBecomeVisible = targetRenderer.OnBecameVisibleAsObservable();

        onBecomeVisible.Subscribe(x => Debug.Log("Camera ON!!!!"));

        //this.UpdateAsObservable().SkipUntil(onBecomeVisible).Subscribe(x =>
        //{
        //    transform.position += Vector3.up * Time.deltaTime;
        //}
        //    );
    }

}

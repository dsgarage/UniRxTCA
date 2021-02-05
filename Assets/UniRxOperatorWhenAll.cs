using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class UniRxOperatorWhenAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var parallel = Observable.WhenAll(
            FetchAsync("https://unity.com/ja").ToObservable(),
            FetchAsync("https://www.google.co.jp").ToObservable(),
            FetchAsync("https://github.com").ToObservable());
        parallel.Subscribe(xs =>
        {
            Debug.Log(xs[0]);//Unity
            Debug.Log(xs[1]);//Google
            Debug.Log(xs[2]);//GitHub
        });
    }


    async UniTask<string> FetchAsync(string uri)
    {
        using (var uwr = UnityWebRequest.Get(uri))
        {
            await uwr.SendWebRequest();
            return uwr.downloadHandler.text;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class UniRxOperatorRetry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var url = "https://unity3d.com/jp";

        //回数と時間の間隔を開けてリトライ
        Observable.Defer(() => FetchAsync(url).ToObservable())
            .OnErrorRetry(
                onError: (Exception ex) => Debug.LogWarning(ex.Message),
                delay: TimeSpan.FromSeconds(3),
                retryCount: 3)
            
            .Subscribe(
                x => Debug.Log(x),
                ex => Debug.Log(ex),
                () => Debug.Log("On Completed."));
        
        //エラーハンドリングとリトライ回数を指定してリトライ
        Observable.Defer(() => FetchAsync(url).ToObservable())
            .OnErrorRetry(
                onError: (Exception ex) => Debug.LogWarning(ex.Message),
                retryCount: 3)
            .Subscribe(
                x => Debug.Log(x),
                ex => Debug.Log(ex),
                () => Debug.Log("On Completed."));

        //ただのリトライ
        Observable.Defer(() => FetchAsync(url).ToObservable()).Retry(3).Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log(ex),
            () => Debug.Log("OnCompleted"));
    }

    private async UniTask<string> FetchAsync(string url)
    {
        using (var uwr = UnityWebRequest.Get(url))
        {
            await uwr.SendWebRequest();
            return uwr.downloadHandler.text;
        }
    }
}

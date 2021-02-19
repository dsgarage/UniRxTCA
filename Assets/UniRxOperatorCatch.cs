using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

public class UniRxOperatorCatch : MonoBehaviour
{
    [SerializeField] private string[] _serverURLs;

    // Start is called before the first frame update
    void Start()
    {
        var array = new[] {"1", "2", "three", "4"};

//数字の文字列が想定されている配列をintに変換する

        array.ToObservable()
            .Select(int.Parse)
            .CatchIgnore((ArgumentNullException ex) =>
            {
                Debug.LogWarning("Nullが指定されました");
            })
            .CatchIgnore((FormatException ex) =>
            {
                Debug.LogWarning("数値ではない文字列が指定されました");
            })
            .Subscribe(x => Debug.Log(x), ex => Debug.LogError(ex), () => Debug.Log("OnCompleted"));

        array.ToObservable().Select(int.Parse).CatchIgnore().Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log(ex),
            () => Debug.Log("OnCOmpleted."));



        //複数のURLを先頭から読み込み正常に読み込めた時点で終了
        //FetchTextDateAsync(_serverURLs).Subscribe(x => Debug.Log(x));
    }

    private IObservable<string> FetchTextDateAsync(string[] urls)
    {
        IObservable<string>[] observables = urls.Select(x 
            => Observable.Defer(() => FetchAsObservavle(x))).ToArray();
    
        return observables.Catch();

    }

    private IObservable<string> FetchAsObservavle(string url)
    {
        return FetchAsync(url).ToObservable();
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

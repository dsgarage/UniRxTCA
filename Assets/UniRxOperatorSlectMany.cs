using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class UniRxOperatorSlectMany : MonoBehaviour
{
    [SerializeField] private Button _downloadButton;
    [SerializeField] private InputField _urlInputField;


    private string[] urls = new[]
    {
        "https://unity3d.com/jp/",
        "https://www.google.co.jp",
        "https://www.bing.com"
    };
    
    // Start is called before the first frame update
    void Start()
    {
        _downloadButton.OnClickAsObservable().Select(_ => _urlInputField.text)
            .SelectMany(url => FetchAsync(url).ToObservable()).Subscribe(x => Debug.Log(x));


        urls.ToObservable().SelectMany(uri => TryGetAsync(uri).ToObservable(), (uri, body) => (uri, body)).
            Subscribe(x =>
            {
                var (uri, body) = x;
                Debug.Log($"{uri}への通信結果:{body}");
            });


    }
    
    private async UniTask<string> FetchAsync(string url)
    {
        using (var uwr = UnityWebRequest.Get(url))
        {
            await uwr.SendWebRequest();
            return uwr.downloadHandler.text;
        }
    }

    private async UniTask<bool> TryGetAsync(string url)
    {
        using (var uwr = UnityWebRequest.Get(url))
        {
            try
            {
                await uwr.SendWebRequest();
                return true;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return false;
            }
        }
    }
}

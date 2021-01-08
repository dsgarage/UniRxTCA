using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UniRx;
using UnityEngine;

public class UniRxFactryMethodStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Start(() =>
            {
                //GoogleのTOPページをHTTPでGETする
                var req = (HttpWebRequest) WebRequest.Create("http://google.com");
                var res = (HttpWebResponse) req.GetResponse();
                using (var reader = new StreamReader(res.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            })
            .ObserveOnMainThread()
            .Subscribe(x => Debug.Log(x));
    }

}

using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ThrottleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // UpdateのタイミングでAttackボタンが押されてるか判定
        // Attackボタンが押されたらSubscribeの処理を実行
        // そのあと３０フレームの間、ボタン入力を無視する
        //this.UpdateAsObservable().Where(input => Input.GetButtonDown("Fire1")).ThrottleFirstFrame(60).Subscribe(x => Debug.Log("Push Attack Button!!!"));
        

    }
}

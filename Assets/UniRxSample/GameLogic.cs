using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Text lifeText;

    [SerializeField] private int life = 10;
    [SerializeField] private int damage = 1;
    [SerializeField] private float span = 3f;
    [SerializeField] private bool countdown = true;

    public void Init()
    {
        life = 100;
    }
    
    IEnumerator Start () {
        Init();
        while (countdown) {
            yield return new WaitForSeconds (span);
            life -= damage;
            Debug.LogFormat ("{0}秒経過 Lifeは{1}です", span , life);
            lifeText.text = "Lifeは" + life.ToString() + "です。";
            
            LifeChack(life);
        }
    }

    void LifeChack(int lifevalu)
    {
        if (lifevalu == 0)
        {
            Debug.Log("Finish!!!!!!!");
            countdown = false;
        }
        else
        {
            return;
        }
    }

    public void AddLife(int addLife)
    {
        life += addLife;
    }
    
    
}

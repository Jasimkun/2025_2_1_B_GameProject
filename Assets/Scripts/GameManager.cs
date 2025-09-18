using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("게임 상태")]
    public int playScore = 0;
    public int itemsCollected = 0;

    [Header("UI 참조")]
    public Text scoreText;
    public Text itemcountText;
    public Text gameStatusText;

    public static GameManager instance;      //싱글턴 패턴

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        itemsCollected++;
        Debug.Log($"아이템 수집! (총 : {itemsCollected} 개");
    }

    public void UpdateUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "접수 : " + playScore;
        }    

        if(itemcountText != null)
        {
            itemcountText.text = "아이템 : " + itemsCollected + "개";
        }
    }

}

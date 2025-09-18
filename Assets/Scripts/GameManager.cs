using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� ����")]
    public int playScore = 0;
    public int itemsCollected = 0;

    [Header("UI ����")]
    public Text scoreText;
    public Text itemcountText;
    public Text gameStatusText;

    public static GameManager instance;      //�̱��� ����

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
        Debug.Log($"������ ����! (�� : {itemsCollected} ��");
    }

    public void UpdateUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "���� : " + playScore;
        }    

        if(itemcountText != null)
        {
            itemcountText.text = "������ : " + itemsCollected + "��";
        }
    }

}

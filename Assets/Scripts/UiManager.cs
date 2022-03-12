using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public Text chupa;
    public Text treas;
    public Text score;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void GameStart()
    {
        chupa.GetComponent<Animator>().Play("chupaUp");
        treas.GetComponent<Animator>().Play("treasDown");
        score.GetComponent<Animator>().Play("scoreEntry");
    }

    public void GameStop()
    {
        gameOver.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

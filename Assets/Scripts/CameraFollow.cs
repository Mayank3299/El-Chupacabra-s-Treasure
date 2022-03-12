using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public bool gameOver= false;

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            UiManager.instance.GameStart();
            transform.position = player.transform.position - offset;
        }
        else
        {   
            enemy.GetComponent<EnemyController>().gameOver = true;
            UiManager.instance.GameStop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPath : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y + 1f, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void ShootBullet()
    {
        if(!gameOver)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            gameOver = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }
    }
}

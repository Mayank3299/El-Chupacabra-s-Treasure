using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    private float dirX;
    public float moveSpeed;

    public GameObject bullet;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public bool gameOver = false;
    public AudioClip fireSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        dirX = -1f;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            anim.SetInteger("TurningState", (int)dirX);
            dirX *= -1f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX * moveSpeed, rb.velocity.y, rb.velocity.z);

        if (!gameOver)
        {
            if (timeBtwShots <= 0)
            {
                Vector3 dest = new Vector3(transform.position.x, transform.position.y + 1.7f, transform.position.z);
                Instantiate(bullet, dest, bullet.transform.rotation);
                AudioSource.PlayClipAtPoint(fireSound, transform.position);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}

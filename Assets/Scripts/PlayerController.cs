using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    Animator anim;

    [SerializeField]
    float speed;
    public float rotationSpeed;

    private float dirX, dirZ;
    int counter = 0;

    public GameOver GameOver;
    public AudioClip coinSound;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameWon())
        {
            dirX = Input.GetAxis("Horizontal");
            dirZ = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(dirX, 0, dirZ);

            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

            if (movementDirection != Vector3.zero)
            {
                anim.SetInteger("RunningState", 1);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                anim.SetInteger("RunningState", -1);
            }
        }
        else
        {
            anim.Play("Excited");
        }
        GameOver.Setup(counter * 10);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Coin")
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            counter += 1;
            ScoreManager.instance.AddPoint();
            Destroy(col.gameObject);
        }
    }

    bool GameWon()
    {
        if (counter == 10)
        {
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            return true;
        }
        else
            return false;
    }
}
  
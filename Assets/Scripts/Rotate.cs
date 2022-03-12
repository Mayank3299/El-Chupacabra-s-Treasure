using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotationSpeed = 3f;
    Vector3 rot = new Vector3(90.0f, 0.0f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Rotate(rot * rotationSpeed * Time.deltaTime);
    }
}

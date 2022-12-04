using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 30f;

    public GroundSpawner1 groundSpawner1;
    public GroundSpawner groundSpawner;

    bool shouldStop = false;
    public float stopTime = 2.3f;
    float currentTime = 0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundSpawner1)
        {
            if (groundSpawner1.isEnd && currentTime <= stopTime)
            {
                currentTime += Time.deltaTime;
            }
            else if (currentTime > stopTime)
            {
                shouldStop = true;
            }
        }
        else if (groundSpawner)
        {
            if (groundSpawner1.isEnd && currentTime <= stopTime)
            {
                currentTime += Time.deltaTime;
            }
            else if (currentTime > stopTime)
            {
                shouldStop = true;
            }
        }


      

        if (!shouldStop)
        {
            //Debug.Log("move");
            //rb.AddForce(Vector3.forward * Time.deltaTime * speed);
            //rb.velocity = Vector3.forward * Time.deltaTime * speed;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
            
    }
}

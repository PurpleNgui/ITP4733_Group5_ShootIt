using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEndTile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}

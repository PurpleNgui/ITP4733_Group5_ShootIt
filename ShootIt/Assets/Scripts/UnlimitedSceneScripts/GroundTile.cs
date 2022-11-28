using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    GroundSpawner1 groundSpawner1;

    [SerializeField] private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindObjectOfType<GroundSpawner>())
            groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        else
            groundSpawner1 = GameObject.FindObjectOfType<GroundSpawner1>();


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(groundSpawner)
            groundSpawner.SpawnTile();
        else
            groundSpawner1.SpawnTile();
        Destroy(gameObject, 2f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    GroundSpawner1 groundSpawner1;

    Move player;

    [SerializeField] private float speed = 20f;

    //bool isSpawn = false;

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
        player = other.GetComponent<Move>();

        if (groundSpawner)
        {

            //groundSpawner.SpawnTile();
            if (!groundSpawner.isEnd)
            {
                //Debug.Log("spawn(!groundSpawner1.isEnd)");
                //Debug.Log("isSpawn: " + isSpawn);
                groundSpawner.SpawnTile();

            }
            else if (groundSpawner.isEnd && !groundSpawner.isSpawn)
            {
                //Debug.Log("spawn(groundSpawner1.isEnd)");
                //Debug.Log("isSpawn: " + isSpawn);
                //isSpawn = true;
                groundSpawner.SpawnTile();
                player.shouldStop = true;

                //return;
            }
        }
        else
        {
            //Debug.Log("this.gameObject.name: " + this.gameObject.name);
            //Debug.Log("this.gameObject.name != CaveEndRoad: " + this.gameObject.name != "CaveEndRoad");
            if (!groundSpawner1.isEnd )
            {
                //Debug.Log("spawn(!groundSpawner1.isEnd)");
                //Debug.Log("isSpawn: " + isSpawn);
                groundSpawner1.SpawnTile();

            }
            else if(groundSpawner1.isEnd && !groundSpawner1.isSpawn)
            {
                //Debug.Log("spawn(groundSpawner1.isEnd)");
                //Debug.Log("isSpawn: " + isSpawn);
                //isSpawn = true;
                groundSpawner1.SpawnTile();
                player.shouldStop = true;

                //return;
            }

        }
           
        Destroy(gameObject, 2f);
    }

}

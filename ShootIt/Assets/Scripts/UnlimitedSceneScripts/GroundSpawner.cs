using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject building1;
    public GameObject building2;
    public GameObject building3;

    public GameObject groundTile;

    GameObject temp;
    Vector3 nextSpawnPoint;

    List<Vector3> points = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            SpawnTile();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile()
    {
        

        /*GameObject*/ temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        

        for(int i =0; i < 2; i++)
        {
            GameObject tempBuilding = Instantiate(RandomObject(), RandomPosition(), Quaternion.identity, temp.transform.GetChild(1));
        }

        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    GameObject RandomObject()
    {
        int randomNum = Random.Range(0, 3);

        switch (randomNum)
        {
            default:
            case 0:
                return building1;
            case 1:
                return building2;
            case 2:
                return building3;
        }
    }

    Vector3 RandomPosition()
    {
        float randomX = Random.Range(1.5f, 6.0f);
        if(Random.Range(1, 51)%2 == 1)                      //50% randomX -> -randomX
        {
            randomX = -randomX;
        }

        float randomZ = Random.Range(5.0f, 6.0f);        //-5.0 - 6
        //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));

        return new Vector3(randomX + temp.transform.position.x, 1f + temp.transform.position.y, randomZ + temp.transform.position.z);
        //Physics.CheckSphere(transform.position, sphereRadius)
    }
}

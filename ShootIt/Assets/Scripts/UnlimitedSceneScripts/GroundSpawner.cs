using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    //public GameObject building1;
    //public GameObject building2;
    //public GameObject building3;
    public int buildingNumber;
    public List<GameObject> building;

    public GameObject groundTile;

    GameObject temp;
    Vector3 nextSpawnPoint;

    Quaternion buildingFacing;
    Quaternion leftQuaternion = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
    Quaternion RightQuaternion = new Quaternion(-0.5f, -0.5f, -0.5f, 0.5f);

    List<Vector3> points = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnTile();
        }


        //building = new List<GameObject>(buildingNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTile()
    {


        /*GameObject*/
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);


        for (int i = 0; i < 2; i++)
        {
            GameObject tempBuilding = Instantiate(RandomObject(), RandomPosition(), buildingFacing, temp.transform.GetChild(1));
            buildingFacing = RightQuaternion;
        }
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    GameObject RandomObject()
    {
        int randomNum = Random.Range(0, building.Count);

        return building[randomNum];
    }

    Vector3 RandomPosition()
    {
        buildingFacing = RightQuaternion;
        float randomX = Random.Range(6.0f, 6.9f);
        if (Random.Range(1, 51) % 2 == 1)                      //50% randomX -> -randomX
        {
            randomX = -randomX;
            BuildingFacing();
        }

        float randomZ = Random.Range(2.9f, 12.9f);
        //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));

        

        return new Vector3(randomX + temp.transform.position.x, temp.transform.position.y, randomZ + temp.transform.position.z);
        //Physics.CheckSphere(transform.position, sphereRadius)
    }

    Quaternion BuildingFacing()
    {
        Debug.Log("BuildingFacing");
        return buildingFacing = leftQuaternion;
    }
}

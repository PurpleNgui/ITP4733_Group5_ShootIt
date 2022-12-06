using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTraget : MonoBehaviour
{
    public int numberOfbuilding = 2;

    [SerializeField] private float startRandomZ = 2f;
    [SerializeField] private float endRandomZ = 19f;

    public float startRandomY = -3f;
    public float endRandomY = 1f;

    public float startRandomX = 8f;
    public float endRandomX = 18f;

    int buildingNum = 0;

    public GameObject traget;

    GroundSpawner groundSpawner;
    GroundSpawner1 groundSpawner1;

    GameObject pos;

    [SerializeField] private float spawnCollisionCheckRadius = 3.5f;

    //GameObject RandomObject()
    //{
    //    buildingNum = Random.Range(0, building.Count);
    //    //Debug.Log("buildingNum: " + buildingNum);

    //    return building[buildingNum];
    //}

    private void Start()
    {
        if (GameObject.FindObjectOfType<GroundSpawner>())
            groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        else
            groundSpawner1 = GameObject.FindObjectOfType<GroundSpawner1>();
    }

    public void SpawnerTarget()
    {
        for (int i = 0; i < numberOfbuilding; i++)
        {
            Instantiate(traget, /*nextSpawnPoint*/RandomPosition(), Quaternion.identity);
        }
    }

    Vector3 RandomPosition()
    {
        //buildingFacing = RightQuaternion;
        float randomX = Random.Range(startRandomX, endRandomX);
        if (Random.Range(1, 51) % 2 == 1)
        {
            randomX = -randomX;
            //BuildingFacing();
        }



        float randomZ = Random.Range(startRandomZ, endRandomZ);               //(2.9f, 12.9f)
        //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));
        float randomY = Random.Range(startRandomY, endRandomY);          //cave:-3to1

        if (groundSpawner)
            pos = groundSpawner.temp;
        else
            pos = groundSpawner1.temp;

        return new Vector3(randomX + pos.transform.position.x, randomY, randomZ + pos.transform.position.z);
        //Physics.CheckSphere(transform.position, sphereRadius)
    }

}

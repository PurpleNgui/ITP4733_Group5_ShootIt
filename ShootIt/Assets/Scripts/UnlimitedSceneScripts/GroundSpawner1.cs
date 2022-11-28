using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSpawner1 : MonoBehaviour
{

    public List<GameObject> building;
    public int numberOfbuilding = 2;
    public int startBuildingSpawn = 1;
    //public GameObject firstBuilding;
    GameObject buildingBoundary1;
    GameObject buildingBoundary2;

    public GameObject groundTile;

    GameObject temp;
    Vector3 nextSpawnPoint;

    //Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    int buildingNum = 0;
    Quaternion buildingFacing;
    Quaternion leftQuaternion = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
    Quaternion RightQuaternion = new Quaternion(-0.5f, -0.5f, -0.5f, 0.5f);

    [SerializeField]private float spawnCollisionCheckRadius = 3.5f;
    //List<Vector3> points = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //nextSpawnPoint = firstBuilding.transform.GetChild(0).transform.position;
        for (int i = 0; i < startBuildingSpawn; i++)
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
        //if (SceneManager.GetActiveScene().name == "CaveScene")
        {
            Vector3 grounSpawnHigh = nextSpawnPoint;
            grounSpawnHigh.y = -5f;
            temp = Instantiate(groundTile, /*nextSpawnPoint*/grounSpawnHigh, Quaternion.identity);
        }
        //else
        //    temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);

        if(building.Count > 0)
        {
            for (int i = 0; i < numberOfbuilding; i++)                    
            {
                //buildingFacing = leftQuaternion;
                GameObject rendomObject = RandomObject();
                Vector3 rendomPos = RandomPosition(i, rendomObject);
                Quaternion rendomRotation = Quaternion.identity;
                rendomRotation.y = Random.rotation.y;


                if (!Physics.CheckSphere(rendomPos, spawnCollisionCheckRadius))
                {
                    //Debug.Log("spwan left");
                    GameObject tempBuilding = Instantiate(rendomObject, rendomPos, /*Quaternion.identity*/rendomRotation/*, temp.transform.GetChild(1)*/);

                }
            }
        
         

        }

     

    
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    GameObject RandomObject()
    {
        buildingNum = Random.Range(0, building.Count);
        //Debug.Log("buildingNum: " + buildingNum);

        return building[buildingNum];
    }

    Vector3 RandomPosition(int buildingNum, GameObject building)
    {
        //buildingFacing = RightQuaternion;
        float randomX = Random.Range(8f, 18f);
        if (Random.Range(1, 51) % 2 == 1)                      //50% randomX -> -randomX
        {
            randomX = -randomX;
            //BuildingFacing();
        }



        float randomZ = Random.Range(2.0f, 19f);               //(2.9f, 12.9f)
        //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));
        float randomY = Random.Range(-3f, 1f);



        return new Vector3(randomX + temp.transform.position.x, randomY, randomZ + temp.transform.position.z);
        //Physics.CheckSphere(transform.position, sphereRadius)
    }

    

}

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
    //GameObject buildingBoundary1;
    //GameObject buildingBoundary2;

    public GameObject groundTile;
    public GameObject groundEndTile;
    public GameObject traget;
    public UIManager uIManager;

    [SerializeField] private float startRandomZ = 2f;
    [SerializeField] private float endRandomZ = 19f;

    public float startRandomY = -3f;
    public float endRandomY = 1f;
    
    public float startRandomX = 8f;
    public float endRandomX = 18f;

    public GameObject temp;
    Vector3 nextSpawnPoint;

    

    //Vector3 scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    int buildingNum = 0;
    //Quaternion buildingFacing;
    //Quaternion leftQuaternion = new Quaternion(-0.5f, 0.5f, 0.5f, 0.5f);
    //Quaternion RightQuaternion = new Quaternion(-0.5f, -0.5f, -0.5f, 0.5f);

    [SerializeField] private float spawnCollisionCheckRadius = 3.5f;
    //List<Vector3> points = new List<Vector3>();

    float totalTime = 30f;
    float second = 0;
    float minute = 0;
    /*[HideInInspector]*/ public bool isEnd = false;
    [HideInInspector] public bool isSpawn = false;

    public bool isDsertScene = false;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
        isSpawn = false;
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

        if (totalTime >= 0f)
        {
            totalTime -= Time.deltaTime;

           
                minute = (int)totalTime / 60;
                second = totalTime %60;
          
          
        }
        else if(totalTime < 0f && isEnd == false)
        {
            isEnd = true;
            //if (isEnd)
                //uIManager.CallResult();
        }

        

    }

    public void SpawnTile()
    {
        //if (SceneManager.GetActiveScene().name == "CaveScene")
        {
            Vector3 grounSpawnHigh = nextSpawnPoint;
            grounSpawnHigh.y = -5f;
            if (!isEnd)
            {
                temp = Instantiate(groundTile, /*nextSpawnPoint*/grounSpawnHigh, Quaternion.identity);
            }
            else if(isEnd  && !isSpawn )
            {
                if(groundEndTile)
                    temp = Instantiate(groundEndTile, /*nextSpawnPoint*/grounSpawnHigh, Quaternion.identity);
                else
                    temp = Instantiate(groundTile, /*nextSpawnPoint*/grounSpawnHigh, Quaternion.identity);
                temp.SetActive(true);
                isSpawn = true;
                if(!groundEndTile)
                    uIManager.CallResult();
            }
            
        }
        //else
        //    temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        
        if(building.Count > 0 && !isEnd)
        {
            for (int i = 0; i < numberOfbuilding; i++)                    
            {
                //buildingFacing = leftQuaternion;
                GameObject rendomObject = RandomObject();
                Vector3 rendomPos = RandomPosition(i, rendomObject);
                Quaternion rendomRotation = Quaternion.identity;
                rendomRotation.y = Random.rotation.y;

                if (isDsertScene)
                {
                    rendomRotation = Random.rotation;
                }


                if (!Physics.CheckSphere(rendomPos, spawnCollisionCheckRadius))
                {
                    //Debug.Log("spwan left");
                    GameObject tempBuilding = Instantiate(rendomObject, rendomPos, /*Quaternion.identity*/rendomRotation/*, temp.transform.GetChild(1)*/);

                    if(Random.Range(1, 50)%3 < 2 && traget)
                    {
                        //rendomPos
                        Instantiate(traget, rendomPos, Quaternion.identity);
                        //randomTraget.SpawnerTarget();
                    }
                   

                }
            }
        
         

        }

     

    
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    public float GetCurrentTime()
    {
        return totalTime;
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
        float randomX = Random.Range(startRandomX, endRandomX);              //cave:8 to 18
        if (Random.Range(1, 51) % 2 == 1)                      //50% randomX -> -randomX
        {
            randomX = -randomX;
            //BuildingFacing();
        }



        float randomZ = Random.Range(startRandomZ, endRandomZ);               //(2.9f, 12.9f)
        //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));
        float randomY = Random.Range(startRandomY, endRandomY);          //cave:-3to1



        return new Vector3(randomX + temp.transform.position.x, randomY, randomZ + temp.transform.position.z);
        //Physics.CheckSphere(transform.position, sphereRadius)
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    //public GameObject building1;
    //public GameObject building2;
    //public GameObject building3;
    //public int buildingNumber;
    public List<GameObject> building;
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


        
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);


        for (int i = 0; i < 2; i++)                         //Left
        {
            buildingFacing = leftQuaternion;
            GameObject rendomObject = RandomObject();
            Vector3 rendomPos = RandomPosition(i, rendomObject);
            rendomPos.x = -rendomPos.x;
            //Debug.Log("left rendomPos: " + rendomPos);

            //buildingBoundary1 = rendomObject.transform.GetChild(0).gameObject;
            //buildingBoundary2 = rendomObject.transform.GetChild(1).gameObject;

            //Debug.Log("rendomObject.transform.localScale: " + rendomObject.transform.localScale);
            if (buildingNum == 3)
            {
                
                //rendomObject.transform.localScale = rendomObject.transform.localScale /2f; 
                buildingFacing = RightQuaternion;

            }

            if (!Physics.CheckSphere(rendomPos, spawnCollisionCheckRadius))
            {
                //Debug.Log("spwan left");
                GameObject tempBuilding =Instantiate(rendomObject, rendomPos, buildingFacing, temp.transform.GetChild(1));
                if(buildingNum == 3)
                {
                    //tempBuilding.transform.localScale = rendomObject.transform.localScale / 2f;
                }
            }
            //GameObject tempBuilding = Instantiate(RandomObject(), rendomPos, buildingFacing, temp.transform.GetChild(1));

        }

        for (int i = 0; i < 2; i++)                     //right
        {
            buildingFacing = RightQuaternion;
            GameObject rendomObject = RandomObject();
            Vector3 rendomPos = RandomPosition(i, rendomObject);
            //Debug.Log("right rendomPos: " + rendomPos);
            
            //buildingBoundary1 = rendomObject.transform.GetChild(0).gameObject;
            //buildingBoundary2 = rendomObject.transform.GetChild(1).gameObject;

            if(buildingNum == 3)
            {
                i--;
                //buildingFacing = leftQuaternion;
                continue;
            }



            if (!Physics.CheckSphere(rendomPos, spawnCollisionCheckRadius))
            {
                //Debug.Log("spwan right");
                Instantiate(rendomObject, rendomPos, buildingFacing, temp.transform.GetChild(1));
            }
            //GameObject tempBuilding = Instantiate(RandomObject(), rendomPos, buildingFacing, temp.transform.GetChild(1));
            
        }

    
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    GameObject RandomObject()
    {
        buildingNum = Random.Range(0, building.Count);

        return building[buildingNum];
    }

    Vector3 RandomPosition(int buildingNum, GameObject building)
    {
        //buildingFacing = RightQuaternion;
        float randomX = Random.Range(9.0f, 9.9f);
        //if (Random.Range(1, 51) % 2 == 1)                      //50% randomX -> -randomX
        //{
        //    randomX = -randomX;
        //    BuildingFacing();
        //}

        if(buildingNum == 4)
        {
            randomX += 1f;
        }

        float randomZ = Random.Range(5f, 5.5f);               //(2.9f, 12.9f)
        //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));
        if (buildingNum != 0)
        {
            //float temp = building.transform.position.z - buildingBoundary1.transform.position.z;
            //if (temp < 0)
            //{
            //    temp = -temp;
            //    Debug.Log("temp: "+ temp);
            //}
            //randomZ += (temp*3) /*+ building.transform.position.z*/;
            //randomZ = (Vector3.Distance(building.transform.position, buildingBoundary1.transform.position) + building.transform.position.z)*2;
            randomZ = Random.Range(14.5f, 15f);
        }



        return new Vector3(randomX + temp.transform.position.x, temp.transform.position.y, randomZ + temp.transform.position.z);
        //Physics.CheckSphere(transform.position, sphereRadius)
    }

    //Vector3 RandomPosition()
    //{
    //    buildingFacing = RightQuaternion;
    //    float randomX = Random.Range(6.0f, 6.9f);
    //    if (Random.Range(1, 51) % 2 == 1)                      //50% randomX -> -randomX
    //    {
    //        randomX = -randomX;
    //        BuildingFacing();
    //    }

    //    float randomZ = Random.Range(2.9f, 12.9f);
    //    //Debug.Log("position: " + new Vector3(randomX, 1f, randomZ));



    //    return new Vector3(randomX + temp.transform.position.x, temp.transform.position.y, randomZ + temp.transform.position.z);
    //    //Physics.CheckSphere(transform.position, sphereRadius)
    //}

    Quaternion BuildingFacing()
    {
        //Debug.Log("BuildingFacing");
        return buildingFacing = leftQuaternion;
    }

    bool IsPointInLine(GameObject p1, GameObject p2, Vector3 Original, GameObject building)
    {
        Debug.Log("building.transform.position: " + building.transform.localPosition);
        Debug.Log("temp.transform.position: " + temp.transform.localPosition);


        Vector3 pos1 = p1.transform.position + building.transform.localPosition + temp.transform.position;
        Vector3 pos2 = p2.transform.position + building.transform.localPosition + temp.transform.position;

        //Vector3 o = Original.transform.position;

        Vector3 tempNum = Vector3.zero;
        if (!(pos1.z > pos2.z))
        {
            tempNum = pos2;
            pos2 = pos1;
            pos1 = tempNum;
        }

        Debug.Log("pos1.z: " + pos1.z + " pos2.z:" + pos2.z);
        Debug.Log("Original.z: " + Original.z);


        if (pos1.z> Original.z && pos2.z < Original.z)
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }
}

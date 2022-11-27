using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestory : MonoBehaviour
{
    float destroyTime = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
  
}

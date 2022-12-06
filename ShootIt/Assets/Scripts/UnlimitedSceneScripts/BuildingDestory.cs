using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestory : MonoBehaviour
{
    public float destroyTime = 3.5f;
    float randomY;
    [SerializeField] private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if(speed != 0)
        {
            Debug.Log("saf");
            randomY = Random.Range(-2f, 15f);
        }
           
        Destroy(this.gameObject, destroyTime);
    }

    private void Update()
    {
        
        if(transform.position.y <= randomY && speed!=0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    // Update is called once per frame

}

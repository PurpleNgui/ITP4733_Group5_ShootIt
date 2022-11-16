using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        Bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Bullet.SetActive(true);
            Debug.Log("Shooting");
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            Bullet.SetActive(false);
            Debug.Log("Stop Shooting");
        }
    }
}

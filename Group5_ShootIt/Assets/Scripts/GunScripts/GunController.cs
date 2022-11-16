using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public ParticleSystem Bullet;

    // Start is called before the first frame update
    void Start()
    {
        Bullet.Stop(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Bullet.Play(true);
            Debug.Log("Shooting");
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            Bullet.Stop(true);
            Debug.Log("Stop Shooting");
        }
    }
}

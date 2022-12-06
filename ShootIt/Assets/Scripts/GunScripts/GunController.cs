using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public ParticleSystem Bullet;

    public float fireRate = 1.0f;

    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float fire = Input.GetAxis("RT");

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //if (!Bullet.isPlaying)
            //{
            //    nextFire = Time.time + fireRate;
            //    Bullet.Emit(1);
            //}
            nextFire = Time.time + fireRate;
            Bullet.Emit(1);
        }

        if (fire != 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Bullet.Emit(1);
        }
    }
}

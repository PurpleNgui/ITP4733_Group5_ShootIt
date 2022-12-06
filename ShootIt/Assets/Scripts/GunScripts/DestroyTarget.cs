using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTarget : MonoBehaviour
{
    public GameObject Sparks;

    public ParticleSystem Bullet;
    public List<ParticleCollisionEvent> collisionEvents;

    GameObject instance;

    public Text scoreText;
    public int score = 0;
    public int shooting = 0;

    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {

        int numCollisionEvents = Bullet.GetCollisionEvents(other, collisionEvents);

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (other)
            {
                Vector3 pos = collisionEvents[i].intersection;
                instance = Instantiate(Sparks, pos, other.transform.rotation);
                Destroy(instance, 0.3f);
            }
            i++;
            shooting++;
            //score.text = "Score : " + i;
        }

        //Instantiate(Sparks, other.transform.position, other.transform.rotation);
        //Destroy(Sparks);

        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            score+=100;
            scoreText.text = /*"Score : " +*/ score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    float remainingTime = 0;
    int score = 0;
    float hitRate = 0f;

    public Text remainingTimeText;
    public Text scoreText;
    public Text hitRateText;

    public GroundSpawner groundSpawner;
    public GroundSpawner1 groundSpawner1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayResult()
    {
        if (groundSpawner)
        {
            remainingTime = groundSpawner.GetCurrentTime();
            remainingTimeText.text = string.Format("{0:d2}:{1:d2}", (int)remainingTime / 60, (int)remainingTime % 60);
        }
        else
        {
            remainingTime = groundSpawner1.GetCurrentTime();
            remainingTimeText.text = string.Format("{0:d2}:{1:d2}", (int)remainingTime / 60, (int)remainingTime % 60);
        }

        scoreText.text = score.ToString();

        hitRateText.text = hitRate + "%";
    }
}

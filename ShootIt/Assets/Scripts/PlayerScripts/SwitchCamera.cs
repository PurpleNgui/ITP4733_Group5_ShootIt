using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject firstCam;
    public GameObject thirdCam;
    public bool camMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Camera"))
        {
            Debug.Log("A");
            if(camMode == true)
            {
                camMode = false;
            }
            else
            {
                camMode = true;
            }
            StartCoroutine(SwitchCam());
        }
    }

    IEnumerator SwitchCam()
    {
        yield return new WaitForSeconds(0.01f);
        if(camMode == false)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
        }
        else
        {
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
        }
    }
}

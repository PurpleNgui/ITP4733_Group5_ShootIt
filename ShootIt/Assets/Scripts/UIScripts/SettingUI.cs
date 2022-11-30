using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public bool useMouse = true;
    public bool useStick = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mouse()
    {
        useMouse = true;
        useStick = false;
    }

    public void Stick()
    {
        useStick = true;
        useMouse = false;
    }

}

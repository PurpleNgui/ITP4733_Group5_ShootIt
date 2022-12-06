using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject osd;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject settingUI;
    [SerializeField] GameObject startUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseUI.activeInHierarchy && !settingUI.activeInHierarchy && !startUI.activeInHierarchy)     //PauseUI & SettingUI haven't opened
        {
            OpenUI(pauseUI);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseUI.activeInHierarchy) //PauseUI have opened
        {
            CloseUI(pauseUI);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && settingUI.activeInHierarchy) //SettingUI have opened
        {
            CloseUI(settingUI);
        }

        //When Pause / Setting
        if (pauseUI.activeInHierarchy || settingUI.activeInHierarchy || startUI.activeInHierarchy)
        {
            Time.timeScale = 0;     //pause the game time
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Time.timeScale = 1;     //start the game time
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void OpenUI(GameObject nextUI)
    {
        nextUI.SetActive(true);
    }

    public void CloseUI(GameObject thisUI)
    {
        thisUI.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject osd;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject settingUI;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject resultUI;

    public string againSceneName;
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        resultUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startUI)
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
            if (pauseUI.activeInHierarchy || settingUI.activeInHierarchy || startUI.activeInHierarchy || resultUI.activeInHierarchy)
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
        
    }

    public void OpenUI(GameObject nextUI)
    {
        nextUI.SetActive(true);
    }

    public void CloseUI(GameObject thisUI)
    {
        thisUI.SetActive(false);
    }

    public void CallResult()
    {
        resultUI.SetActive(true);
        resultUI.GetComponent<ResultUI>().DisplayResult();
    }

    public void CallStartPage()
    {

        startUI.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(againSceneName);
    }

    public void NextLevel()
    {
        if(nextSceneName != null)
            SceneManager.LoadScene(nextSceneName);
    }
}

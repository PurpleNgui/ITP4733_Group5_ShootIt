using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject osd;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject settingUI;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject resultUI;

    GroundSpawner groundSpawner;
    GroundSpawner1 groundSpawner1;

    public GameObject startFirstButton, pauseFirstButton, optionFirstButton;

    public string againSceneName;
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        resultUI.SetActive(false);

        if (GameObject.FindObjectOfType<GroundSpawner>())
            groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        else
            groundSpawner1 = GameObject.FindObjectOfType<GroundSpawner1>();

        EventSystem.current.SetSelectedGameObject(startFirstButton);
    }

    // Update is called once per frame
    void Update()
    {
        //if(!pauseUI.activeInHierarchy && !settingUI.activeInHierarchy && !startUI.activeInHierarchy && !resultUI.activeInHierarchy)
        //{
        //    if (groundSpawner && groundSpawner.isEnd)
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    }
        //    else if (groundSpawner1.isEnd)
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}


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

            if (Input.GetButtonDown("Menu") && !pauseUI.activeInHierarchy && !settingUI.activeInHierarchy && !startUI.activeInHierarchy)     //PauseUI & SettingUI haven't opened
            {
                OpenUI(pauseUI);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            }
            else if (Input.GetButtonDown("Menu") && pauseUI.activeInHierarchy) //PauseUI have opened
            {
                CloseUI(pauseUI);
            }
            else if (Input.GetButtonDown("Menu") && settingUI.activeInHierarchy) //SettingUI have opened
            {
                CloseUI(settingUI);
            }
            else if (settingUI.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(optionFirstButton);
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
        //if(lateUI != startUI)
            nextUI.SetActive(true);
        //else
        //    startUI.SetActive(true);
    }

    public void CloseUI(GameObject thisUI)
    {
        //lateUI = thisUI;
        thisUI.SetActive(false);
        //if (groundSpawner && groundSpawner.isEnd && thisUI)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        //else if(groundSpawner1.isEnd)
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
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
        if (nextSceneName != "")
            SceneManager.LoadScene(nextSceneName);
        else 
            CallStartPage();
    }
}

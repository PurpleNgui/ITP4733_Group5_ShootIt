using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public string scenename;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   public void MultiPlayer()
    {
        SceneManager.LoadScene(scenename);
    }

    public void SinglePlayer()
    {
        transform.gameObject.SetActive(false);
    }
}

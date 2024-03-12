using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    //Play Scene n°1
    public void PlayGame ()
    {
        //Load Next Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //quit game
    public void QuitGame ()
    {
        //Debug.Log ("QUIT!");

        //Quit Game
        Application.Quit();
    }

    public void BackToMenu ()
    {
        //Load Menu Scene (0)
        SceneManager.LoadScene(0);
    }

    void Start ()
    {
        //Update Volume at Start
        AudioListener.volume = PlayerPrefs.GetFloat("volume");        
    } 
}

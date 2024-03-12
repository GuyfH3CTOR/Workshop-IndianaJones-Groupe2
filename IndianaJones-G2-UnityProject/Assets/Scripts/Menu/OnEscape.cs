using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEscape : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject UiPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Escape Button
        // if (Input.GetKeyDown(KeyCode.Escape))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateMenuPanel();
        }       
    }
    
    public void UpdateMenuPanel()
    {
        if(menuPanel.activeInHierarchy == false)
        {
            //Show Menu menuPanel
            menuPanel.SetActive(true);
            //Hide Menu UiPanel
            UiPanel.SetActive(false);

            // Cursor Invisible and locked at screen center
            Cursor.lockState = CursorLockMode.None;
            
            Camera360Movement.cameraCanRotate = false;
            // CursorManagement.b_IsCursorLocked = false;

            Time.timeScale = 0;
        }
        else
        {
            //Show Menu menuPanel
            menuPanel.SetActive(false);
            //Hide Menu UiPanel
            UiPanel.SetActive(true);

            // Cursor Invisible and locked at screen center
            Cursor.lockState = CursorLockMode.Locked;

            Camera360Movement.cameraCanRotate = true;
            // CursorManagement.b_IsCursorLocked = true;
            
            Time.timeScale = 1;
        }
    }
}

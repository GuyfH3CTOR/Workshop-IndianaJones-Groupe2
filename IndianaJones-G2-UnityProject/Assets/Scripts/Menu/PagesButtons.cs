using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pages;

    private int currentPage;
    private int numberOfPages;

    void Start()
    {
        numberOfPages= pages.Length;
        // Debug.Log(numberOfPages);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // Debug.Log("A");
            TurnPageLeft();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("E");
            TurnPageRight();
        }
    }

    public void TurnPageLeft()
    {
        currentPage--;
        currentPage = Mathf.Clamp(currentPage,0,numberOfPages-1);
        // Debug.Log("left"+currentPage);
        UpdatePages();
    }

    public void TurnPageRight()
    {
        currentPage++;
        currentPage = Mathf.Clamp(currentPage,0,numberOfPages-1);
        // Debug.Log("right"+currentPage);
        UpdatePages();
    }

    public void UpdatePages()
    {
        foreach(GameObject page in pages) 
        {
            page.SetActive(false);
        }
        
        pages[currentPage].SetActive(true);
        // Debug.Log(pages[currentPage]);
    }
}

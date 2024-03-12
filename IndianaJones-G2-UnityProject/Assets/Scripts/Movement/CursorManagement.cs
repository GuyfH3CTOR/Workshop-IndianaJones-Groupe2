using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManagement : MonoBehaviour
{
    [SerializeField] private GameObject g_CursorNormal;
    [SerializeField] private GameObject g_CursorOver;

    public static bool b_IsCursorNormal = true;
    public static bool b_IsCursorLocked = true;

    [SerializeField] private Texture2D t2D_CursorOver;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Update()
    {
        if(b_IsCursorLocked)
        {
            // Cursor Invisible and locked at screen center
            Cursor.lockState = CursorLockMode.Locked;
            
            // Set Locked cursor widget
            if(b_IsCursorNormal)
            {
                g_CursorNormal.SetActive(true);
                g_CursorOver.SetActive(false);
            }
            else
            {
                g_CursorNormal.SetActive(false);
                g_CursorOver.SetActive(true);
            }
        }
        else
        {
            // Deactivate Locked cursor widget
            g_CursorNormal.SetActive(false);
            g_CursorOver.SetActive(false);

            // Cursor visible and free
            Cursor.lockState = CursorLockMode.None;

            if(b_IsCursorNormal)
            {
                // Reset Cursor to default
                Cursor.SetCursor(null, hotSpot, cursorMode);
            }
            else
            {
                // Set Cursor to Over
                Cursor.SetCursor(t2D_CursorOver, hotSpot, cursorMode);
            }
        }
    }
}

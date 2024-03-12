using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class OnKeyPressed : MonoBehaviour
{
    // Event if correct Select Number
    [Serializable] public class OpenJournalEvent : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private OpenJournalEvent e_OpenJournalEvent = new OpenJournalEvent();

    // Event if correct Select Number
    [Serializable] public class CloseJournalEvent : UnityEvent {}
    [FormerlySerializedAs("onClick")]
    [SerializeField] private CloseJournalEvent e_CloseJournalEvent = new CloseJournalEvent();

    [SerializeField] private GameObject g_BoutonOn;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            // Debug.Log(g_BoutonOn.activeInHierarchy);
            
            if(g_BoutonOn.activeInHierarchy == true)
            {
                e_OpenJournalEvent.Invoke();
            }
            else
            {
                e_CloseJournalEvent.Invoke();
            }
        }
    }
}

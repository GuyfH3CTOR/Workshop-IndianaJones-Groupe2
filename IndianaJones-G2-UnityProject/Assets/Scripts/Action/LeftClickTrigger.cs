using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class LeftClickTrigger : MonoBehaviour
{
    [Serializable]
    public class TriggerClickedEvent : UnityEvent {}
    
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private TriggerClickedEvent m_OnClick = new TriggerClickedEvent();
    
    //Select transform Camera;
    [SerializeField]
    private Transform ViewCameraTransform;
    
    //Select Button type;
    [SerializeField]
    private bool doOnce;
    private bool asOccured;
    private bool overObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseEnter()
    {
        overObject = true;
    }

    private void OnMouseExit()
    {
        overObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position == ViewCameraTransform.position && overObject == true)
        {
            if(Input.GetMouseButtonDown(0) && asOccured == false)
            {
                m_OnClick.Invoke();
                if(doOnce == true)
                {
                    asOccured = true;
                }
            }
        }
    }
}

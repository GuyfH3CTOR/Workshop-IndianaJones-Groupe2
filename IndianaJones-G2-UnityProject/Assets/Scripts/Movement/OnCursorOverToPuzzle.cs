using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCursorOverToPuzzle : MonoBehaviour
{
    // Select PuzzleCamera Transform
    [SerializeField] private Transform puzzleCameraTransform;
    [SerializeField] private Transform roomCameraTransform;
    private Vector3 puzzleCameraPosition;
    private Vector3 roomCameraPosition;
    private Quaternion roomCameraRotation;

    // Select Camera Speed
    [SerializeField]
    private float timeTakenDuringLerp = 10F;

    // [SerializeField]
    // private float cameraRotSpeed = 0.005F;
    // private float cameraRotationSpeed = 1F;    

    // Set Lerping Floats
    private float startTime;
    private float journeyLength;
    
    // Array for all chidren renderers
    private Renderer[] renderers;

    // Set Lerping boolean
    private bool overObject;    
    private bool getLerping;
    private bool DoesCameraRotateAtArrival;

    // Transform of Lerping Start/End Position
    private Vector3 startPosition;
    private Vector3 endPosition;

    // Transform of Lerping Start/End Position
    private Quaternion startRotation;
    private Quaternion endRotation;

    // Puzzle OnMouseOver Collider
    private Collider myCollider;

    void Start()
    {
        // Get all children renderers
        renderers = GetComponentsInChildren<Renderer>();

        puzzleCameraPosition = puzzleCameraTransform.position;

        // Get OnMouseOver Collider
        myCollider = GetComponent<Collider>();
    }

    void Update()
    {
        // Camera Can Rotate
        if(Camera.main.transform.position != puzzleCameraTransform.position)
        {
            // Set Puzzle Collider
            myCollider.enabled = true;
        }
        else
        {            
            // Set Puzzle Collider
            myCollider.enabled = false;
        }

        // On Click 
        if(Input.GetMouseButtonUp(0) && Camera.main.transform.position == roomCameraTransform.position && overObject == true && getLerping == false && Camera360Movement.cameraIsMoving == false)
        {
            // Set roomCameraTransform
            roomCameraPosition = Camera.main.transform.position;
            roomCameraRotation = Camera.main.transform.rotation;
            // Debug.Log(roomCameraRotation);

            // Set Start/End Lerping Position
            startPosition = roomCameraPosition;
            endPosition = puzzleCameraPosition;

            // Set Start/End Lerping Position
            startRotation = roomCameraRotation;
            endRotation = puzzleCameraTransform.rotation;

            // Set Puzzle Collider
            myCollider.enabled = false;

            // Set Cursor
            CursorManagement.b_IsCursorLocked = false;
            CursorManagement.b_IsCursorNormal = true;

            StartLerping();
            Camera360Movement.cameraIsMoving = true;
        }

        if(Input.GetMouseButtonDown(1) && Camera.main.transform.position == puzzleCameraTransform.position && getLerping == false)
        {
            // Set Start/End Lerping Position
            startPosition = puzzleCameraPosition;
            endPosition = roomCameraPosition;

            // Set Start/End Lerping Position
            startRotation = puzzleCameraTransform.rotation;
            endRotation = roomCameraRotation; 

            // Set Puzzle Collider
            myCollider.enabled = true;
            Camera360Movement.cameraIsMoving = true;

            StartLerping();
            
            // Set Cursor
            CursorManagement.b_IsCursorLocked = true;
        }
    }

    void FixedUpdate()
    {
        // Lerping Update
        if(getLerping == true)
        {
            LerpingToNewPosition();
        }
    }

    private void OnMouseEnter()
    {
        //is Player in Room Camera
        if(Camera.main.transform.position != puzzleCameraTransform.position)
        {
            overObject = true;
        }

        if(Camera.main.transform.position == roomCameraTransform.position)
        {            
            // Set Cursor
            CursorManagement.b_IsCursorNormal = false;
        }
    }

    private void OnMouseExit()
    {
        //is Player in Room Camera
        if(Camera.main.transform.position != puzzleCameraTransform.position)
        {
            overObject = false;

        }

        if(Camera.main.transform.position == roomCameraTransform.position)
        {            
            // Set Cursor
            CursorManagement.b_IsCursorNormal = true;
        }
    }

    private void StartLerping()
    {
        // Set StartTime at the lerping first tick
        startTime = Time.time;

        // Disable Camera Rotation
        Camera360Movement.cameraCanRotate = false;

        // Get Length between startMarker and endMarker
        journeyLength = Vector3.Distance(startPosition, endPosition);

        // Start Lerping Update
        getLerping = true;
    }
    
    private void LerpingToNewPosition()
    {          
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * timeTakenDuringLerp;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = Mathf.Clamp(distCovered / journeyLength,0,1);

        // Set our position as a fraction of the distance between the markers.
        Camera.main.transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);

        // Set our Rotation as a fraction of the distance between the markers.
        Camera.main.transform.rotation = Quaternion.Slerp(startRotation, endRotation, fractionOfJourney);

        // check if lerp is done and if the player was NOT looking at the puzzle 
        if(fractionOfJourney >= 1)
        {            
            // reset fractionOfJourney
            fractionOfJourney = 0;

            if(Camera.main.transform.position != puzzleCameraTransform.position)
            {
                // Enable Camera Rotation
                Camera360Movement.cameraCanRotate = true;
            }
            else
            {                
                // Set Cursor
                CursorManagement.b_IsCursorLocked = false;
                CursorManagement.b_IsCursorNormal = true;
            }

            if(DoesCameraRotateAtArrival == true)
            {
                // Enable Camera Rotation
                Camera360Movement.cameraCanRotate = true;
            }
            
            // Stop Lerping
            getLerping = false;
            Camera360Movement.cameraIsMoving = false;
        }
    }
}

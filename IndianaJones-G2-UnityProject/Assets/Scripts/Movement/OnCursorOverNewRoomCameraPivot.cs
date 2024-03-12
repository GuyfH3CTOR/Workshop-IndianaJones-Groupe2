using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONCursorOverNewRoomCameraPivot : MonoBehaviour
{
    // Select NewRoomCamera Transform
    [SerializeField]
    private Transform NewRoomCamera;

    [SerializeField]
    private float cameraMovSpeed;

    [SerializeField]
    private bool DoesCameraRotateAtArrival = true;

    [SerializeField]
    private AudioSource as_WalkingSound;
    
    private Vector3 cameraInitialPosition;
    private float startTime;    
    private float journeyLength;
    private bool canClick = true;
    private bool GetLerping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetLerping == true)
        {
            LerpingToNewPosition();
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0) && canClick == true && Camera360Movement.cameraIsMoving == false)
        {
            StartLerping();
            canClick = false;
        }
    }

    private void StartLerping()
    {
        // Set StartTime at the lerping first tick
        startTime = Time.time;

        // Disable Camera Rotation
        Camera360Movement.cameraCanRotate = false;

        // Get Length between startMarker and endMarker
        journeyLength = Vector3.Distance(Camera.main.transform.position, NewRoomCamera.position);

        // Get Camera Initial Position
        cameraInitialPosition = Camera.main.transform.position;

        GetLerping = true;
        Camera360Movement.cameraIsMoving = true;
        
        as_WalkingSound.Play(0);
    }
    
    private void LerpingToNewPosition()
    {          
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * cameraMovSpeed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourneyToRoom = Mathf.Clamp(distCovered / journeyLength,0,1);

        // Set our position as a fraction of the distance between the markers.
        Camera.main.transform.position = Vector3.Lerp(cameraInitialPosition, NewRoomCamera.position, fractionOfJourneyToRoom);

        // Debug.Log(fractionOfJourneyToRoom1+ "fractionOfJourneyToRoom1");

        // check if lerp is done and if the player was NOT looking at the puzzle 
        if(fractionOfJourneyToRoom == 1)
        {
            // Stop Lerping
            GetLerping = false;

            // reset fractionOfJourney
            fractionOfJourneyToRoom = 0;

            if(DoesCameraRotateAtArrival == true)
            {
                // Enable Camera Rotation
                Camera360Movement.cameraCanRotate = true;
            }

            canClick = true;
            Camera360Movement.cameraIsMoving = false;
            
            as_WalkingSound.Stop();
        }
    }
}

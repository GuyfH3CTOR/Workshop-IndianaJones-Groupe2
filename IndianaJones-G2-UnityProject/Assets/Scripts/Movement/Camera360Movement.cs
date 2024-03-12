using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera360Movement : MonoBehaviour
{
    //CameraSpeed
    [SerializeField]
    public float speed;

    //Camera Max Up and Down angle
    [SerializeField]
    public int cameraMaxAngleUp = 40;
    [SerializeField]
    public int cameraMaxAngleDown = 340;

    //cameraRotation
	private float X;
	private float Y;

    // lock camera rotation
    public static bool cameraCanRotate;

    // Is Camera Rotating
    public static bool cameraIsRotating;

    // Is Camera Moving
    public static bool cameraIsMoving;

    // Is Over Something
    public static bool overSomething;

    void Start()
    {
        cameraCanRotate = true;
    }
    
    // Update is called once per frame
    void Update()
    {   
        if(cameraCanRotate) 
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * speed, Input.GetAxis("Mouse X") * speed, 0));

            //Get camera current rotation
            if(transform.rotation.eulerAngles.x > 0 && transform.rotation.eulerAngles.x < cameraMaxAngleDown)
            {
                X = Mathf.Clamp(transform.rotation.eulerAngles.x,0,cameraMaxAngleDown);
            }
            else
            {
                if(transform.rotation.eulerAngles.x > cameraMaxAngleUp && transform.rotation.eulerAngles.x < 360)
                {
                    X = Mathf.Clamp(transform.rotation.eulerAngles.x,cameraMaxAngleUp,360);
                }
            };
            Y = transform.rotation.eulerAngles.y;

            //Update Camera Rotation
            transform.rotation = Quaternion.Euler(X, Y, 0);
            // Debug.Log(X);
            // Debug.Log(Quaternion.Euler(X, Y, 0));

            CursorManagement.b_IsCursorLocked = true;
        }
    }
}

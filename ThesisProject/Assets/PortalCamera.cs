using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portalB;
    public Transform portalA;
    //public Vector3 vecky;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculate offset between playerCamera and PortalB
        Vector3 playerOffsetFromPortal = playerCamera.position - portalA.position;
        //Debug.Log("Player Offset: " + playerOffsetFromPortal);  
        Debug.Log("Portal B Position: " + portalA.position);
        Debug.Log("Player Cam Pos: " + playerCamera.position);
        
        //Vector3 transformedPlayerOffset = portalA.TransformPoint(portalA.InverseTransformPoint(playerOffsetFromPortal));
        
        //set the camera's position to the portal's position plus the player's offset
        //transform.position = portalA.position + transformedPlayerOffset;
        transform.position = portalB.position + playerOffsetFromPortal;
        Debug.Log("CurrentPos: " + transform.position);

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portalA.rotation, portalB.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}

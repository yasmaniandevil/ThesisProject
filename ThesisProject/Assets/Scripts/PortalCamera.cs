using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    [FormerlySerializedAs("portalB")] public Transform Portal;
    [FormerlySerializedAs("portalA")] public Transform otherPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnPreCull()
    {
        //calculate offset between playerCamera and PortalB
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        
        //set the camera's position to the portal's position plus the player's offset
        transform.position = Portal.position + playerOffsetFromPortal;
        
        // Calculate the angular difference in rotation between the two portals
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(Portal.rotation, otherPortal.rotation);

        // Create a rotation that represents the difference in rotation between the two portals.
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        // Calculate the new camera direction by applying the portal's rotation difference
        // //to the playerCamera's forward direction
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        // Set the camera's rotation to look in the new camera direction.
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

    }
}

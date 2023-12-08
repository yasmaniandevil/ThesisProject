using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.PostEvent("PortalEnter", gameObject);
        Debug.Log("enter");
    }

    /*private void OnTriggerExit(Collider other)
    {
        AkSoundEngine.PostEvent("PortalExit", gameObject);
        Debug.Log("exit");
    }*/
}

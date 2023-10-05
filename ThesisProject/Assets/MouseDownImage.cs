using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class MouseDownImage : MonoBehaviour
{

    public GameObject buildingPrefab;
    public GameObject grassPrefab;
    private bool isPlacingCube = false;
    private bool isPlacingGrass = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingCube)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(isPlacingCube);
                    Instantiate(buildingPrefab, hit.point, quaternion.identity);
                    //Debug.Log("Instantiate Cube");
                } 
            }
        } 
        else if (isPlacingGrass)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray rayy = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitt;

                if (Physics.Raycast(rayy, out hitt))
                {
                    Debug.Log(isPlacingGrass);
                    Instantiate(grassPrefab, hitt.point, quaternion.identity);
                }
            }
        }
    }
    

    public void ToggleCubePlacement()
    {
        
        isPlacingCube = true;
        isPlacingGrass = false;
        Debug.Log("Toggled Cube Placement: " + isPlacingCube);
        Debug.Log("Turn off grass: " + isPlacingGrass);
    }

    public void ToggleGrassPlacement()
    {
        isPlacingCube = false;
        isPlacingGrass = true;
        Debug.Log("Toggled Grass Placement: " + isPlacingGrass);
        Debug.Log("Turn off cube: " + isPlacingCube);
    }
}

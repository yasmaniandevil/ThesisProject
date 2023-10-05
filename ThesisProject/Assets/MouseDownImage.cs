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

    //public GameObject buildingBlock;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingCube || isPlacingGrass)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("clicked");
                if (isPlacingCube)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (isPlacingCube)
                        {
                            Instantiate(buildingPrefab, hit.point, quaternion.identity);
                            
                        }
                        else if (isPlacingGrass)
                        {
                            Instantiate(grassPrefab, hit.point, quaternion.identity);
                        }
                    
                        
                    }
                }
            }
        }
    }

    public void ToggleCubePlacement()
    {
        
        isPlacingCube = !isPlacingCube;
        isPlacingGrass = false;
        Debug.Log("Toggled Cube Placement: " + isPlacingCube);
        Debug.Log("ToggleCubeGrass: " + isPlacingGrass);
    }

    public void ToggleGrassPlacement()
    {
        isPlacingGrass = !isPlacingGrass;
        isPlacingCube = false;
        Debug.Log("Toggled Grass Placement: " + isPlacingGrass);
        Debug.Log("ToggleGrassCube: " + isPlacingCube);
    }
}

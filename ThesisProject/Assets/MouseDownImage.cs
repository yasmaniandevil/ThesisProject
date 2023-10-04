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
    private bool isPlacingCube = false;

    //public GameObject buildingBlock;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacingCube)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    
                    Instantiate(buildingPrefab, hit.point, quaternion.identity);
                }
            }
        }
    }

    public void ToggleCubePlacement()
    {
        
        isPlacingCube = !isPlacingCube;
    }
}

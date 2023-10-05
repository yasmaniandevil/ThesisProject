using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class wATER : MonoBehaviour
{

    public GameObject waterPrefab;

    private bool isPlacingWater = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingWater)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(isPlacingCube);
                    Instantiate(waterPrefab, hit.point, quaternion.identity);
                    //Debug.Log("Instantiate Cube");
                }
            }

        }
    }

    public void ToggleWaterPlacement()
    {

        isPlacingWater = true;
        //Debug.Log("Toggled Cube Placement: " + isPlacingCube);
        //Debug.Log("Turn off grass: " + isPlacingGrass);
    }

}

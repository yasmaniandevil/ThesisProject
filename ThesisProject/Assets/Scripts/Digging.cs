using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{

    //public GameObject ClickedObj;

    private Vector3 targetPosition;
    private bool isMoving = false;
    public float moveSpeed = 5f;
    
    //public Animation animShovel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Dig"))
                {
                    targetPosition = hit.collider.transform.position + Vector3.up * 1f;
                    isMoving = true;
                }
                
            }
        }

        if (isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                //isMoving = false;
                gameObject.SetActive(false);
                
            }
        }
    }
    
}

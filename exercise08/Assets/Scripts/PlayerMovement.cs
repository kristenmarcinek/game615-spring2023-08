using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // The speed at which the PlayerCharacter moves
    private Camera mainCamera; // The main camera in the scene

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
           
            Vector3 mousePos = Input.mousePosition;

            
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               
                transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);
            }
        }
    }
}
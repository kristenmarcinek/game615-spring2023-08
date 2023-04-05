using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 5.0f;
    public Camera mainCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get the position of the mouse click in screen space
            Vector3 mousePos = Input.mousePosition;

            
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Move towards the hit point
                transform.position = Vector3.MoveTowards(transform.position, hit.point, speed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("banana"))
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
        }
    }
}
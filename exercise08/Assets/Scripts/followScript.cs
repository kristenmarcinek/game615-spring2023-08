using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{
    public float speed = 1.0f;

    
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        
        float step =  speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            
            target.position *= -1.0f;
        }
    }
}


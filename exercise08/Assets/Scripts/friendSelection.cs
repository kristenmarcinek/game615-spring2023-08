using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendSelection : MonoBehaviour
{


    public Renderer bodyRend;

    public Color hoverColor;
    public Color selectedColor;
    public Color defaultColor;

    public bool selected = false;
    

    // Start is called before the first frame update
    void Start()
    {
        bodyRend = GetComponent<Renderer>();
        defaultColor = bodyRend.material.color;

    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            bodyRend.material.color = hoverColor;
        }

    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            bodyRend.material.color = defaultColor;
        }
    }

    
    
}

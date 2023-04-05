using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIscript : MonoBehaviour
{
    public float playerScore;
    public TextMeshProUGUI playerScoret;

    // Start is called before the first frame update
    void Start()
    {playerScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("banana")) 
            playerScore ++;
            playerScoret.text =  playerScore.ToString()+ "bananas gotten ";
            }
}


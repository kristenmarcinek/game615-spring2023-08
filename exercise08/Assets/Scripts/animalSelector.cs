using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class animalSelector : MonoBehaviour
{
    public GameObject player;
    public GameObject[] animals;
    public float followSpeed = 5f;
    public GameObject animalInfoPanel;
    public TMP_Text animalNameText;
    public TMP_Text animalDescriptionText;
    public Button followButton;

    private GameObject selectedAnimal;
    private bool isFollowing = false;

    void Start()
    {
        // Hide the animal info panel at the start
        animalInfoPanel.SetActive(false);

        // Hide the follow button at the start
        followButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if player is moving
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // If an animal is selected and following is enabled, move it towards the player
        if (selectedAnimal != null && isFollowing)
        {
            Vector3 targetPos = player.transform.position;
            targetPos.y = selectedAnimal.transform.position.y; // keep animal at same height as player
            selectedAnimal.transform.position = Vector3.MoveTowards(selectedAnimal.transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }

    void UpdateSelectedAnimal()
    {
        // Disable following for previous animal (if any)
        if (selectedAnimal != null)
        {
            isFollowing = false;
        }

        // Set selected animal and enable following
        selectedAnimal = gameObject;
        isFollowing = true;

        // Show the animal info panel
        animalInfoPanel.SetActive(true);

        // Display animal info
        AnimalInfo animalInfo = selectedAnimal.GetComponent<AnimalInfo>();
        if (animalInfo != null)
        {
            animalNameText.text = animalInfo.name;
            animalDescriptionText.text = animalInfo.description;
        }

        // Show the follow button
        followButton.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        foreach (GameObject animal in animals)
        {
            if (animal == gameObject)
            {
                UpdateSelectedAnimal();
            }
        }
    }

    // Called when the follow button is clicked
    public void OnFollowButtonClicked()
    {
        isFollowing = !isFollowing;

        // Update the text on the button
        if (isFollowing)
        {
            followButton.GetComponentInChildren<Text>().text = "Stop Following";
        }
        else
        {
            followButton.GetComponentInChildren<Text>().text = "Start Following";
        }
    }
}
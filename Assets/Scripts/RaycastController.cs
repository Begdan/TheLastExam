using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.5f);
    private Camera mainCamera;
    [SerializeField] private static float interactionDistance = 3.0f;
    private string objectTag;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(rayOrigin);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.transform.CompareTag("Door"))
                DoorController.ManageDoor();
            if (hit.transform.CompareTag("CallElevatorButton"))
                ElevatorController.ManageDoors();
            if (hit.transform.CompareTag("LightFadeTrigger"))
                LightFadeController.FadeOut();
            if (hit.transform.CompareTag("PickUp"))
                PlayerController.ItemPickUp(hit);
            else PlayerController._pickUpItemText.gameObject.SetActive(false);
            if (PlayerController._hintText != null)
            {
                if (hit.transform.CompareTag("Hint"))
                    PlayerController.UpdateHintText(hit.transform.name);
                else PlayerController._hintText.text = "";
            }
        }
        else
        {
            PlayerController._pickUpItemText.gameObject.SetActive(false);
            PlayerController._hintText.text = "";
        }
    }
}

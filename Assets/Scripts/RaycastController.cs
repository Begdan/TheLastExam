using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.5f);
    private Camera mainCamera;
    [SerializeField] private static float interactionDistance = 3.0f;
    
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
            else if (hit.transform.CompareTag("CallElevatorButton"))
                ElevatorController.ManageDoors();
            else if (hit.transform.CompareTag("LightFadeTrigger"))
                LightFadeController.FadeOut();
        }
    }
}

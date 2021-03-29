using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool isLocked;
    private Animator animator;
    private Camera mainCamera;
    [SerializeField] private float openDistance = 5.0f;
    [SerializeField] private string doorTag = "Door";

    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0.5f);
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, openDistance))
        {
            /*Debug.DrawRay(ray.origin, ray.direction * openDistance, Color.red);*/
            if (hit.transform.CompareTag(doorTag))
            {
                if (Input.GetKeyDown(KeyCode.E) && !isLocked)
                {
                    if (!animator.GetBool("isOpened"))
                        Open();
                    else Close();
                }
            }
        }
    }

    private void Open()
    {
        animator.SetBool("isOpened", true);
    }

    private void Close()
    {
        animator.SetBool("isOpened", false);
    }
}

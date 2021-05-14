using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool isLocked;
    private static bool _isLocked;
    private static Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        _isLocked = isLocked;
    }

    public static void ManageDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isLocked)
        {
            if (!animator.GetBool("isOpened"))
                Open();
            else Close();
        }
    }

    private static void Open()
    {
        animator.SetBool("isOpened", true);
    }

    private static void Close()
    {
        animator.SetBool("isOpened", false);
    }
}

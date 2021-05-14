using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private Animator leftDoorAnimator;
    [SerializeField] private Animator rightDoorAnimator;
    
    private static Animator _leftDoorAnimator;
    private static Animator _rightDoorAnimator;
    
    void Start()
    {
        _leftDoorAnimator = leftDoorAnimator;
        _rightDoorAnimator = rightDoorAnimator;
    }

    public static void ManageDoors()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_leftDoorAnimator.GetBool("isOpened") && !_rightDoorAnimator.GetBool("isOpened"))
                Open();
            else Close();
        }
    }

    private static void Open()
    {
        _leftDoorAnimator.SetBool("isOpened", true);
        _rightDoorAnimator.SetBool("isOpened", true);
    }

    private static void Close()
    {
        _leftDoorAnimator.SetBool("isOpened", false);
        _rightDoorAnimator.SetBool("isOpened", false);
    }
}

using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool isLocked;
    private bool _isLocked;
    private Animator animator;
    public PlayerController player;

    public int doorNumber = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        _isLocked = isLocked;
    }

    public void ManageDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isLocked)
        {
            if (!animator.GetBool("isOpened"))
                Open();
            else Close();
        }
    }

    private void Open()
    {
        if (doorNumber == 0)
        {
            animator.SetBool("isOpened", true);
        }
        else if (PlayerController.playerInventory.Keys.Contains(doorNumber))
        {
            animator.SetBool("isOpened", true);
            PlayerController.playerInventory.Keys.Remove(doorNumber);
            doorNumber = 0;
            PlayerController.UpdateUI();
        }
    }

    private void Close()
    {
        animator.SetBool("isOpened", false);
    }
}

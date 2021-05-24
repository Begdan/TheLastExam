using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (doorNumber == -1)
        {
            BetweenScenesData.PlayerInventory = PlayerController.playerInventory;
            SceneManager.LoadScene("FirstFloorEnd");
        }

        if (doorNumber == -2)
        {
            BetweenScenesData.PlayerInventory = null;
            SceneManager.LoadScene("MainMenu");
        }
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
        else
        {
            var key = PlayerController.playerInventory.Keys.FirstOrDefault(x => x.RoomNumber == doorNumber);
            if (key != null)
            {
                animator.SetBool("isOpened", true);
                PlayerController.playerInventory.Keys.Remove(key);
                doorNumber = 0;
                PlayerController.UpdateUI();
            }
        }
    }

    private void Close()
    {
        animator.SetBool("isOpened", false);
    }
}

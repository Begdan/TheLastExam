using Assets.Scripts.Classes;
using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerInventory playerInventory = new PlayerInventory();

    public float walkingSpeed = 3f;
    public float runningSpeed = 6f;
    public float jumpSpeed = 8.0f;
    public float jumpReload = 1f;
    public float gravity = 40.0f;
    public Camera playerCamera;
    public Text pickUpItemText;
    public Text battariesCountText;
    public Text keysCountText;
    public Image flashlightImage;
    public GameObject flashlight;
    public Slider flashlightSlider;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f;
    public float hitDistance = 3f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public float timeUntilJump = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CharacterMovement();
        ItemPickUp();


        OnFlashlight();
        RechargeFlashlight();
    }

    void CharacterMovement()
    {
        if (timeUntilJump <= jumpReload)
            timeUntilJump += Time.deltaTime;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && timeUntilJump >= jumpReload)
        {
            moveDirection.y = jumpSpeed;
            timeUntilJump = 0;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void ItemPickUp()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.distance < hitDistance && hit.transform.CompareTag("PickUp"))
            {
                if (!pickUpItemText.gameObject.activeSelf)
                    pickUpItemText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerInventory.AddItem(hit.transform.GetComponent<ItemController>());
                    UpdateUI();
                    Destroy(hit.transform.gameObject);
                }
            }
            else pickUpItemText.gameObject.SetActive(false);
        }
    }

    void UpdateUI()
    {
        battariesCountText.text = playerInventory.Batteries.ToString();
        keysCountText.text = string.Join(" ", playerInventory.Keys);
        flashlightSlider.value = (float)(playerInventory.FlashLight / Constants.flashlightCharge);
        if (playerInventory.FlashLight.HasValue)
        {
            flashlightSlider.gameObject.SetActive(true);
            flashlightImage.gameObject.SetActive(true);
        }
    }


    void RechargeFlashlight()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerInventory.Batteries > 0)
        {
            playerInventory.FlashLight = Constants.flashlightCharge;
            playerInventory.Batteries -= 1;
            UpdateUI();
        }
    }

    void OnFlashlight()
    {
        if (!playerInventory.FlashLight.HasValue)
            return;

        if (Input.GetKeyDown(KeyCode.F))
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);

        if (flashlight.gameObject.activeSelf)
        {
            if (playerInventory.FlashLight > 0)
            {
                flashlightSlider.value = (float)(playerInventory.FlashLight / Constants.flashlightCharge);
                playerInventory.FlashLight -= Time.deltaTime;
            }
            else
                flashlight.gameObject.SetActive(false);
        }
    }
}
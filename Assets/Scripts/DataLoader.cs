using System.Collections;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    void Start()
    {
        PlayerController.playerInventory = BetweenScenesData.PlayerInventory;
        PlayerController.UpdateUI();
    }
}

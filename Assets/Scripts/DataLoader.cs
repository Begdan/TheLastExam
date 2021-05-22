using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    void Start()
    {
        PlayerController.playerInventory = BetweenScenesData.PlayerInventory;
        PlayerController.UpdateUI();
    }
}

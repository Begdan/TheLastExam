using System.Collections;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    void Start()
    {
        PlayerController.playerInventory = BetweenScenesData.PlayerInventory;
        StartCoroutine(UpdateUi());
    }

    IEnumerator UpdateUi()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerController.UpdateUI();
    }
}

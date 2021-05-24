using System.Collections;
using UnityEngine;

public class ScreamerController : MonoBehaviour
{
    public GameObject eyes;
    public GameObject screamerModel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            screamerModel.SetActive(true);
            var controller = other.GetComponent<PlayerController>();
            controller.ChangeFlashlightState(false);
            StartCoroutine(Scream(controller));
            controller.playerCamera.transform.LookAt(eyes.transform);
            screamerModel.transform.LookAt(controller.playerCamera.transform);
            controller.canMove = false;
        }
    }

    private IEnumerator Scream(PlayerController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.canMove = true;
        Destroy(screamerModel);
        Destroy(this);
    }
}

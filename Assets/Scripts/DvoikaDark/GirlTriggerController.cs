using System.Collections;
using UnityEngine;

public class GirlTriggerController : MonoBehaviour
{
    public GameObject girl;
    public GameObject girlEyes;
    public Camera camera;
    public GameObject hint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var controller = other.GetComponent<PlayerController>();
            StartCoroutine(Dismember(controller));
            camera.transform.LookAt(girlEyes.transform);
            controller.canMove = false;
        }
    }

    private IEnumerator Dismember(PlayerController controller)
    {
        yield return new WaitForSeconds(2f);
        girl.transform.rotation = Quaternion.Euler(0, 0, 0);
        StartCoroutine(Scream(controller));
    }

    private IEnumerator Scream(PlayerController controller)
    {
        yield return new WaitForSeconds(0.2f);
        hint.SetActive(true);
        Destroy(girl);
        controller.canMove = true;
        Destroy(this);
    }
}

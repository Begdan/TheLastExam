using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SofaController : MonoBehaviour
{
    private bool IsStartSleep = false;
    public GameObject playerController;
    public void StartSleep()
    {
        playerController.GetComponent<PlayerController>().canMove = false;
        IsStartSleep = true;
        StartCoroutine(CameraFade());
    }

    public GameObject panel;
    private Image _image;
    public float timeUntilBlack = 3f;

    private void Update()
    {
        if (IsStartSleep)
        {
            var currentTransparency = _image.color.a;
            var newTransparency = currentTransparency += Time.deltaTime / timeUntilBlack;
            _image.color = new Color(0, 0, 0, newTransparency);
        }
    }

    private IEnumerator CameraFade()
    {
        yield return new WaitForSeconds(timeUntilBlack + 3f);
        SceneManager.LoadScene("DvoikaDark");
    }

    private void Start()
    {
        _image = panel.GetComponent<Image>();
    }
}

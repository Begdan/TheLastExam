using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstFloorElevatorTrigger : MonoBehaviour
{
    public GameObject ElevatorTriggerWall;
    public Animator leftDoorAnimator;
    public Animator rightDoorAnimator;
    private bool isStartedFade = false;
    public GameObject panel;
    private Image _image;
    public float TimeUntilBlack = 3f;
    public float TimeUntilStartFade = 1f;

    private void Start()
    {
        _image = panel.GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ElevatorTriggerWall.gameObject.SetActive(true);
            leftDoorAnimator.SetBool("isOpened", false);
            rightDoorAnimator.SetBool("isOpened", false);
            StartCoroutine(CameraFade());
        }
    }

    private IEnumerator CameraFade()
    {
        yield return new WaitForSeconds(TimeUntilStartFade);
        isStartedFade = true;
        yield return new WaitForSeconds(TimeUntilBlack + 0.5f);
        isStartedFade = false;
        _image.color = new Color(0, 0, 0, 0);
        SceneManager.LoadScene("Dvoika");
    }

    private void Update()
    {
        if (isStartedFade)
        {
            var currentTransparency = _image.color.a;
            var newTransparency = currentTransparency + Time.deltaTime / TimeUntilBlack;
            _image.color = new Color(0, 0, 0, newTransparency);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class TydaNeNadoTrigger : MonoBehaviour
{
    public Text Text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.text = "Экзамен проходит не в тех кабинетах, мне надо вернуться";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.text = "";
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class TydaNeNadoTrigger : MonoBehaviour
{
    public Text Text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.text = "Ёкзамен проходит не в тех кабинетах, мне надо вернутьс€";
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

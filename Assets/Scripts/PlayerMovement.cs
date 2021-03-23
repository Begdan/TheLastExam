using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(verticalInput, 0, 0) * speed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, -horizontalInput) * speed * Time.deltaTime);
        
        
    }
}

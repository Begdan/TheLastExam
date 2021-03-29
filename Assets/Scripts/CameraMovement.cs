using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axis = RotationAxis.MouseX;

    public float minimumVert = -45f;
    public float maximumVert = 45f;

    public float sensHorizontal = 10f;
    public float sensVertical = 10f;

    public float rotationX = 0;
    
    void Update()
    {
        if (axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
        }

        float rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}

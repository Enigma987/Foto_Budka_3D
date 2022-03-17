using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTransform : MonoBehaviour
{
    private Vector3 actualMousePos;
    private Vector3 previousMousePos;

    void Update()
    {
        if (Input.GetMouseButton(0))
            Rotate();

        if (Input.GetMouseButton(1))
            Move();
            

        previousMousePos = Input.mousePosition;
    }

    public void Rotate()
    {
        actualMousePos = Input.mousePosition - previousMousePos;

        if (Vector3.Dot(transform.up, Vector3.up) >= 0)
            transform.Rotate(transform.up, -Vector3.Dot(actualMousePos, Camera.main.transform.right), Space.World);
        else
            transform.Rotate(transform.up, Vector3.Dot(actualMousePos, Camera.main.transform.right), Space.World);

        transform.Rotate(Camera.main.transform.right, Vector3.Dot(actualMousePos, Camera.main.transform.up), Space.World);
    }

    public void Move()
    {
        actualMousePos = Input.mousePosition - previousMousePos;

        transform.Translate(actualMousePos * 0.01f, Space.World);
    }
}

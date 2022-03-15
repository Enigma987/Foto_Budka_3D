using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotate : MonoBehaviour
{
    private Vector3 actualMousePos;
    private Vector3 previewMousePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            actualMousePos = Input.mousePosition - previewMousePos;

            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                transform.Rotate(transform.up, -Vector3.Dot(actualMousePos, Camera.main.transform.right), Space.World);
            else
                transform.Rotate(transform.up, Vector3.Dot(actualMousePos, Camera.main.transform.right), Space.World);

            transform.Rotate(Camera.main.transform.right, Vector3.Dot(actualMousePos, Camera.main.transform.up), Space.World);
        }

        previewMousePos = Input.mousePosition;
    }
}

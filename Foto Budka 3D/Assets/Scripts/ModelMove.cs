using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMove : MonoBehaviour
{
    private Vector3 actualMousePos;
    private Vector3 previewMousePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            actualMousePos = Input.mousePosition - previewMousePos;

            transform.Translate(actualMousePos * 0.01f, Space.World);
        }

        previewMousePos = Input.mousePosition;
    }
}

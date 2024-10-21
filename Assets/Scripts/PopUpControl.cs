using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControl : MonoBehaviour
{
    private float destroyTime = 3f;

    void Update()
    {
        // control the rotation of the canvas
        transform.LookAt(Camera.main.transform);

        Destroy(gameObject, destroyTime);
    }
}

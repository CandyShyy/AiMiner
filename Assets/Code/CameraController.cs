using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = -1f;
    public float rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Mouse X");
        rotation += input * sensitivity;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}

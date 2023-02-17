using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    
    void LateUpdate()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the angle between the camera position and the mouse position
        float angle = Mathf.Atan2(mousePosition.y - playerTransform.position.y, mousePosition.x - playerTransform.position.x) * Mathf.Rad2Deg - 90f;

        // Set the camera rotation around the Z-axis
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

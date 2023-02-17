using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1f;
    public float maxZoom = 5f;
    public float minZoom = 1f;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        float currentDistance = framingTransposer.m_CameraDistance;

        // Calculate the new distance based on the scroll input
        float newDistance = currentDistance + scroll * zoomSpeed;

        // Clamp the new distance within the min/max zoom range
        newDistance = Mathf.Clamp(newDistance, maxZoom, minZoom);

        // Calculate the new orthographic size based on the new distance
        float newOrthoSize = Mathf.Abs(newDistance) / 2f;

        // Set the new camera distance and orthographic size
        framingTransposer.m_CameraDistance = newDistance;
        virtualCamera.m_Lens.OrthographicSize = newOrthoSize;
    }
}

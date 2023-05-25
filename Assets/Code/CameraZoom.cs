using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float maxZoom = 20f;
    public float minZoom = 2f;

    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        { 
        float newSize = virtualCamera.m_Lens.OrthographicSize -= scroll * scrollSpeed;

        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

        virtualCamera.m_Lens.OrthographicSize = newSize;
        }
    }
}

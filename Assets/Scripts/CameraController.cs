using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float MIN_CAMERA_ZOOM = 2f;
    private const float MAX_CAMERA_ZOOM = 12f;

    [SerializeField] private GameObject virtualCamera;
    [SerializeField] private float zoomSpeed = 8f;
    [SerializeField] private float zoomAmount = 7f;
    [SerializeField] private float cameraMovementSensitivity = 10f;
    [SerializeField] private float cameraRotationSensitivity = 80f;

    // Update is called once per frame
    private void Update()
    {
        Vector3 moveVector = new(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            moveVector.z += 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVector.z -= 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += 1;
        }

        transform.position += (transform.forward * moveVector.z + transform.right * moveVector.x) * Time.deltaTime * cameraMovementSensitivity;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, cameraRotationSensitivity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, -cameraRotationSensitivity * Time.deltaTime);
        }

        // * Note: How the cinemachine camera component has been selected
        CinemachineTransposer ct = virtualCamera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();

        Vector3 followOffest = ct.m_FollowOffset;
        if (Input.mouseScrollDelta.y > 0)
        {
            followOffest.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            followOffest.y += zoomAmount;
        }
        followOffest.y = Mathf.Clamp(followOffest.y, MIN_CAMERA_ZOOM, MAX_CAMERA_ZOOM);
        ct.m_FollowOffset.y = Mathf.Lerp(ct.m_FollowOffset.y, followOffest.y, Time.deltaTime * zoomSpeed); ;
    }
}

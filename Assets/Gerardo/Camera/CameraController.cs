using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 2f;
    public float minYAngle = -60f;
    public float maxYAngle = 60f;

    private float rotationX = 0f;
    private PlayerInput playerInput;
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        float inputY = playerInput.actions["CameraMove"].ReadValue<Vector2>().y;

        rotationX += inputY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);

        CinemachineComposer composer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
        composer.m_TrackedObjectOffset.y = rotationX;
    }
}

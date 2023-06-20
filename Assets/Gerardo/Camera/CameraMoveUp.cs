using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMoveUp : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float rotationSpeed = 1f;

    private void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed || Gamepad.current != null && Gamepad.current.rightStick.y.ReadValue() > 0)
        {
            RotateCameraUp();
        }
    }

    private void RotateCameraUp()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        cameraTransform.Rotate(Vector3.right, rotationAmount);
    }
}

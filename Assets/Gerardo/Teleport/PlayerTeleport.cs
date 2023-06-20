using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private PlayerInput playerInput;
    private bool canTeleport = true;
    public float teleportDelay = 1.0f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        float inputY = playerInput.actions["Move"].ReadValue<Vector2>().y;

        if (inputY > 0.5f && canTeleport)
        {
            if (currentTeleporter != null)
            {
                StartCoroutine(TeleportDelay());
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    private IEnumerator TeleportDelay()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportDelay);
        canTeleport = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}

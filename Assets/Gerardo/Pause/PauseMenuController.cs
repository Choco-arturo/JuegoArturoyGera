using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public PlayerInput playerInput;

    private void Update()
    {
        // Verificar si se realiza la entrada correspondiente del control
        if (playerInput.actions["Pause"].triggered)
        {
            // Activar el menú de pausa
            pauseMenu.Pause();
        }
    }
}


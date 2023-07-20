using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEndRedirect : MonoBehaviour
{
    // Variables para referencias al componente Animation y nombre de la escena del menú principal
    public Animation animationToMonitor;
    public string mainMenuSceneName = "Menu";

    // Método para redirigir al menú principal
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // Método que se invoca cuando se termina la animación
    private void OnAnimationEnd()
    {
        GoToMainMenu();
    }
}

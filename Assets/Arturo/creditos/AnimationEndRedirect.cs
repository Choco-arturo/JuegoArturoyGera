using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEndRedirect : MonoBehaviour
{
    // Variables para referencias al componente Animation y nombre de la escena del men� principal
    public Animation animationToMonitor;
    public string mainMenuSceneName = "Menu";

    // M�todo para redirigir al men� principal
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // M�todo que se invoca cuando se termina la animaci�n
    private void OnAnimationEnd()
    {
        GoToMainMenu();
    }
}

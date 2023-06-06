using UnityEngine;
using UnityEngine.EventSystems;

public class NavigationCursorController : MonoBehaviour
{

    public bool resetNavigationFocus = false; // Indica si se debe restablecer el enfoque del controlador de navegaci�n

    private void Update()
    {
        // Comprueba si se debe restablecer el enfoque del controlador de navegaci�n
        if (resetNavigationFocus)
        {
            // Restablece el enfoque del controlador de navegaci�n
            EventSystem.current.SetSelectedGameObject(null);
            resetNavigationFocus = false;
        }
    }

    /*public bool showNavigationCursor = true; // Indica si el cursor de navegaci�n debe mostrarse

    private void Update()
    {
        // Comprueba si se ha pulsado un bot�n del men�
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
        {
            // Restablece el cursor de navegaci�n
            EventSystem.current.SetSelectedGameObject(null);
            ShowNavigationCursor();
        }
    }

    private void OnEnable()
    {
        // Muestra el cursor de navegaci�n al habilitar este script
        ShowNavigationCursor();
    }

    private void OnDisable()
    {
        // Oculta el cursor de navegaci�n al deshabilitar este script
        HideNavigationCursor();
    }

    private void ShowNavigationCursor()
    {
        Cursor.visible = showNavigationCursor;
    }

    private void HideNavigationCursor()
    {
        Cursor.visible = false;
    }*/
}


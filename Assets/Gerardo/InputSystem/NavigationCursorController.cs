using UnityEngine;
using UnityEngine.EventSystems;

public class NavigationCursorController : MonoBehaviour
{

    public bool resetNavigationFocus = false; // Indica si se debe restablecer el enfoque del controlador de navegación

    private void Update()
    {
        // Comprueba si se debe restablecer el enfoque del controlador de navegación
        if (resetNavigationFocus)
        {
            // Restablece el enfoque del controlador de navegación
            EventSystem.current.SetSelectedGameObject(null);
            resetNavigationFocus = false;
        }
    }

    /*public bool showNavigationCursor = true; // Indica si el cursor de navegación debe mostrarse

    private void Update()
    {
        // Comprueba si se ha pulsado un botón del menú
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
        {
            // Restablece el cursor de navegación
            EventSystem.current.SetSelectedGameObject(null);
            ShowNavigationCursor();
        }
    }

    private void OnEnable()
    {
        // Muestra el cursor de navegación al habilitar este script
        ShowNavigationCursor();
    }

    private void OnDisable()
    {
        // Oculta el cursor de navegación al deshabilitar este script
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


using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInputModule : StandaloneInputModule
{
    public GameObject defaultSelectedButton; // Referencia al botón que deseas seleccionar por defecto

    public override void ActivateModule()
    {
        base.ActivateModule();

        // Establecer el botón seleccionado por defecto
        if (defaultSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
        }
    }
}


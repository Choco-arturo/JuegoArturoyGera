using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInputModule : StandaloneInputModule
{
    public GameObject defaultSelectedButton; // Referencia al bot�n que deseas seleccionar por defecto

    public override void ActivateModule()
    {
        base.ActivateModule();

        // Establecer el bot�n seleccionado por defecto
        if (defaultSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
        }
    }
}


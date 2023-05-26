using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    public void TomarDano(float dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    //--------------------------------------------------------------//

    /*private DeathPanelScript deathCanvas;

    void Start()
    {
        deathCanvas = GameObject.Find("DeathCanvas").GetComponent<DeathPanelScript>();
    }

    void Update()
    {

        if (vida <= 0)
        {
            deathCanvas.DeathPanel.SetActive(true);
        }
    }*/
}

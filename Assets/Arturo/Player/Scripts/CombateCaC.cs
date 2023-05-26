using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radiGolpe;
    [SerializeField] private float danoGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiquienteAtaque;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(tiempoSiquienteAtaque> 0)
        {
            tiempoSiquienteAtaque -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Golpe();
            tiempoSiquienteAtaque = tiempoEntreAtaque;
        }
    }


    private void Golpe()
    {
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radiGolpe);

        foreach(Collider2D colisionador in objetos)
        {
            IDano objeto = colisionador.GetComponent<IDano>();
            if(objeto != null)
            {
                objeto.TomarDano(danoGolpe);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radiGolpe);
    }
}

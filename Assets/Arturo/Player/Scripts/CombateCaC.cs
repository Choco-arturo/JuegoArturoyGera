using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radiGolpe;
    [SerializeField] private float danoGolpe;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiquienteAtaque;

    private Animator animator;

    public PlayerInput _playerInput;

    public AudioSource attackAudioSource;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tiempoSiquienteAtaque > 0)
        {
            tiempoSiquienteAtaque -= Time.deltaTime;
        }

        if (_playerInput.actions["Attack"].WasPressedThisFrame())
        {
            Golpe();
            tiempoSiquienteAtaque = tiempoEntreAtaque;
        }
    }


    private void Golpe()
    {
        if (attackAudioSource != null && attackAudioSource.clip != null)
        {
            attackAudioSource.PlayOneShot(attackAudioSource.clip);
        }

        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radiGolpe);

        foreach(Collider2D colisionador in objetos)
        {
           
            if(colisionador.CompareTag("Enemigo"))
            {
                //colisionador.transform.GetComponent<Enemy>().TomarDano(danoGolpe);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radiGolpe);
    }
}

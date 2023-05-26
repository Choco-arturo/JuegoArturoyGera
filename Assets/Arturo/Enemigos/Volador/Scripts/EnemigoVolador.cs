using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVolador : MonoBehaviour
{

    [SerializeField] private GameObject efecto;
    
    private Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach(ContactPoint2D punto in other.contacts)
            {
                if(other.gameObject.CompareTag("Player"))
                {
                    if (punto.normal.y < -0.9)
                    {
                        animator.SetTrigger("Golpe");
                        other.gameObject.GetComponent<movimientoJugador>().Rebote();
                    }
                }
            }
        }
    }

    public void Muerte()
    {
        animator.SetTrigger("Golpe");
        Destroy(gameObject);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour, IDano
{

    public CombateJugador jugador;

    public EnemyData enemyData;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public GameObject target;
    public bool atacando;
    public bool puedeAtacar = true;


    public GameObject rango;
    public GameObject Hit;

    private bool isHit = false;
    private bool isDead = false;
    private bool canAttack = true;

    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
        enemyData = Instantiate(enemyData);
        jugador = target.GetComponent<CombateJugador>();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        Comportamientos();
    }

    public void Comportamientos()
    {
        if (isDead)
        {
            return;
        }

        

        if (!canAttack)
        {
            return;
        }

        if (isHit)
        {
            return;
        }

        if (jugador.vida <= 0)
        {
            return;
        }

        if (Mathf.Abs(transform.position.x - target.transform.position.x) > enemyData.rango_vision && !atacando)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:

                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * enemyData.speed_walk * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * enemyData.speed_walk * Time.deltaTime);
                            break;
                    }
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > enemyData.rango_ataque && !atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * enemyData.speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ani.SetBool("attack", false);
                }
                else
                {
                    ani.SetBool("walk", false);
                    ani.SetBool("run", true);
                    transform.Translate(Vector3.right * enemyData.speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ani.SetBool("attack", false);
                }
            }
            else
            {
                if (!atacando)
                {
                    if (transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }
            }
        }
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;

        isHit = false;
    }

    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TomarDano(int dano)
    {
        if (!isHit && !isDead)
        {
            isHit = true;
            ani.SetTrigger("hit");
            atacando = false;
            ani.SetBool("attack", false);

            enemyData.vida -= dano;

            if (enemyData.vida <= 0)
            {
                canAttack = false; // Desactivar la capacidad de ataque del enemigo
                StopAttackAnimation();
                Dead();
            }
        }
    }

    public void StopAttackAnimation()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }

    public void Dead()
    {
        isDead = true;
        rango.GetComponent<BoxCollider2D>().enabled = false;
        Hit.GetComponent<BoxCollider2D>().enabled = false;
        ani.SetBool("run", false);
        ani.SetBool("walk", false);
        ani.SetBool("attack", false);
        ani.SetTrigger("dead");

        float tiempoDeAnimacionMuerte = 2.0f; // Ajusta el valor según la duración de la animación de muerte
        Invoke("DestroyObject", tiempoDeAnimacionMuerte);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

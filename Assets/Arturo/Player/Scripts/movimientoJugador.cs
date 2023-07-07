using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class movimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public CombateJugador combateJugador;

    [Header("Movimiento")]

    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)] [SerializeField] private float suavizadorDeMovimeinto;
    public Vector2 velociad = Vector2.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]

    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector2 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;

    private bool saltandoDePared;


    [Header("animacion")]

    public Animator animator;


    [SerializeField] private ParticleSystem particulas;

    public PlayerInput _playerInput;

    public AudioClip[] footstepSounds;
    public float stepInterval = 0.5f;
    public AudioSource audioSource;
    private float stepTimer;
    private bool isMoving;
    private Vector2 movement;

    [SerializeField] private AudioSource jumpAudioSource;

    //atacque al player

    public bool damage_;
    public int empuje;
    public CombateCaC player;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        stepTimer = stepInterval;
        combateJugador = GetComponent<CombateJugador>();
    }

    void Update()
    {
        if (combateJugador != null && combateJugador.vida > 0)
        {
            Damage();

            //inputX = _playerInput.actions["Move"].ReadValue<Vector2>().x;
            movimientoHorizontal = _playerInput.actions["Move"].ReadValue<Vector2>().x * velocidadDeMovimiento;

            animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
            animator.SetFloat("VelocidadY", rb2D.velocity.y);


            if (_playerInput.actions["Jump"].WasPressedThisFrame())
            {

                // Salto normal cuando no se está en la escalera
                salto = true;
                particulas.Play();
            }
        }
        


    }

    private void FixedUpdate()
    {
        if (combateJugador != null && combateJugador.vida > 0)
        {
            enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

            animator.SetBool("enSuelo", enSuelo);




            Mover(movimientoHorizontal * Time.deltaTime, salto);

            salto = false;
        }
        

        
    }

    private void Mover(float mover, bool saltar)
    {
        
            if (!saltandoDePared)
            {
                Vector2 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
                rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velociad, suavizadorDeMovimeinto);
            }



            if (mover > 0 && !mirandoDerecha)
            {
                Girar();
            }

            else if (mover < 0 && mirandoDerecha)
            {
                Girar();
            }



            if (enSuelo && saltar)
            {
                Salto();
            }
        

    }

    public void Damage()
    {
        if(damage_)
        {
            transform.Translate(Vector3.right * empuje*Time.deltaTime, Space.World);
            
            salto = false;
            //enPared = false;
            //deslizando = false;
            //saltandoDePared = false;
            //isMoving = true;

            
        }
    }

    public void Finish_Damage()
    {
        damage_= false;
    }

    

    private void Salto()
    {
        if (jumpAudioSource != null && jumpAudioSource.clip != null)
        {
            jumpAudioSource.PlayOneShot(jumpAudioSource.clip);
        }
        enSuelo = false;
        rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        particulas.Play();
    }

    public void Rebote()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector2 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
        particulas.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        
    }

    /*private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];
            audioSource.Play();
        }
    }*/
}

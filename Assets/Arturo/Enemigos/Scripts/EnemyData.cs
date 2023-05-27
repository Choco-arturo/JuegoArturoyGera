using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Vida")]
    public float vida;

    [Header("Ataque")]
    public float distanciaAtaque;
    public float radioAtaque;
    public float danoAtaque;

    [Header("Movimiento")]
    public float velocidadMovimiento;
}

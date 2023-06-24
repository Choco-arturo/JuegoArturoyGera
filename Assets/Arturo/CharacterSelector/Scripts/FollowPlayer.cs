using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        // Buscar el jugador por tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Verificar si se encontr� el jugador
        if (player == null)
        {
            Debug.LogWarning("No se encontr� el jugador con el tag 'Player'");
        }
    }

    private void Update()
    {
        // Verificar si se encontr� el jugador
        if (player != null)
        {
            // Obtener la posici�n del jugador
            Vector3 playerPosition = player.transform.position;

            // Actualizar la posici�n de la Virtual Camera para seguir al jugador
            transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
        }
    }
}

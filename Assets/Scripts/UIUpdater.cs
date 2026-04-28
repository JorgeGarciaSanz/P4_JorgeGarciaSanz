using TMPro;
using UnityEngine;

public class UIUpdaterClase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoVida;
    [SerializeField] private TextMeshProUGUI textoEnemigos;
    [SerializeField] private HealthClase healthJugador;

    private void Update()
    {
        // Vida del jugador
        if (healthJugador != null && textoVida != null)
        {
            textoVida.text = "Vida: " + healthJugador.Vida;
        }

        // Enemigos restantes
        if (textoEnemigos != null)
        {
            int enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemy").Length;
            textoEnemigos.text = "Enemigos: " + enemigosRestantes;
        }
    }
}

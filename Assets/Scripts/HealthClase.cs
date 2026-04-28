using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthClase : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    [SerializeField] private bool esJugador = false;

    public int Vida { get { return vida; } }

    public void TakeDamage(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0) vida = 0;

        Debug.Log(name + " vida: " + vida);

        if (vida == 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        if (esJugador)
        {
            // Reiniciar nivel al morir
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
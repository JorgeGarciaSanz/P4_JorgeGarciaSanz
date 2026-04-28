using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string escenaVictoria = "Victory";
    private bool victoriaCargada = false;

    private void Update()
    {
        if (victoriaCargada) return;

        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemigos.Length == 0)
        {
            victoriaCargada = true;
            SceneManager.LoadScene(escenaVictoria);
        }
    }
}
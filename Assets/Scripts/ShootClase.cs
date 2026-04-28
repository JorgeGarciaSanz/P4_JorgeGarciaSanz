using UnityEngine;

public class ShootClase : MonoBehaviour
{
    [SerializeField] private GameObject prefabBala;
    private string textoDebug = "Disparo una bala!";
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(textoDebug);
            //Instantiate(prefabBala,transform);
                Instantiate(prefabBala, transform.position, transform.rotation);

        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            Debug.Log("Hit: " + hit.collider.name);
        }
        int suma(int a, int b, out int resultado)
        {
            resultado=0;
            return a + b;
            
        }

        void foo()
        {
            int resultado=0;
            int a=1;
            int b=2;
            int m_suma = suma(a, b, out resultado);
            Debug.Log("Resultado: " + resultado);
        }
        
    }
}

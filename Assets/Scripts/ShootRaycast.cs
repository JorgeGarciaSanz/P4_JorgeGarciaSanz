using UnityEngine;

public class ShootRaycastClase : MonoBehaviour
{
    [SerializeField] private Transform origenDisparo;
    [SerializeField] private float rango = 100f;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private int damage = 100;

    private float siguienteDisparo = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= siguienteDisparo)
        {
            siguienteDisparo = Time.time + fireRate;

            RaycastHit hit;
            if (Physics.Raycast(origenDisparo.position, origenDisparo.forward, out hit, rango))
            {
                Debug.Log("Hit: " + hit.collider.name);

                HealthClase hp = hit.collider.GetComponentInParent<HealthClase>();
                if (hp != null)
                {
                    hp.TakeDamage(damage);
                }
            }
        }
    }
}

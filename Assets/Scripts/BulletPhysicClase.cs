using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletPhysicClase : MonoBehaviour
{
  [SerializeField] public float velocity = 5.0f;
  [SerializeField] public float lifeTime = 3.0f;

  private void Start()
  {
    Rigidbody rb = GetComponent<Rigidbody>();
    rb.linearVelocity = transform.forward * velocity;

    Destroy(gameObject, lifeTime);

  }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.name);
        /*
        if (other.GetComponent<Health>)
        {
            health.QuitarVida(10);
        }*/
    }
}

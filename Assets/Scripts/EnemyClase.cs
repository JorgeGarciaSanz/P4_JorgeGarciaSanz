using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyClase : MonoBehaviour
{
    [SerializeField] protected float detectionRange = 15f; // para el base: siempre persigue
    protected NavMeshAgent agent;
    protected Transform player;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        if (player == null) return;
        ActualizarComportamiento();
    }

    protected virtual void ActualizarComportamiento()
    {
        // Base: perseguir
        agent.SetDestination(player.position);
    }

    protected bool PlayerEnRango()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }
}

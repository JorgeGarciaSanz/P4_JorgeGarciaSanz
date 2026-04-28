using UnityEngine;

public class EnemyPatrolClase : EnemyClase

{

    [SerializeField] private Transform[] patrolPoints;

    private int currentPoint = 0;

    protected override void ActualizarComportamiento()
    {
        float distanceToPlayer = Vector3.Distance(transform.position,player.position);
        if (distanceToPlayer <= detectionRange)
        {
            agent.SetDestination(player.position);
        }else
        {
            Patrol();
        }
        
        void Patrol()
        {
           if(patrolPoints.Length ==0) return;
              agent.SetDestination(patrolPoints[currentPoint].position);

            if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 1f)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
            }
        }
    
    }
}

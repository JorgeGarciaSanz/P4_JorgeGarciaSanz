using UnityEngine;

public class EnemyFastClase : EnemyClase
{
     [SerializeField] private float speedExtra = 6f;

    protected override void Awake()
    {
        base.Awake();
        agent.speed = speedExtra;   
    }

}

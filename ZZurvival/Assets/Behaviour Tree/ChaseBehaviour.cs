using UnityEngine;
using UnityEngine.AI;


public class ChaseBehaviour : MonoBehaviour
{
    public float Speed;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void UpdateSpeed()
    {
        agent.speed = Speed;
    }
    public void Chase(Transform target, Transform self)
    {
        agent.destination = target.position;
    }
    public void Run(Transform target, Transform self)
    {
      agent.destination = (target.position - self.position).normalized * -Speed;
    }

    public void StopRunning()
    {
        agent.isStopped = true;

    }
    public void StopChasing()
    {
       
    }
}

using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public float Speed;
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void Chase(Transform target, Transform self)
    {
        _rb.velocity = (target.position - self.position).normalized * Speed;
    }
    public void Run(Transform target, Transform self)
    {
        _rb.velocity = (target.position - self.position).normalized * -Speed;
    }

    public void StopChasing()
    {
        _rb.velocity = Vector2.zero;
    }
}

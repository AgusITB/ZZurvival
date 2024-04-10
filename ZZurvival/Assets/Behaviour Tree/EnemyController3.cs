using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController3 : StateController2
{
    public float AttackDistance;
    public float HP;
    private float nextHurt = 0;

    void Update()
    {
        StateTransition();
        if (currentState.action != null)
            currentState.action.OnUpdate();

        if (Input.GetKey("space") && Time.time >= nextHurt)
        {
            OnHurt(1);
            nextHurt = Time.time + 0.3f;
        }
    }

    public void OnHurt(float damage)
    {
        HP -= damage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
        {
            Debug.Log("I saw the player");
            target = player.gameObject;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement _))
        {
            target = null;
        }
        
    }
}

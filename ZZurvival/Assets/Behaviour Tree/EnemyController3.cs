using System.Collections.Generic;
using UnityEngine;
using MEC;

public class EnemyController3 : StateController2
{
    [SerializeField] private CapsuleCollider capsule;
    public float AttackDistance;
    public float HP;
    [SerializeField] private float detection_delay;
    [SerializeField] private Animator enemyAnimator;

    CoroutineHandle rayacstCoroutineHandle;
    void Update()
    {
        StateTransition();
        if (currentState.action != null)
            currentState.action.OnUpdate();
    }

    public void OnAttack(bool isAttacking)
    {
        enemyAnimator.SetBool("isAttacking", isAttacking);
    }
    public void OnDeath()
    {
        enemyAnimator.SetBool("isDying", true);
        capsule.enabled = false;
    }
    public void OnPatrol(bool isPatroling)
    {
        enemyAnimator.SetBool("isFollowing", isPatroling);

    }
    public void OnHunt(bool isHunting)
    {
        enemyAnimator.SetBool("isHunting", isHunting);
    }

    public void OnHurt(float damage)
    {
        HP -= damage;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.TryGetComponent(out PlayerMovement player))
        {
            rayacstCoroutineHandle = Timing.RunCoroutine(DetectPlayer(player.transform));
        }
    }

    private IEnumerator<float> DetectPlayer(Transform player)
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(0.5f);
            Vector3 direction =  player.position - transform.position;
            direction.y = 0.5f;
            Debug.DrawRay(transform.position, direction * 500f, Color.green);

            int wallLayerMask = LayerMask.NameToLayer("Wall");
            int playerLayerMask = LayerMask.NameToLayer("Player");
            LayerMask layerMask = (1 << 3 | 1 << 8);

            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, 500f, layerMask);

            for (int i = 0; i < hits.Length; i++)
            {

                RaycastHit hit = hits[i];
                if (hit.collider.gameObject.layer == playerLayerMask)
                {
                    Debug.Log(hits[i].collider.name);
                    target = player.gameObject;
                }
                else if (hit.collider.gameObject.layer == wallLayerMask)
                {
                    Debug.Log(hits[i].collider.name);
                    break;
                }
             
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
        {
            target = null;
            Timing.KillCoroutines(rayacstCoroutineHandle);
        }

    }
    private void OnDrawGizmos()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            Debug.DrawRay(transform.position, direction * 500f, Color.green);
        }

    }

}

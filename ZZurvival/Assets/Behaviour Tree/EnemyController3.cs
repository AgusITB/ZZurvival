using System.Collections;
using UnityEngine;

public class EnemyController3 : StateController2
{
    public float AttackDistance;
    public float HP;
    private float nextHurt = 0;
    private float detection_delay;

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
            Vector3 direction = player.transform.position - transform.position;
            Debug.DrawRay(transform.position, direction * 500f, Color.green);

            LayerMask layermask = LayerMask.NameToLayer("Wall");

            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, 500f);
            foreach (RaycastHit item in hits)
            {
                Debug.Log(item.transform.name);
            }
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
    
                if (hit.collider.gameObject.layer == layermask)
                {
                    Debug.Log("Can't see the player");
                    break;
                }else
                {
                    Debug.Log("I saw the player");
                    target = player.gameObject;
                }
        
            }

        }
    }
    private Vector3[] GetBoundingPoints(Bounds bounds)
    {
        Vector3[] bounding_points =
        {
        bounds.min,
        bounds.max,
        new Vector3( bounds.min.x, bounds.min.y, bounds.max.z ),
        new Vector3( bounds.min.x, bounds.max.y, bounds.min.z ),
        new Vector3( bounds.max.x, bounds.min.y, bounds.min.z ),
        new Vector3( bounds.min.x, bounds.max.y, bounds.max.z ),
        new Vector3( bounds.max.x, bounds.min.y, bounds.max.z ),
        new Vector3( bounds.max.x, bounds.max.y, bounds.min.z )
    };

        return bounding_points;
    }

    private IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(detection_delay);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement player))
        {         
            target = null;
        }
        
    }
    private void OnDrawGizmos()
    {
        if(target!= null)
        {
            Vector3 direction = target.transform.position - transform.position;
            Debug.DrawRay(transform.position, direction * 500f, Color.green);
        }
      
    }

}

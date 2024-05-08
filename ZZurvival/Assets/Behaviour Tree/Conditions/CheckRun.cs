using UnityEngine;
[CreateAssetMenu(fileName = "Run", menuName = "ScriptableNodes/ScriptableConditions/Run")]

public class CheckRun : ScriptableCondition
{
    public override bool Check(StateController2 sc)
    { 
   
        var ec = (EnemyController3)sc;

        Debug.Log(ec.HP < 8 && Vector3.Distance(ec.transform.position, ec.player.transform.position) < 40f);
        return ec.HP < 8 && Vector3.Distance(ec.transform.position, ec.player.transform.position)< 40f;
    }
}


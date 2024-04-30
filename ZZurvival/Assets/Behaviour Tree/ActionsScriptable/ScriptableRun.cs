using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableRun", menuName = "ScriptableObjects2/ScriptableAction/ScriptableRun")]

public class ScriptableRun : ScriptableAction
{
    public override void OnFinishedState()
    {
        _chaseBehaviour.StopChasing();
    }

    public override void OnSetState(StateController2 sc)
    {
        base.OnSetState(sc);
        GameManager.gm.UpdateText("estoy huyendo");
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();
        _enemyController = (EnemyController3)sc;
        _chaseBehaviour.Speed = 4f;
        _chaseBehaviour.UpdateSpeed();
    }

    public override void OnUpdate()
    {
        try
        {
            _chaseBehaviour.Run(_enemyController.target.transform, sc.transform);
        }
        catch
        {
            _chaseBehaviour.StopChasing();
        }
    }

}

using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableFollow", menuName = "ScriptableObjects2/ScriptableAction/ScriptableFollow")]

public class ScriptableFollow : ScriptableAction
{
    public override void OnFinishedState()
    {
        _chaseBehaviour.StopChasing();
        _enemyController.OnHunt(false);
    }

    public override void OnSetState(StateController2 sc)
    {
        base.OnSetState(sc);
        GameManager.gm.UpdateText("Te persigo");
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();     
        _enemyController = (EnemyController3)sc;
        _enemyController.OnHunt(true);
        _chaseBehaviour.Speed = 4f;
        _chaseBehaviour.UpdateSpeed();
    }

    public override void OnUpdate()
    {
        _chaseBehaviour.Chase(_enemyController.target.transform, sc.transform);
    }
}

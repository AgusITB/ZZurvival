using UnityEngine;
[CreateAssetMenu(fileName = "ScriptableRun", menuName = "ScriptableObjects2/ScriptableAction/ScriptableRun")]

public class ScriptableRun : ScriptableAction
{
    public override void OnFinishedState()
    {
        _chaseBehaviour.StopRunning();
        _enemyController.OnEscape(false);
    }

    public override void OnSetState(StateController2 sc)
    {
        base.OnSetState(sc);
        
        GameManager.gm.UpdateText("estoy huyendo");
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();
        _enemyController = (EnemyController3)sc;
        _chaseBehaviour.Speed = 4f;
        _chaseBehaviour.UpdateSpeed();
        _enemyController.OnEscape(true);
    }

    public override void OnUpdate()
    {
        try
        {
            _chaseBehaviour.Run(_enemyController.player.transform, sc.transform);
        }
        catch
        {
            _chaseBehaviour.StopRunning();
            _enemyController.OnEscape(false);
        }
    }

}

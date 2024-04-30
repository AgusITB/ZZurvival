using UnityEngine;
[CreateAssetMenu(fileName = "ScriptablePatrol", menuName = "ScriptableObjects2/ScriptableAction/ScriptablePatrol", order = 4)]
public class ScriptablePatrol : ScriptableAction
{
    public override void OnFinishedState()
    {
        GameManager.gm.UpdateText("donde se metió?");
        _enemyController.OnPatrol(false);
    }

    public override void OnSetState(StateController2 sc)
    {
        base.OnSetState(sc);
        GameManager.gm.UpdateText("vamo a patrulla");
        _enemyController = (EnemyController3)sc;
        _enemyController.OnPatrol(true);
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();
        _chaseBehaviour.Speed = 1f;
        _chaseBehaviour.UpdateSpeed();
    }

    public override void OnUpdate()
    {
        GameManager.gm.UpdateText("apatrullando la ciuda");
    }
}

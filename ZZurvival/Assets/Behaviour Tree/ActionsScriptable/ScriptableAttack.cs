using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAttack", menuName =
    "ScriptableObjects2/ScriptableAction/ScriptableAttack", order = 1)]
public class ScriptableAttack : ScriptableAction
{
    public override void OnFinishedState()
    {
        GameManager.gm.UpdateText("va te perdono");
        _enemyController.OnAttack(false);
    }

    public override void OnSetState(StateController2 sc)
    {
        base.OnSetState(sc);
        GameManager.gm.UpdateText("a q te meto");
        _chaseBehaviour = sc.GetComponent<ChaseBehaviour>();
        _enemyController = (EnemyController3)sc;
        _enemyController.OnAttack(true);
    }

    public override void OnUpdate()
    {
        GameManager.gm.UpdateText("que te meto asin");
    }
}

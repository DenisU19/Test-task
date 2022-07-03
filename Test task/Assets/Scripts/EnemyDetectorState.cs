using UnityEngine;

public class EnemyDetectorState : PlayerStateData
{
    [SerializeField]
    private LayerMask _EnemyLayer;
    [SerializeField]
    private float _enemyDetectorRadius;
    [SerializeField]
    private Animator _heroAnimator;

    public Collider[] _enemies;


    public override void StateRun()
    {
        if (_isStateFinished)
        {
            return;
        }

        _heroAnimator.SetBool("IsRunning", false);
        _enemies = Physics.OverlapSphere(transform.position, _enemyDetectorRadius, _EnemyLayer);
        
        if (_enemies.Length <= 0)
        {
            _isStateFinished = true;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _enemyDetectorRadius);
    }
}

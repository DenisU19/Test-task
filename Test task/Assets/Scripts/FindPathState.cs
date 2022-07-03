using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class FindPathState :  PlayerStateData
{
    [SerializeField]
    private List<Transform> _patrolPoints;
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Animator _heroAnimator;

    public override void StateRun()
    {
        if(_isStateFinished)
        {
            return;
        }

        MoveToNextPatrolPoint();
    }

    public void MoveToNextPatrolPoint()
    {
        if(_patrolPoints.Count == 0)
        {
            SceneManager.LoadScene(0);
            return;
        }

        _navMeshAgent.SetDestination(_patrolPoints[0].position);
        _heroAnimator.SetBool("IsRunning", true);

        if (Vector3.Distance(_navMeshAgent.gameObject.transform.position, _patrolPoints[0].position) < 0.1f)
        {
            _patrolPoints.Remove(_patrolPoints[0]);
            _isStateFinished = true;
        }
    }

}

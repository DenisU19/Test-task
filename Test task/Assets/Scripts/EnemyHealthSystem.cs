using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private GameObject _enemyRagdoll;

    private float _currentHealth;
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            Instantiate(_enemyRagdoll, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

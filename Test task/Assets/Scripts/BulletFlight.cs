using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private float _bulletDamage;

    private EnemyHealthSystem _enemyHealthSystem;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(transform.forward * _bulletSpeed * Time.deltaTime, Space.World);
    }


    private void OnCollisionEnter(Collision collision)
    {
        _enemyHealthSystem = collision.gameObject.GetComponent<EnemyHealthSystem>();
        if (_enemyHealthSystem)
        {
            _enemyHealthSystem.ApplyDamage(_bulletDamage);
        }
        gameObject.SetActive(false);
    }

}

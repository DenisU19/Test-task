using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private int _bulletCount;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnPositon;

    private int _currentBulletNumber;
    private Transform _bulletContainer;
    public List<GameObject> _bullets;
    private void Start()
    {
        _bulletContainer = transform;

        for(int i = 0; i < _bulletCount; i++)
        {
            _bullets.Add(Instantiate(_bulletPrefab, transform.position, Quaternion.identity, _bulletContainer));
            _bullets[i].SetActive(false);
        }
    }

    public void BulletSpawn(Vector3 _bulletRotateDirection)
    {
        GameObject _currentBullet = _bulletContainer.GetChild(_currentBulletNumber).gameObject;
        _currentBullet.transform.position = _bulletSpawnPositon.position;
        _bulletSpawnPositon.rotation = Quaternion.LookRotation(_bulletRotateDirection - _bulletSpawnPositon.position);
        _currentBullet.transform.rotation = _bulletSpawnPositon.rotation;
        _currentBullet.SetActive(true);
        _currentBulletNumber++;

        if(_currentBulletNumber >= _bulletCount)
        {
            _currentBulletNumber = 0;
        }
    }
}

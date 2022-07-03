using UnityEngine;
using UnityEngine.Events;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private BulletSpawner _bulletSpawner;
    [SerializeField]
    private PlayerStateSystem _playerStateSystem;

    private Touch _currentPlayerTouch;
    private Camera _mainCamera;
    private RaycastHit hit;

    private void Start()
    {
        _mainCamera = Camera.main;
    }


    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            if (!_playerStateSystem.enabled)
            {
                _playerStateSystem.enabled = true;
                return;
            }


            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                _bulletSpawner.BulletSpawn(hit.point);
            }
            else
            {
                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);

                float minDist = Mathf.Infinity;
               
                    if (planes[5].Raycast(ray, out float distance))
                    {
                        if (distance < minDist)
                        {
                          minDist = distance;
                        }
                    }


                _bulletSpawner.BulletSpawn(ray.GetPoint(minDist)); 
            }
        }
    }
}

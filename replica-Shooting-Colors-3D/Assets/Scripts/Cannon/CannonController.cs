using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingColors3D.Cannon
{
    public class CannonController : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _ballPrefab;
        private void Update()
        {
#if UNITY_ANDROID
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Cannon"))
                    {
                        ShootBall();
                    }
                }
            }
#endif
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Cannon"))
                    {
                        print("Shooting");
                        ShootBall();
                    }
                }
            }
#endif
        }
        private void ShootBall()
        {
            Instantiate(_ballPrefab, _shootPoint.position, Quaternion.identity);
        }
    }
}
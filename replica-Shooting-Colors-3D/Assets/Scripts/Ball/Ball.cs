using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingColors3D.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _shootSpeed = 50f;

        private void FixedUpdate()
        {
            transform.position += Vector3.forward * _shootSpeed * Time.fixedDeltaTime;
        }
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
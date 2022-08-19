using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hack1
{
    public class BalaEnemiga : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] GameObject _Explosion;

        private void Update () {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D (Collider2D collision) {
            if (collision.tag == "Player") {
                Explosion(collision.transform);
            }
        }

        void Explosion (Transform lugar) {
            Instantiate(_Explosion, lugar.position, Quaternion.identity);
        }
    }
}
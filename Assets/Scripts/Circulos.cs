using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hack1
{
    public class Circulos : MonoBehaviour
    {
        public Animator _animacion;
        private void OnTriggerEnter2D (Collider2D collision) {
            if (collision.tag == "Enemie") {
                _animacion.SetTrigger("Press");
            }
        }
    }
}
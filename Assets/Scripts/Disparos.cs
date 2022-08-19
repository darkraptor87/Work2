using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hack1
{
    public class Disparos : MonoBehaviour
    {
        public static Disparos instance;

        public static Action onDisparo;

        [SerializeField] float[] _tiempos;

        private void Awake () {
            if (instance == null) {
                instance = this;
            }
        }

        public void Play () {
            StartCoroutine(TiemposDeDisparo());
        }

        public void Stop () {
            StopCoroutine(TiemposDeDisparo());
        }

        public IEnumerator TiemposDeDisparo() {
            for (int i = 0; i < _tiempos.Length; i++) {
                yield return new WaitForSeconds(_tiempos[i]);
                if (onDisparo != null) {
                    onDisparo();
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Hack1 {
    public class Nave : MonoBehaviour
    {

        [SerializeField] GameObject _bala;
        [SerializeField] GameObject _explosion;
        [SerializeField] GameObject _dano;
        [SerializeField] GameObject _texto;
        [SerializeField] GameController _gameController;
        [SerializeField] Transform _puntoDisparo;
        [SerializeField] Animator _animacion;

        private void OnEnable () {
            _gameController.onDisparando += Disparando;
        }

        private void OnDisable () {
            _gameController.onDisparando -= Disparando;
        }
        
        void Disparando (Transform obj) {
            if (obj != null) {
                GameObject objtemp;
                _puntoDisparo.LookAt(obj);
                objtemp = Instantiate(_bala, _puntoDisparo.position, _puntoDisparo.rotation);
            } else {
                DisparoFallido();
            }
        }

        public void Muerto () {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        public void Empezar () {
            _animacion.SetTrigger("Empezar");
        }

        void DisparoFallido () {
            _gameController.AnalizarPuntaje(-5);
            Instantiate(_dano, transform.position, Quaternion.identity);
            GameObject temp = Instantiate(_texto, transform.position, Quaternion.identity);
            temp.GetComponent<TextMeshPro>().color = Color.red;
            temp.GetComponent<TextMeshPro>().text = "Fail";
        }
    }
}
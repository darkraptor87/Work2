using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Hack1
{
    public class Enemigo : MonoBehaviour
    {

        [SerializeField] float _speed;
        [SerializeField] Transform _puntoDeDisparo;
        [SerializeField] GameObject _explosion;
        [SerializeField] GameObject _texto;
        [SerializeField] GameObject _bala;
        Transform _objetivo;
        Transform _nave;

        [SerializeField] float _minimoBueno;
        [SerializeField] float _minimoExelente;
        [SerializeField] int _malPuntaje, _buenPuntaje, _exelentePuntaje;

        float _distancia;

        private void Start () {
            _nave = GameController.instance.nave;
        }

        void Update () {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
            if (_objetivo != null) {
                _distancia = Vector2.Distance(transform.position, _objetivo.position);
            }
        }

        private void OnTriggerEnter2D (Collider2D collision) {
            if (collision.tag == "Fase1") {
                Disparar();
                GameController.instance.AnalizarPuntaje(_malPuntaje);
                GameController.instance.QuitarEnemigoDeLaLista();
            } else if (collision.tag == "Fase2") {
                Destroy(this.gameObject);
            }
        }

        public void ObtenerObjetivo (Transform obj) {
            _objetivo = obj;
        }

        public void DestruirObjeto () {
            VerificacionDePuntos();
            Instantiate(_explosion, transform.position ,Quaternion.identity);
            Destroy(this.gameObject);
        }

        void VerificacionDePuntos () {
            GameObject textoTemp = Instantiate(_texto, transform.position ,Quaternion.identity);
            if (_distancia < _minimoExelente) {
                GameController.instance.AnalizarPuntaje(_exelentePuntaje);
                textoTemp.GetComponent<TextMeshPro>().text = "Excellent";
                textoTemp.GetComponent<TextMeshPro>().color = Color.green;
            } else if (_distancia < _minimoBueno) {
                GameController.instance.AnalizarPuntaje(_buenPuntaje);
                textoTemp.GetComponent<TextMeshPro>().text = "Good";
                textoTemp.GetComponent<TextMeshPro>().color = Color.yellow;
            } else {
                Disparar();
                GameController.instance.AnalizarPuntaje(_malPuntaje);
                textoTemp.GetComponent<TextMeshPro>().text = "Bad";
                textoTemp.GetComponent<TextMeshPro>().color = Color.red;
            }
        }

        void Disparar () {
            _puntoDeDisparo.LookAt(_nave);
            Instantiate(_bala, _puntoDeDisparo.position, _puntoDeDisparo.rotation);
        }
    }
}
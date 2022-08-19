using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hack1
{
    public class GameController : MonoBehaviour
    {

        [SerializeField] AudioSource _audio;
        [SerializeField] EnemigosController _enemigoController;
        [SerializeField] UIController _uiController;

        [SerializeField] Transform[] _puntos;

        public static GameController instance;

        List<Enemigo> _enemigos = new List<Enemigo>();

        public Action<Transform> onDisparando;

        public Transform nave;

        public EstadoJuego _estadoJuego;

        int _puntaje;
        public int puntaje {
            get {
                return _puntaje;
            }
        }

        int _vida = 50;

        void Awake () {
            if (instance == null) {
                instance = this;
            }
        }

        void Start () {
            _estadoJuego = EstadoJuego.Espera;
            _uiController.CambiarEstado(_estadoJuego);
        }

        void Update () {
            if (!_audio.isPlaying && _estadoJuego == EstadoJuego.EnJuego) {
                _estadoJuego = EstadoJuego.Muerto;
                _uiController.CambiarEstado(_estadoJuego);
                _enemigoController.PararEnemigos();
                StartCoroutine(ParaReiniciar());
            }

            if (Input.GetKeyDown(KeyCode.W)) {
                _audio.Stop();
            }
        }

        public void PresionarIniciarJuego () {
            nave.GetComponent<Nave>().Empezar();
            StartCoroutine(IniciarJuego());
        }

        public void ReiniciarNivel () {
            SceneManager.LoadScene("Principal");
        }

        void FinDelJuego () {
            _estadoJuego = EstadoJuego.Muerto;
            _uiController.CambiarEstado(_estadoJuego);
            _enemigoController.PararEnemigos();
            _audio.Stop();
            nave.GetComponent<Nave>().Muerto();
            StartCoroutine(ParaReiniciar());
        }

        IEnumerator ParaReiniciar () {
            yield return new WaitForSeconds(1);
            _estadoJuego = EstadoJuego.Fin;
            _uiController.CambiarEstado(_estadoJuego);
        }

        IEnumerator IniciarJuego () {
            _enemigoController.IniciarEnemigos();
            yield return new WaitForSeconds(0.8f);
            _audio.Play();
            _estadoJuego = EstadoJuego.EnJuego;
            _uiController.CambiarEstado(_estadoJuego);

        }

        public void Disparo () {
            if (onDisparando != null) {
                if (_enemigos.Count > 0) {
                    onDisparando(_enemigos[0].transform);
                    Enemigo ene = _enemigos[0].GetComponent<Enemigo>();
                    _enemigos.RemoveAt(0);
                    ene.DestruirObjeto();
                } else {
                    onDisparando(null);
                }
            }
        }

        public void AnalizarPuntaje (int val) {
            if (_estadoJuego == EstadoJuego.EnJuego) {
                if (val > 0) {
                    _puntaje += val * 10;
                }

                if (_vida <= 100) {
                    _vida += val;
                } else {
                    _vida = 100;
                }

                _uiController.DiferenciaVida(_vida, _puntaje);

                if (_vida <= 0) {
                    FinDelJuego();
                }
            }
        }

        public void QuitarEnemigoDeLaLista () {
            _enemigos.RemoveAt(0);
        }


        public Transform DarObjetivo (int val, Enemigo ene) {
            Transform obj;
            _enemigos.Add(ene);
            obj = _puntos[val];
            return obj;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using SonicBloom.Koreo;
//using SonicBloom.Koreo.Players;


namespace Hack1
{
    public class EnemigosController : MonoBehaviour
    {

        [SerializeField] Transform[] _puntos;
        [SerializeField] GameObject _enemigo;

        //[SerializeField] SimpleMusicPlayer _simpleMusicPlayer;
        [SerializeReference] GameController _gameController;

        /*[EventID]
        public string eventID1;*/

        float temporal;

        private void Awake () {
            //Koreographer.Instance.RegisterForEvents(eventID1, InstanciarEnemigos);
        }

       /*private void Start () {
            _simpleMusicPlayer = GetComponent<SimpleMusicPlayer>();
        }*/

        private void OnEnable () {
            Disparos.onDisparo += PruebaFinal;
        }

        private void OnDisable () {
            Disparos.onDisparo -= PruebaFinal;
        }

        private void Update () {
            temporal += Time.deltaTime;
        }

        /*void InstanciarEnemigos (KoreographyEvent eventAS) {
            Debug.Log("1: " + temporal);
            temporal = 0;
            GameObject obj;
            int val = Random.Range(0, _puntos.Length);
            obj = Instantiate(_enemigo, _puntos[val]);
            obj.GetComponent<Enemigo>().ObtenerObjetivo(_gameController.DarObjetivo(val, obj.GetComponent<Enemigo>()));
        }*/

        void PruebaFinal () {
            GameObject obj;
            int val = Random.Range(0, _puntos.Length);
            obj = Instantiate(_enemigo, _puntos[val]);
            obj.GetComponent<Enemigo>().ObtenerObjetivo(_gameController.DarObjetivo(val, obj.GetComponent<Enemigo>()));
        }

        public void IniciarEnemigos () {
            //_simpleMusicPlayer.Play();
            Disparos.instance.Play();
        }

        public void PararEnemigos () {
            //_simpleMusicPlayer.Stop();
            Disparos.instance.Stop();
        }

    }
}
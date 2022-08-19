using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Hack1
{
    public class UIController : MonoBehaviour
    {

        [SerializeField] GameController _gameController;

        [SerializeField] Image _imagenVida;
        [SerializeField] Gradient _gradientColor;
        [SerializeField] TextMeshProUGUI _textoPuntaje;
        [SerializeField] Text _textoBoton;
        [SerializeField] GameObject _panelFinal;
        [SerializeField] TextMeshProUGUI _textoPuntajeFinal;

        EstadoJuego _estadoJuego;

        private void Start () {
            _imagenVida.fillAmount = 0.5f;
            _imagenVida.color = _gradientColor.Evaluate(0.5f);
            _textoPuntaje.text = "0";
            _textoBoton.text = "START";
            _panelFinal.SetActive(false);
        }

        public void DiferenciaVida (int vida, int puntaje) {
            _imagenVida.fillAmount = vida / 100f;
            _imagenVida.color = _gradientColor.Evaluate(vida / 100f);
            _textoPuntaje.text = puntaje + "";
        }

        public void CambiarEstado (EstadoJuego val) {
            _estadoJuego = val;
            if (_estadoJuego == EstadoJuego.EnJuego) {
                _textoBoton.text = "PRESS TO SHOOT";
            } else if (_estadoJuego == EstadoJuego.Muerto) {
                _textoBoton.text = "";
                _textoPuntajeFinal.text = _gameController.puntaje + "";
                _panelFinal.SetActive(true);
            } else if (_estadoJuego == EstadoJuego.Fin) {
                _textoBoton.text = "RESTART";
            }
        }

        public void UI_Disparo () {
            if (_estadoJuego == EstadoJuego.Espera) {
                _gameController.PresionarIniciarJuego();
            } else if (_estadoJuego == EstadoJuego.EnJuego) {
                _gameController.Disparo();
            } else if (_estadoJuego == EstadoJuego.Fin) {
                _gameController.ReiniciarNivel();
            }
        }
    }
}
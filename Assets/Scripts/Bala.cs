using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    [SerializeField] float _speed;

    private void Update () {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

}

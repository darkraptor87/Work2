using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hack1
{
    public class DestruirObjeto : MonoBehaviour
    {

        [SerializeField] float _tiempo = 1f;

        IEnumerator Start () {
            yield return new WaitForSeconds(_tiempo);
            Destroy(this.gameObject);
        }
    }
}
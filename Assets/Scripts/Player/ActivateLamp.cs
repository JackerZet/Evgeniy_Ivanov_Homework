using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyGame
{   
    public class ActivateLamp : MonoBehaviour
    {
        [SerializeField] private GameObject _light;

        [System.Obsolete]
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {                
                _light.active = _light.active == true ? false : true;
            }           
        }
    }
}

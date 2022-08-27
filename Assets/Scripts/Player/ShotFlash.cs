using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class ShotFlash : MonoBehaviour
    {
        [SerializeField] private float flashTime = 0.1f;
        private float _timeToDestroy;
        private void Start()
        {
            _timeToDestroy = Time.time + flashTime;
        }
        private void Update()
        {
            if(Time.time >= _timeToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}

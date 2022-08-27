using System.Collections;
using UnityEngine;

namespace MyGame
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject flash;
        [SerializeField] private Transform spawnBullet;
        [SerializeField] private float delay = 0.2f;
        
        private bool _shooting = false;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && _shooting)
            {
                _shooting = false;                
            }
            if (Input.GetMouseButtonDown(0) && !_shooting)
            {
                _shooting = true;
                StartCoroutine(SpawnBullet());               
            }         
        }
        private IEnumerator SpawnBullet()
        {
            while (_shooting)
            {               
                Instantiate(flash, spawnBullet.position, Quaternion.identity);
                Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
                yield return new WaitForSeconds(delay);
            }          
            yield return null;
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}

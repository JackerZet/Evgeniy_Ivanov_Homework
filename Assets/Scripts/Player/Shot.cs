using MyGame.SO;
using UnityEngine;

namespace MyGame
{
    public class Shot : MonoBehaviour
    {
        [SerializeField] private GameObject flash;
        [SerializeField] private FloatVariable speed;        
        [SerializeField] private IntVariable damage;

        private void FixedUpdate()
        {
            ChangePosition();
        }
        private void ChangePosition()
        {
            transform.position += transform.forward * speed.value * Time.deltaTime;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(flash, transform.position, Quaternion.identity);
            Destroy(gameObject);            
        }
    }
}

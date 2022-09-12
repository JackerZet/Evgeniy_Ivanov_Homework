using MyGame.SO;
using UnityEngine;

namespace MyGame
{
    public class PlayerHealthManager : MonoBehaviour
    {
        [SerializeField] private IntVariable maxHealth;
        [SerializeField] private IntVariable curHealth;       

        private void Awake()
        {
            curHealth.value = maxHealth.value;            
        }               
        public void TakeDamage(int amount)
        {
            curHealth.value -= amount;
            if(curHealth.value <= 0)
            {
                OnDeath();
            }
        }
        public void OnDeath()
        {
            GetComponentInChildren<Animator>().enabled = false;
            GetComponentInChildren<PlayerAnimatorController>().enabled = false;
        }
    }
}

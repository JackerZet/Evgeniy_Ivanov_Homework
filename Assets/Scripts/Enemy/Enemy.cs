using MyGame.SO;
using MyGame.SO.Events;
using UnityEngine;

namespace MyGame
{ 
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PlayerHealthManager player;
        [SerializeField] private IntVariable playerCurHealth;
        [SerializeField] private IntEventChannel dealDamage;

        public int damage = 2;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                TryDealDamage();
        }
        private void TryDealDamage()
        {
            if (playerCurHealth.value < 10)
            {
                int rand = Random.Range(0, 1);
                if (rand == 0)
                {
                    DealDamage(damage);
                }
            }
            else
            {
                DealDamage(damage);
            }
        }

        public void DealDamage(int damage)
        {
            dealDamage.RaiseEvent(damage);
        }    
    }
}
 
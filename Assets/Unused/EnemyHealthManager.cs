using MyGame.SO;
using UnityEngine;

namespace MyGame
{
    public class EnemyHealthManager : MonoBehaviour
    {
        [SerializeField] private IntVariable maxHealth;
        [SerializeField] private int curHealth;

        private void Awake()
        {
            curHealth = maxHealth.value;
        }
        public void TakeDamage(int amount)
        {
            curHealth -= amount;
        }
    }
}

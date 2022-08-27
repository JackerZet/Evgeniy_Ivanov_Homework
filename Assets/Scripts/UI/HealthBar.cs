using MyGame.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private IntVariable curHealth;
        [SerializeField] private IntVariable maxHealth;
        
        private float _pastHealth;
        private float _curHealth;
        private float _fillAmount;

        private void Awake()
        {
            healthBar.color = new Color(1f, 1f, 1f);
        }
        private void OnEnable()
        {
            StartCoroutine(HealthCheck());
        }
        private IEnumerator HealthCheck()
        {
            while (enabled)
            {
                _curHealth = curHealth.value;
                if (_curHealth != _pastHealth) 
                {
                    _fillAmount = (float)curHealth.value / maxHealth.value;
                    healthBar.fillAmount = _fillAmount;
                    if (curHealth.value <= maxHealth.value / 2)
                    {
                        healthBar.color = new Color(_fillAmount * 0.70f + 0.65f, _fillAmount * 2, _fillAmount * 2);
                    }
                    else
                    {
                        healthBar.color = new Color(1f, 1f, 1f);
                    }
                }
                _pastHealth = _curHealth;
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
        private void OnDisable()
        {
            StopCoroutine(HealthCheck());
        }
    }
}

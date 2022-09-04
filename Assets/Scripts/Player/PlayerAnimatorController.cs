using StarterAssets;
using UnityEngine;
using System.Collections;

namespace MyGame
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorController : MonoBehaviour
    {        
        private StarterAssetsInputs playerInputs;      
        private Animator playerAnim;

        private const string parDirX = "dirX";
        private const string parDirY = "dirY";  
        private const string parSpeed = "speed";
        private const string parJump = "jump";

        private float _dirX;
        private float _dirY;
        private float _speed;
              
        private void OnEnable()
        {
            StartCoroutine(ChangePosition());
        }
        private void Awake()
        {
            playerInputs = GetComponentInParent<StarterAssetsInputs>();
            playerAnim = GetComponent<Animator>();
        }        
        private IEnumerator ChangePosition()
        {
            while (playerAnim)
            {
                _dirX = Mathf.Lerp(_dirX, playerInputs.move.x, 0.05f);
                _dirY = Mathf.Lerp(_dirY, playerInputs.move.y, 0.05f);
                
                playerAnim.SetFloat(parDirX, _dirX);
                playerAnim.SetFloat(parDirY, _dirY);
               
                if (playerInputs.move.x == 0f && playerInputs.move.y == 0f)
                {
                    _speed = Mathf.Lerp(_speed, 0, 0.25f);                        
                }
                else
                {
                    if (!playerInputs.sprint)
                    {
                        _speed = Mathf.Lerp(_speed, 1, 0.25f);                
                    }
                    else
                    {
                        _speed = Mathf.Lerp(_speed, 2, 0.25f);                        
                    }                  
                }
                playerAnim.SetFloat(parSpeed, _speed);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerAnim.SetTrigger(parJump);
                }
                yield return new WaitForSeconds(0.01f);
            }
            yield return null;
        }
        private void OnDisable()
        {
            StopCoroutine(ChangePosition());
        }
    }
}

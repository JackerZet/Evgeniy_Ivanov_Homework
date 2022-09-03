using StarterAssets;
using UnityEngine;

namespace MyGame
{
    public class AnimatorController : MonoBehaviour
    {
        private StarterAssetsInputs playerInputs;
        private Animator playerAnimator;

        private const string dirX = "dirX";
        private const string dirY = "dirY";
        private const string walk = "walk";
        private const string run = "run";
        private bool _walk;
        private bool _run;
        private void Awake()
        {
            playerInputs = GetComponentInParent<StarterAssetsInputs>();
            playerAnimator = GetComponent<Animator>();
        }
        private void Update()
        {
            JumpAnimation();
            WalkAnimation();
            RunAnimation();           
        }
        private void WalkAnimation()
        {
            ChangeWalkDirectionY();                     
            ChangeWalkDirectionX();
            
            if (playerInputs.move.x == 0 && playerInputs.move.y == 0 && _walk)
            {
                playerAnimator.SetBool(walk, false);
                _walk = false;
            }
        }
        private void RunAnimation()
        {
            if (playerInputs.sprint && !_run && _walk)
            {
                playerAnimator.SetBool(run, true);                
                _run = true;
            }
            else if(!playerInputs.sprint && _run)
            {
                playerAnimator.SetBool(run, false);  
                _run = false;
            }
        }
        private void JumpAnimation()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAnimator.SetTrigger("jump");              
            }           
        }
        private void ChangeWalkDirectionY()
        {
            if (playerInputs.move.y != 0 || !_walk)
            {
                playerAnimator.SetBool(walk, true);
                playerAnimator.SetFloat(dirY, playerInputs.move.y);
                _walk = true;
            }
            else if (_walk)
            {
                playerAnimator.SetFloat(dirY, 0);
            }           
        }
        private void ChangeWalkDirectionX()
        {
            if (playerInputs.move.x != 0 || !_walk)
            {
                playerAnimator.SetBool(walk, true);
                playerAnimator.SetFloat(dirX, playerInputs.move.x);
                _walk = true;
            }
            else if (_walk)
            {
                playerAnimator.SetFloat(dirX, 0);
            }
        }
    }
}

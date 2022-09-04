using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    [RequireComponent(typeof(Animator))]
    public class PlayerIKController : MonoBehaviour
    {
        [SerializeField] private Transform rightHandObj = null;
        [SerializeField] private Transform leftHandObj = null;
        [SerializeField] private Transform lookObj = null;
        [SerializeField] private bool ikActive = false;
        
        protected Animator playerAnim;
        private bool objNearPlayer;
        private void Awake()
        {
            playerAnim = GetComponent<Animator>();
        }       
        private void OnTriggerEnter(Collider other)
        {          
            if(other.gameObject.CompareTag("NPC"))
            {
                objNearPlayer = true;               
            }
        }
        private void OnTriggerExit(Collider other)
        {          
            if (other.gameObject.CompareTag("NPC"))
            {
                objNearPlayer = false;
            }
        }
        private void OnAnimatorIK()
        {
            if (playerAnim)
            {               
                if (ikActive)
                {                    
                    if (lookObj != null && objNearPlayer)
                    {
                        playerAnim.SetLookAtWeight(1);
                        playerAnim.SetLookAtPosition(lookObj.position);
                    }
                    
                    if (rightHandObj != null)
                    {
                        playerAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                        playerAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        playerAnim.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                        playerAnim.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                    }
                    if (leftHandObj != null)
                    {
                        playerAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                        playerAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                        playerAnim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                        playerAnim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                    }
                }                               
                else
                {
                    playerAnim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    playerAnim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    playerAnim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                    playerAnim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                    playerAnim.SetLookAtWeight(0);
                }
            }

        }
    }
}

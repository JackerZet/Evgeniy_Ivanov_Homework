using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using StarterAssets;

namespace MyGame
{
    [RequireComponent(typeof(Volume))]
    public class VolumeController : MonoBehaviour
    {
        [Tooltip("The aperture for Bokeh, unfortunately, should be adjusted independently, depending on the screen resolution")]
        [Header("Focusing the eyes")]
        [SerializeField] private bool focusingTheEyes = false;        
        [SerializeField] private Transform playerCamera;
        [Tooltip("Max distance for focus of camera. Recomended 300")]
        [SerializeField] private float maxFocusDistance = 300f;

        private Volume _vol;
        private DepthOfField _def;  
        private Ray _ray;

        private void Awake()
        {
            _vol = GetComponent<Volume>();
            _vol.profile.TryGet(out _def);           
        }
        void Update()
        {
            if (_def && focusingTheEyes) 
            {
                _ray = new Ray(playerCamera.position, playerCamera.TransformDirection(new Vector3(0f, 0f, 1f)));
                RaycastHit hit;
                Physics.Raycast(_ray, out hit, maxFocusDistance, 1 << 0, QueryTriggerInteraction.Ignore);
                if (_def.mode.value == DepthOfFieldMode.Bokeh)
                {
                    _def.focusDistance.value = Mathf.Clamp(Mathf.Lerp(_def.focusDistance.value, hit.distance != 0f ? hit.distance : maxFocusDistance, 0.07f), 1f, maxFocusDistance);
                    _def.focalLength.value = Mathf.Clamp(_def.focusDistance.value * 1.1f + 45f , 45f, 140f) * Mathf.Pow(_def.aperture.value, 0.25f);                    
                }
                else if(_def.mode.value == DepthOfFieldMode.Gaussian)
                {
                    _def.gaussianStart.value = Mathf.Lerp(_def.gaussianStart.value, hit.distance != 0f ? hit.distance : maxFocusDistance, 0.07f);                   
                }
            }
        }
    }
}


using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace _Project.Gameplay
{
    public class PlayerVFXHandler
    {
        private readonly VolumeProfile _volumeProfile;

        private float _currentVignetteValue;
        private Tween _tween;

        public float VignetteValue => _currentVignetteValue;

        public PlayerVFXHandler(VolumeProfile volumeProfile)
        {
            _volumeProfile = volumeProfile;

            SetDefault();
        }

        private void SetDefault()
        {
            SetVignetteIntensityValue(0f, false);
        }
        
        public void SetVignetteIntensityValue(float value, bool smoothAnimation = true, float duration = 1f)
        {
            if (_volumeProfile.TryGet(out Vignette vignette))
            {
                float clampedValue = Mathf.Clamp01(value);
                _currentVignetteValue = clampedValue;
                
                if (smoothAnimation == false)
                {
                    vignette.intensity.value = clampedValue;
                    return;
                }
                
                _tween?.Kill();

                _tween = DOTween.To(
                    () => vignette.intensity.value,
                    x => vignette.intensity.value = x,
                    clampedValue, duration
                );
            }
        }
    }
}
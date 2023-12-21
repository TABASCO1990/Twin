using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Animation))]
    public class AdvertisingButton : MonoBehaviour
    {
        [SerializeField] private Timer.Watch _watch;

        private Animation _animation;

        private void Start()
        {
            _animation = GetComponent<Animation>();
        }

        private void OnEnable()
        {
            _watch.ShakeButtonAds += OnShakeButtonAds;
        }

        private void OnDisable()
        {
            _watch.ShakeButtonAds -= OnShakeButtonAds;
        }

        private void OnShakeButtonAds()
        {
            _animation.Play();
        }
    }
}

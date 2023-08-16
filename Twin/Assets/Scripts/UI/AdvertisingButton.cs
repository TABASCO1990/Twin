using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AdvertisingButton : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        _timer.SizeChanged += OnSizeChanged;
    }

    private void OnDisable()
    {
        _timer.SizeChanged -= OnSizeChanged;
    }

    private void OnSizeChanged()
    {
        _animation.Play();
    }
}

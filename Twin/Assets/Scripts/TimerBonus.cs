using DG.Tweening;
using UnityEngine;

public class TimerBonus : MonoBehaviour
{
    [SerializeField] private float _value = 10f;

    private Vector3 _valueRorate = new Vector3(0, 10, 0);
    private float _durationRotate = 1f;
    private int _countLoops = -1;
    private float _pozitionY = 1.4f;

    public float Value => _value;

    private void Start()
    {
        SetAnimation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player.Player player))
        {
            player.IncreaseTime(_value);
            DOTween.Pause(transform);
            transform.gameObject.SetActive(false);
        }
    }

    private void SetAnimation()
    {
        transform.DORotate(_valueRorate, _durationRotate).SetLoops(_countLoops, LoopType.Yoyo);
        transform.DOMove(new Vector3(transform.position.x, _pozitionY, transform.position.z), 0.5f).SetLoops(_countLoops, LoopType.Yoyo);
    }
}
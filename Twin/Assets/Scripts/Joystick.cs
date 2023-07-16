using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Joystick : MonoBehaviour
{
    [SerializeField] RectTransform _border;
    [SerializeField] RectTransform _knob;

    public RectTransform Border => _border;
    public RectTransform Knob => _knob;


    private void Awake()
    {
        _border = GetComponent<RectTransform>();
    }
}

using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(LeanLocalization))]
public class Language : MonoBehaviour
{
    [DllImport("__Internal")] public static extern string GetLang();

    private LeanLocalization _leanLocalization;
    public string CurrentLanguage;

   /* private void Awake()
    {
        _leanLocalization.CurrentLanguage = GetLang();
    }*/
}

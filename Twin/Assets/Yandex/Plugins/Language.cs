using Lean.Localization;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(LeanLocalization))]
public class Language : MonoBehaviour
{
    [DllImport("__Internal")] public static extern string GetLang();

    private LeanLocalization _leanLocalization;
    public string CurrentLanguage;
}

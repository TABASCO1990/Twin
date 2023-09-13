using UnityEngine;
using System.Runtime.InteropServices;
using Lean.Localization;
using System.Linq;

public class LanguageSwitch : MonoBehaviour
{
    [DllImport("__Internal")] public static extern string GetLang();

    private string _languageEnglish = "English";

    private void Start()
    {
        SetLanguageCountry();
    }

    private void SetLanguageCountry()
    {
        string currentLanguage = GetLang();

        for (int i = 0; i < LeanLocalization.CurrentLanguages.Count; i++)
        {
            var language = LeanLocalization.CurrentLanguages.ElementAt(i);

            if (currentLanguage == language.Value.TranslationCode)
            {
                LeanLocalization.SetCurrentLanguageAll(language.Key);
                return;
            }
        }

        LeanLocalization.SetCurrentLanguageAll(_languageEnglish);
    }
}

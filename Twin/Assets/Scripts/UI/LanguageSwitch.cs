using System.Linq;
using System.Runtime.InteropServices;
using Lean.Localization;
using UnityEngine;

namespace UI
{
    public class LanguageSwitch : MonoBehaviour
    {
        private string _languageEnglish = "English";

        private void Start()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
            SetLanguageCountry();
#endif
        }

        [DllImport("__Internal")] public static extern string GetLang();

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
}

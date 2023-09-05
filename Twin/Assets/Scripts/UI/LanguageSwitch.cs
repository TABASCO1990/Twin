using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;
using System.Runtime.InteropServices;
using System.Linq;

public class LanguageSwitch : MonoBehaviour
{
    const int LanguageRussian = 0;
    const int LanguageEnglish = 1;

    [DllImport("__Internal")] public static extern string GetLang();

    [SerializeField] private Sprite[] _flags;
    [SerializeField] private Image _imageFlag;

    private string _languageRussian = "Russian";
    private string _languageEnglish = "English";
    private string _languageTurkish = "Turkish";    
    private int _indexFlag;

    private void Start()
    {
        SetLanguageCountry();
        _imageFlag.sprite = _flags[_indexFlag];       
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
                _indexFlag = i;
                return;
            }
        }

        LeanLocalization.SetCurrentLanguageAll(_languageEnglish);
        _indexFlag = LanguageEnglish;
    }

    public void NextLanguage()
    {
        _indexFlag++;

        if (_indexFlag > _flags.Length - 1)
        {
            _indexFlag = 0;
        }

        _imageFlag.sprite = _flags[_indexFlag];
        SetLanguage();
    }

    public void PreviousLanguage()
    {
        _indexFlag--;

        if (_indexFlag < 0)
        {
            _indexFlag = _flags.Length - 1;
        }

        _imageFlag.sprite = _flags[_indexFlag];
        SetLanguage();
    }

    private void SetLanguage()
    {
        switch (_indexFlag)
        {
            case LanguageRussian:
                LeanLocalization.SetCurrentLanguageAll(_languageRussian);
                break;
            case LanguageEnglish:
                LeanLocalization.SetCurrentLanguageAll(_languageEnglish);
                break;
            default:
                LeanLocalization.SetCurrentLanguageAll(_languageTurkish);
                break;
        }
    }
}

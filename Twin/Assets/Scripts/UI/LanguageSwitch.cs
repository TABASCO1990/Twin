using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;

public class LanguageSwitch : MonoBehaviour
{
    const int LanguageRussian = 0;
    const int LanguageEnglish = 1;

    [SerializeField] private Sprite[] _flags;
    [SerializeField] private Image _imageFlag;

    private string _languageRussian = "Russian";
    private string _languageEnglish = "English";
    private string _languageTurkish = "Turkish";  

    private int indexFlag;

    private void Start()
    {
        indexFlag = 0;
        _imageFlag.sprite = _flags[indexFlag];       
    }

    public void NextLanguage()
    {
        indexFlag++;

        if (indexFlag > _flags.Length - 1)
        {
            indexFlag = 0;
        }

        _imageFlag.sprite = _flags[indexFlag];
        SetLanguage();
    }

    public void PreviousLanguage()
    {
        indexFlag--;

        if (indexFlag < 0)
        {
            indexFlag = _flags.Length - 1;
        }

        _imageFlag.sprite = _flags[indexFlag];
        SetLanguage();
    }

    private void SetLanguage()
    {
        switch (indexFlag)
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

using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;

    public IntVariable pointsToWin;

    private bool changeActive = false;

    IEnumerator SetLocale(int _localeID)
    {
        changeActive = true;       
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        changeActive = false;
    }

    public void Awake()
    {
        instance = this;
    }

    public void ChangeLocale(int localeID)
    {
        if (changeActive) {
            return;
        }
        StartCoroutine(SetLocale(localeID));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void LoadLevel(UnityEditor.SceneAsset _scene)
    {
        switch (_scene.name)
        {
            case nameof(Level_001):
                Level_001.Load();
                break;

            case nameof(Menu):
                Menu.Load();
                break;
        }
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        print("Выход");
    }

}

using UnityEngine.UI;

public class Sound : Music
{
    public override void SetStatus()
    {
        if (Progress.Inststance.PlayerInfo.isEffects)
        {
            Progress.Inststance.PlayerInfo.isEffects = false;
            _audioEffects.enabled = false;
            _musicImage.GetComponent<Image>().sprite = offMusic;
        }
        else
        {
            Progress.Inststance.PlayerInfo.isEffects = true;
            _audioEffects.enabled = true;
            _musicImage.GetComponent<Image>().sprite = onMusic;
        }

        Progress.Inststance.PlayerInfo.isSound = !Progress.Inststance.PlayerInfo.isEffects;

#if !UNITY_EDITOR && UNITY_WEBGL
        Progress.Inststance.Save();
#endif
    }
}

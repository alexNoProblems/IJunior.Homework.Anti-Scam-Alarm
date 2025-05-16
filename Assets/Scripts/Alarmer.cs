using UnityEngine;

public class Alarmer : MonoBehaviour
{
    [SerializeField] private AudioFader _audioFader;

    public void StartAlarm()
    {
        if (_audioFader != null)
            _audioFader.FadeIn();
    }

    public void StopAlarm()
    {
        if (_audioFader != null)
            _audioFader.FadeOut();
    }
}

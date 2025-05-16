using System.Collections;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private float _fadeSpeed = 0.2f;

    private Coroutine _fadeCoroutine;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    public void FadeOut()
    {
        StartFade(_minVolume);
    }

    public void FadeIn()
    {
        if (_alarmAudioSource.volume != _minVolume)
            _alarmAudioSource.volume = _minVolume;
        
        StartFade(_maxVolume);
    }

    private void StartFade(float targetVolume)
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(FadeVolume(targetVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        if (!_alarmAudioSource.isPlaying)
            _alarmAudioSource.Play();
        
        while (!Mathf.Approximately(_alarmAudioSource.volume, targetVolume))
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (Mathf.Approximately(targetVolume, _minVolume))
            _alarmAudioSource.Stop();

        _fadeCoroutine = null;
    }
}

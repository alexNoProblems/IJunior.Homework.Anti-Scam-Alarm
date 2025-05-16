using UnityEngine;

public class AudioFader : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioSource;
    [SerializeField] private float _fadeSpeed = 0.2f;

    private bool _isFading = false;
    private float _targetVolume = 0;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Update()
    {
        if (_isFading)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);

            if (Mathf.Approximately(_alarmAudioSource.volume, _targetVolume))
            {
                _isFading = false;

                if (_targetVolume == 0f)
                    _alarmAudioSource.Stop();
            }
        }
    }

    public void FadeOut()
    {
        _isFading = true;

        if (!_alarmAudioSource.isPlaying)
            _alarmAudioSource.Play();

        _targetVolume = 0f;
    }

    public void FadeIn()
    {
        _isFading = true;

        if (!_alarmAudioSource.isPlaying)
        {
            _alarmAudioSource.volume = _minVolume;
            _alarmAudioSource.Play();
        }

        _targetVolume = _maxVolume;
    }
}

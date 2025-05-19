using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private AudioSource _doorAudioSource;
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Alarmer _alarmer;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Detector _detector;

    private bool _isOpened = false;
    private bool _isAlarmOn = false;

    private void Update()
    {
        if (!_isOpened && _detector.HasRobber && _inputReader.IsOpenKeyPressed)
            OpenDoor();
    }

    private IEnumerator WaitAndStartAlarm()
    {
        yield return new WaitForSeconds(_doorAudioSource.clip.length);

        _alarmer.StartAlarm();
    }

    public void StopAlarm()
    {
        if (_isAlarmOn)
        {
            _alarmer.StopAlarm();
            _isAlarmOn = false;
        }
    }

    private void OpenDoor()
    {
        _doorAudioSource?.Play();
        _spriteRenderer.enabled = false;
        _backgroundMusicSource?.Stop();

        if (_alarmer != null && _doorAudioSource != null)
        {
            StartCoroutine(WaitAndStartAlarm());
            _isAlarmOn = true;
        }
    }
}

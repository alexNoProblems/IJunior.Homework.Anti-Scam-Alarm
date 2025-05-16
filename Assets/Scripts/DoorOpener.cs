using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private AudioSource _doorAudioSource;
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private KeyCode _openKey = KeyCode.E;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _openDistance = 1f;
    [SerializeField] private Alarmer _alarmer;
    private bool _isOpened = false;
    private bool _isAlarmOn = false;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _playerTransform.position);

        if (!_isOpened && distance <= _openDistance && Input.GetKeyDown(_openKey))
            OpenDoor();
        
        if (_isAlarmOn && distance > _openDistance)
        {
            _alarmer.StopAlarm();
            _isAlarmOn = false;
        }
    }

    private IEnumerator WaitAndStartAlarm()
    {
        yield return new WaitForSeconds(_doorAudioSource.clip.length);

        _alarmer.StartAlarm();
    }

    private void OpenDoor()
    {
        _isOpened = true;

        if (_doorAudioSource != null)
            _doorAudioSource.Play();
        
        if (_spriteRenderer != null)
            _spriteRenderer.enabled = false;
        
        if (_backgroundMusicSource != null)
            _backgroundMusicSource.Stop();
        
        if (_alarmer != null && _doorAudioSource != null)
        {
            StartCoroutine(WaitAndStartAlarm());
            _isAlarmOn = true;
        }
    }
}

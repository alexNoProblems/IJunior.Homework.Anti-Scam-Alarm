using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private AudioSource _doorAudioSource;
    [SerializeField] private AudioSource _backgroundMusicSource;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private KeyCode _openKey = KeyCode.E;
    [SerializeField] private Alarmer _alarmer;
    private bool _isOpened = false;
    private bool _isAlarmOn = false;
    private bool _isPlayerInZone = false;

    private void Update()
    {
        if (!_isOpened && _isPlayerInZone && Input.GetKeyDown(_openKey))
            OpenDoor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isOpened && other.GetComponent<Robber>() != null)
            _isPlayerInZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isAlarmOn && other.GetComponent<Robber>() != null)
        {
            _isPlayerInZone = false;

            if (_isAlarmOn)
            {
                _alarmer.StopAlarm();
                _isAlarmOn = false;
            }
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

using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action OnRobberExited;
    private bool _hasRobberInZone = false;

    public bool HasRobber => _hasRobberInZone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Robber>() != null)
            _hasRobberInZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Robber>() != null)
        {
            _hasRobberInZone = false;
            OnRobberExited?.Invoke();
        }
            
    }
}

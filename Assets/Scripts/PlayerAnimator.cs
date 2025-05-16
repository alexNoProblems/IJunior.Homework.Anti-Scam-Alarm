using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _isWalking = "IsWalking";

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool(_isWalking, isWalking);
    }
}

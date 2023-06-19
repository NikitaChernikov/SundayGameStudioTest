using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieRagdoll : MonoBehaviour
{
    public static string TAG_FOR_RAGDOLL_BODYPARTS = "ragdoll";

    private Animator _animator;
    private Rigidbody[] _childrenRb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _childrenRb = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in _childrenRb)
        {
            rb.tag = TAG_FOR_RAGDOLL_BODYPARTS;
            rb.isKinematic = true;
        }
    }

    public void Die()
    {
        foreach (Rigidbody rb in _childrenRb)
        {
            rb.isKinematic = false;
        }
        _animator.enabled = false;
    }
}

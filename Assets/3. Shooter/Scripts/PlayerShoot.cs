using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public event EventHandler OnShoot;
    public event EventHandler<OnHitEvetArgs> OnHit;

    [SerializeField] private Camera _camera;
    [SerializeField] private float hitPushForce = 50f;

    public void Shoot()
    {
        OnShoot?.Invoke(this, EventArgs.Empty);
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = _camera.ScreenPointToRay(rayStartPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            OnHit?.Invoke(this, new OnHitEvetArgs { HitObject = hit });

            if (hit.collider.CompareTag(ZombieRagdoll.TAG_FOR_RAGDOLL_BODYPARTS))
            {
                hit.transform.root.GetComponent<ZombieRagdoll>().Die();
            }

            Rigidbody objectRb = hit.transform.GetComponent<Rigidbody>();
            if (objectRb)
            {
                objectRb.AddForce(-hit.normal * hitPushForce, ForceMode.Impulse);
            }
            
        }
    }
}

public class OnHitEvetArgs : EventArgs
{
    public RaycastHit HitObject;
}

using UnityEngine;
using System.Collections;

public class ShootingVisual : MonoBehaviour
{
    [SerializeField] private GameObject _muzzleFlashPrefab;
    [SerializeField] private GameObject _bulletImpact;
    [SerializeField] private GameObject _bloodPrefab;
    [SerializeField] private PlayerShoot _playerShoot;

    private float _flashDeactivationTime = 0.1f;
    private float _bloodDeactivationTime = 5f;

    private void OnEnable()
    {
        _playerShoot.OnShoot += PlayerShoot_OnShoot;
        _playerShoot.OnHit += PlayerShoot_OnHit;
    }
    

    private void OnDisable()
    {
        _playerShoot.OnShoot -= PlayerShoot_OnShoot;
        _playerShoot.OnHit -= PlayerShoot_OnHit;
    }

    private void PlayerShoot_OnHit(object sender, OnHitEvetArgs e)
    {
        RaycastHit hitObj = e.HitObject;
        if (hitObj.collider.CompareTag(ZombieRagdoll.TAG_FOR_RAGDOLL_BODYPARTS))
        {
            Transform blood = Instantiate(_bloodPrefab, hitObj.point, Quaternion.LookRotation(hitObj.normal)).transform;
            blood.SetParent(hitObj.transform);
            Destroy(blood.gameObject, _bloodDeactivationTime);
        }
        else
        {
            Transform bulletHole = Instantiate(_bulletImpact, hitObj.point, Quaternion.LookRotation(hitObj.normal)).transform;
            bulletHole.SetParent(hitObj.transform);
        }
    }

    private void PlayerShoot_OnShoot(object sender, System.EventArgs e)
    {
        StartCoroutine(ShowFlashEffect());
    }

    private IEnumerator ShowFlashEffect()
    {
        _muzzleFlashPrefab.SetActive(true);
        yield return new WaitForSeconds(_flashDeactivationTime);
        _muzzleFlashPrefab.SetActive(false);
    }
}

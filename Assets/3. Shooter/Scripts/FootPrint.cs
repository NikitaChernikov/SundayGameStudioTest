using UnityEngine;

public class FootPrint : MonoBehaviour
{
    [SerializeField] private GameObject _footPrintPrefab;

    private void OnTriggerEnter(Collider other)
    {
        GameObject footPrint = Instantiate(_footPrintPrefab, other.ClosestPoint(transform.position), _footPrintPrefab.transform.rotation);
        Destroy(footPrint, 5f);
    }
}

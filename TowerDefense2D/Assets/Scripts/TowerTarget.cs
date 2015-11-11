using UnityEngine;
using System.Collections;

public class TowerTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _targettingRadius;

    private int _layerMask;

    void Start()
    {
        _layerMask = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(this.transform.position, _targettingRadius, _layerMask);
        if (col)
        {
            _target = col.gameObject;
        }
            
        else
        {
            _target = null;
        }
            
    }

    public GameObject GetTarget()
    {
        return _target;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, _targettingRadius);
    }
}

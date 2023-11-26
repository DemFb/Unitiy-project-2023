using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Collider _collider;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    public void EnableCollider(bool value)
    {
        _collider.enabled = value;
    }
}

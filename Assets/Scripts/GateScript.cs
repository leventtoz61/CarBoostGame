using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] private int _gateAmount=5;
    [SerializeField] private Collider _collider;
    public int GateAmount => _gateAmount; // property  açma

    public void CloseGateCollider()
    {
        _collider.enabled = false;
    }
    
}

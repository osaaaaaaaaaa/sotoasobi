using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public int damage;
    public void SetupDamage(int _damage)
    {
        damage = _damage;
    }
}

using UnityEngine;

public interface IDamageble
{
    void Damage(float damage);
    void Damage(float damage, Vector3 dir);
}

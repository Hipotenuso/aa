using System;
using UnityEngine;
using Cloth;
using System.Collections;
using System.Collections.Generic;

public class healthBase : MonoBehaviour, IDamageble
{
    public float startLife;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;
    public UIGunUpdater uiGunUpdater;
    public Action<healthBase> OnDamage;
    public Action<healthBase> OnKill;
    public float damageMultiply = 1;
    public int ALife;

    private void Awake()
    {
        Init();
    }

    public void ActualLife()
    {
        ALife = (int)_currentLife;
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = startLife;
        Debug.Log("vida startada");
        UpdateUI();
    }

    protected virtual void Kill()
    {
        if(destroyOnKill)
            Destroy(gameObject, 3f);
        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

    public void Damage(float f)
    {
        _currentLife -= f * damageMultiply;
        if(_currentLife <=0)
            Kill();
        OnDamage?.Invoke(this);
        UpdateUI();
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
    private void UpdateUI()
    {
        if(uiGunUpdater != null)
        {
            uiGunUpdater.UpdateValue((float) _currentLife / startLife);
        }
    }

    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCoroutine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;
    }
}
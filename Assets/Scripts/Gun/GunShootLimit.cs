using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;

public class GunShootLimit : StaffBase
{
    public UIGunUpdater uIGunUpdater; // Agora um único GameObject

    public float maxShoot = 5f;
    public float timeToRecharge = 1f;

    private float _currentShoots;
    private bool _recharging = false;

    void Awake()
    {
        GetUIUpdater();
    }

    protected override IEnumerator StartShoot()
    {
        if (_recharging) yield break;
        while (true)
        {
            if (_currentShoots < maxShoot)
            {
                Shoot();
                _currentShoots++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(shootDelay);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_currentShoots >= maxShoot)
        {
            StopShooting();
            Recharge();
        }
    }

    private void Recharge()
    {
        _recharging = true;
        StartCoroutine(RechargeCoroutine());
    }

    IEnumerator RechargeCoroutine()
    {
        Debug.Log("Recharging");
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            if (uIGunUpdater != null) 
                uIGunUpdater.UpdateValue(time / timeToRecharge);
            yield return new WaitForEndOfFrame();
        }
        _currentShoots = 0;
        _recharging = false;
        Debug.Log("Recharged!");
    }

    private void UpdateUI()
    {
        if (uIGunUpdater != null) 
            uIGunUpdater.UpdateValue(maxShoot, _currentShoots);
    }

    private void GetUIUpdater()
    {
        uIGunUpdater = GameObject.FindFirstObjectByType<UIGunUpdater>(); // Agora pega apenas um
    }
}

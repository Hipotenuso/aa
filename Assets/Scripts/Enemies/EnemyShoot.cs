using Enemy;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        public StaffBase staffBase;

        void Awake()
        {
            if (staffBase == null) staffBase = GetComponentInChildren<StaffBase>();
        }

        protected override void Init()
        {
            base.Init();

            staffBase.StartShooting();
        }
    }

}

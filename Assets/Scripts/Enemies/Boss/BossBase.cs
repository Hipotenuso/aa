using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Boss
{
    public abstract class BossBase : MonoBehaviour, IDamageble
    {
        [Header("Boss Stats")]
        public float maxHealth = 30f;
        public float _currentLife;
        public float damage = 10f;
        public float moveSpeed = 3f;
        public float attackRange = 5f; // Adicionando o campo de alcance de ataque
        private int _index = 0;
        public float minDistance = 1f;
        public float delayToDeath = .5f;
        public FlashColor flashColor;
        public UnityEvent OnKillEvent;
        public Collider _collider;
        public healthBase healthBase;
        public List<Transform> waypoints;

        public BossStateMachine stateMachine;

        public virtual void Awake()
        {
            _currentLife = maxHealth;

            stateMachine = new BossStateMachine(this);
            healthBase = healthBase.GetComponent<healthBase>();
        }

        public virtual void Start()
        {
            stateMachine.SetState(new BossIdle(gameObject, this));
        }


        public virtual void Update()
        {
            stateMachine.Update();
        }

        public virtual void Move(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }

        protected virtual void kill()
        {
            OnKill();
        }
        protected virtual void OnKill()
        {
            if(_collider != null) _collider.enabled = false;
            Destroy(gameObject, delayToDeath);
            OnKillEvent?.Invoke();
        }
         
        public void GoToRandomPoint()
        {
            StartCoroutine(GoToPointCoroutine(waypoints[Random.Range(0, waypoints.Count)]));
        }

        IEnumerator GoToPointCoroutine(Transform t)
        {
            if(Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
            {
                _index++;
                if(_index >= waypoints.Count)
                {
                    _index = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * moveSpeed);
            //transform.LookAt(waypoints[_index].transform.position);
            yield return new WaitForEndOfFrame();
        }

        public void OnDamage(float f)
        {
            if(flashColor != null) flashColor.Flash();
            _currentLife -= f;
            if(_currentLife <= 0)
            {
                kill();
            }
        }

        public void Damage(float damage)
        {
            Debug.Log("Boss recived damage");
            OnDamage(damage);
        }

        public void Damage(float damage, Vector3 dir)
        {
            Debug.Log("Boss recived damage");
            OnDamage(damage);
        }

        void OnCollisionEnter(Collision collision)
        {
            PlayerNew p = collision.transform.GetComponent<PlayerNew>();
            if(p != null)
            {
                p.healthBase.Damage(5);
            }
        }
    }
}

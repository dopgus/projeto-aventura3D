using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        public float startLife = 10f;

        [SerializeField] private float _currentLife;

        private void Awake()
        {
            Init();
        }

        protected void Resetlife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            Resetlife();
        }

        protected virtual void Kill()
        {
            OnKill();
        }
        protected virtual void OnKill()
        {
            Destroy(gameObject);
        }

        public void OnDamage(float f)
        {
            _currentLife -= f;

            if(_currentLife <= 0)
            {
                Kill();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }
        }
    }
}

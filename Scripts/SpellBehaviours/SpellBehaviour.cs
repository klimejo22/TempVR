using System;
using UnityEngine;

namespace Game
{
    public class SpellBehaviour : MonoBehaviour
    {
        [SerializeField] private int speed = 5;
        [SerializeField] private int damage;
        public int manaCost;

        protected void MoveForward()
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }
        protected void Start()
        {
            
        }
        protected void Update()
        {
            MoveForward();
        }
        protected virtual void Effect(Enemy enemy)
        {
            enemy.DealDamage(damage);
        }
        protected void OnCollisionEnter(Collision collision)
        {
            Debug.LogError("Spell se dotkl objektu " + collision.gameObject.name);
            GameObject other = collision.gameObject;
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Effect(enemy);
            }
            
            Destroy(gameObject);
        }
    }
}

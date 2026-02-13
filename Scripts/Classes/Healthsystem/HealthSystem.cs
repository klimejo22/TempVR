using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int mana;
    protected int maxHealth;
    protected int maxMana;
    public void DealDamage(int damage)
    {
        health -= damage;
    }
    public void Heal(int hp)
    {
        health += hp;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}

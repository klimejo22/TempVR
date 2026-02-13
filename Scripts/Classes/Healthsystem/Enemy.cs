using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : HealthSystem
{
    [SerializeField] private List<GameObject> itemDrops;

    void Start()
    {
        maxHealth = health;
        maxMana = mana;
        foreach (GameObject item in itemDrops)
        {
            if (item.GetComponent<Item>() == null)
            {
                Debug.LogError($"Item {item.name} nema Item komponentu na sobe");
            }
        }
    }
    void Update()
    {
        DebugDMG();
        if (health <= 0)
        {
            foreach (GameObject item in itemDrops)
            {
                Item itemAttr = item.GetComponent<Item>();
                if (Random.Range(0, 100) <= itemAttr.dropChance)
                {
                    Instantiate(item);    
                }
                
            }

            Destroy(gameObject);
        }
    }
    private void DebugDMG()
    {
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            health = 0;    
        }
    }

}

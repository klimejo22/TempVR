using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Spell
    {
        public string name;
        public string description;
        public int dmg;
        public int manaCost;
        public GameObject projectile;
        public List<Item> craftingRecipe;

        public Spell(string name, string description, int dmg, int manaCost, GameObject projectile)
        {
            this.name = name;
            this.description = description;
            this.dmg = dmg;
            this.manaCost = manaCost;
            this.projectile = projectile;
        }

        public void Use()
        {
            
        }
    }

}

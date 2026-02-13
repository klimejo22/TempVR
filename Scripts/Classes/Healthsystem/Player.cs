using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public List<GameObject> spellList;
    public int points;
    [HideInInspector] public int chosenSpellIndex = 0;
    public int health;
    public int mana;

    public GameObject device;
    private int maxHealth;
    private int maxMana;


    void Awake()
    {
        maxHealth = health;
        maxMana = mana;

        DebugShowDevices();
    }
    private void DebugShowDevices()
    {
        var devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevices(devices);

        Debug.Log("=== DEVICE COUNT: " + devices.Count + " ===");

        foreach (var d in devices)
        {
            Debug.Log("DEVICE -> " + d.name + " (" + d.characteristics + ")");
        }
    }

    

    private void CastSpell()
    {
        
        Debug.Log("Spell je castnut");

    }

    private void OnTriggerPressed(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();

        // Pokud chceš jen "kliknutí" a ne lehké dotyky
        if (value > 0.8f)
        {
            Debug.Log("LEFT TRIGGER PRESSED! Value: " + value);
            CastSpell();
        }
    }
    public GameObject GetCurrentSpell()
    {
        return spellList[chosenSpellIndex];
    }
    public void DecreaseMana(int manaCost)
    {
        mana -= manaCost;
        if (mana < 0)
        {
            mana = 0;
        }
    }
}

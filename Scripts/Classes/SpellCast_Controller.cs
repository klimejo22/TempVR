using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Game
{
    public class SpellCast_Controller : MonoBehaviour
    {
        private Transform rightControllerPosition;
        public GameObject rightController;
        public InputActionReference castSpell;
        void Start()
        {
            rightControllerPosition = rightController.transform;
            castSpell.action.Enable();
            castSpell.action.performed += CastSpell;
            InputSystem.onDeviceChange += OnDeviceChange;
        }

        void CastSpell(InputAction.CallbackContext context)
        {
            Player player = gameObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogError("Obj nema player");
                return;
            }
            GameObject currentSpell = player.GetCurrentSpell();
            SpellBehaviour currentSpellBehaviour = currentSpell.GetComponent<SpellBehaviour>();
            if (currentSpellBehaviour == null)
            {
                Debug.LogError("Spell nema svuj behaviour na sobe");
            }
            if (player.mana == 0)
            {
                return;
            }
            player.DecreaseMana(currentSpellBehaviour.manaCost);
            Instantiate(currentSpell, rightControllerPosition.position, rightControllerPosition.rotation);
        }

        void OnDestroy()
        {
            castSpell.action.Disable();
            castSpell.action.performed -= CastSpell;
            InputSystem.onDeviceChange -= OnDeviceChange;
        }

        void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            if (InputDeviceChange.Disconnected == change)
            {
                castSpell.action.Disable();
                castSpell.action.performed -= CastSpell;
            } else if (InputDeviceChange.Reconnected == change)
            {
                castSpell.action.Enable();
                castSpell.action.performed += CastSpell;
            }
        }

        void Update()
        {
            rightControllerPosition = rightController.transform;
        }
    }
    
}

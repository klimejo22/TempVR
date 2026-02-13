using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Game
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class Item : MonoBehaviour
    {
        public string itemName;
        public byte dropChance;
        [SerializeField] private int pointCount;

        private XRGrabInteractable xRGrabInteractable;
        [SerializeField] private Player player;

        void Awake()
        {
            xRGrabInteractable = GetComponent<XRGrabInteractable>();
            xRGrabInteractable.selectEntered.AddListener(OnGrab);

            if (player == null)
            {
                throw new ArgumentNullException("Na playerObj neni script player");
            }
        }

        private void OnGrab(SelectEnterEventArgs args)
        {
            player.points += pointCount;
            Destroy(gameObject);
        }
    }
    
}

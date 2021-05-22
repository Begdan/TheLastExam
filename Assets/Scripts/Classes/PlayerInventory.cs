using Assets.Scripts.Enums;
using System.Collections.Generic;

namespace Assets.Scripts.Classes
{
    public class PlayerInventory
    {
        public PlayerInventory()
        {
            Keys = new List<Key>();
        }

        public int Batteries { get; set; }

        public float? FlashLight { get; set; }

        public List<Key> Keys { get; set; }

        public void AddItem(ItemController item)
        {
            switch (item.itemType)
            {
                case ItemType.Battery:
                    Batteries++;
                    break;

                case ItemType.FlashLight:
                    if (FlashLight == null)
                        FlashLight = Constants.flashlightCharge;
                    break;

                case ItemType.Key:
                    Keys.Add(new Key(item.RoomNumberKey, item.KeyLabel));
                    break;
            }
        }
    }
}
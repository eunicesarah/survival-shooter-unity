using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare
{
    [CreateAssetMenu(fileName = "shopMenu", menuName="scriptable object/New shop Item", order = 1)]
    public class ShopItemSo : ScriptableObject
    {
        public string title;  
        public string description;
        public int price;
    }

}

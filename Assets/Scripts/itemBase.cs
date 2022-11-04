using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Create new item")]
public class itemBase : ScriptableObject
{

    [SerializeField] public bool active = true;
    [SerializeField] public string item_name;

    [TextArea]
    [SerializeField] public string description;

    [SerializeField] int attack_mod;
    [SerializeField] int shop_price;

    [SerializeField] public Sprite icon;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Class : MonoBehaviour
{

    private string name1 = "";
    private int health;
    private Weapons[] equipped = new Weapons[2];

    public void setName(string newName) {  name1 = newName; }
    
    public void setHealth(int newHealth) { health = newHealth; }

    public int getHealth() { return health; }

    public string getName() { return name1; }

    public void setWeapons(int slot, Weapons weapon) { equipped[slot] = weapon; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    
    int dmg;
    string unitName;

    public void setName(string name) {  this.unitName = name; }

    public void setDamage(int damage) { dmg  = damage; }

    public string getName() { return this.unitName;}

    public int getDamage() { return dmg;}

}

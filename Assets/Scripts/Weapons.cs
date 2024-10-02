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

    //Set Weapons

    public void setWarlockPunch()
    {
        dmg = 25;
        name = "Warlock Punch";
    }

    public void setSpikedWand()
    {
        dmg = 20;
        name = "Spiked Wand";
    }

    public void setFireBall()
    {
        dmg = 15;
        name = "Fire Ball";
    }

    public void setAcidicStream()
    {
        dmg = 16;
        name = "Acidic Stream";
    }

    public void setWizardGale()
    {
        dmg = 10;
        name = "Wizard Gale";
    }

    public void setZap()
    {
        dmg = 10;
        name = "Zap";
    }

    //Special Potions

    public void setSpecialPotion(int potion, string name)
    {

        dmg = potion;
        this.name = name;
    }
}

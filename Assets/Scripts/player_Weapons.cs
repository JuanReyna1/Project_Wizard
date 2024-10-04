using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Weapons : Weapons
{

    public static player_Weapons instance;

    private static int blockChance = -1;
    private static string special_Potion = "";
    private static int dmgBonus = 1;
    private static int burnChance = 0;
    private static Weapons[] player_Arsenal = { new Weapons(), new Weapons(), new Weapons() };

    private void Awake()
    {
        
        if (instance != null)
        {

            Destroy(this);
            return;

        }

        instance = this;
        DontDestroyOnLoad(instance);
        
    }
    
    public void setWeapon(int slot, int newDmg, string nameIn) 
    { 
        
        player_Arsenal[slot].setName(nameIn);
        player_Arsenal[slot].setDamage(newDmg);
    
    }

    public void setBlockChance(int newChance)
    {

        blockChance = newChance;

    }

    public void setSpPotion(string newPotion)
    {

        special_Potion = newPotion;

    }

    public void setDmgBonus(int bonus)
    {

        dmgBonus = bonus;

    }

    public void setBurnChance(int bonus)
    {
        burnChance = bonus;
    }

    public Weapons getWeapon(int slot) { return player_Arsenal[slot]; }

    public int getBlockChance() { return blockChance; }

    public string getSpPotion() { return special_Potion; }

    public int getDmgBonus() {  return dmgBonus; }

    public int getBurnChance() {  return burnChance; }

}

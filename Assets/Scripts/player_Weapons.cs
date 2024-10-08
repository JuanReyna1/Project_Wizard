using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Weapons : Weapons
{

    public static player_Weapons instance;

    private static Weapons[] player_Arsenal = { new Weapons(), new Weapons() };

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

    public Weapons getWeapon(int slot) { return player_Arsenal[slot]; }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Class : MonoBehaviour
{

    private string name1 = "";
    private int health;
    private int burn;
    private int stuned;
    private Weapons[] enemyArsenal = { new Weapons(), new Weapons() };

    //Setters
    public void setName(string newName) {  name1 = newName; }
    
    public void setHealth(int newHealth) { health = newHealth; }

    public void setWeapon(int slot, int damage, string nameW)
    {

        //enemyArsenal[slot] = new Weapons();
        enemyArsenal[slot].setDamage(damage);
        enemyArsenal[slot].setName(nameW);

    }

    public void setWeapons(Weapons[] arsenal) {  enemyArsenal = arsenal; }

    //Getters
    public int getHealth() { return health; }

    public string getName() { return name1; }

    public Weapons getWeapons(int slot) {  return enemyArsenal[slot]; }

    //Operations
    public void takeDmg(int damage) { health -= damage; }

    public void heal() { health += 25; }
}

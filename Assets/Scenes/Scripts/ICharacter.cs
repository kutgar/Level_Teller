using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICharacter
// Interface of Character
{
    // Calculates The Helth of a Character
    void Health();
    // Calculates The Armor of a Character
    void Armor();
    // Move Fuanction
    void Move(Vector2 dirToLook, Vector2 dir, Vector2 startposition);
    // Attack Fuanction
    void Strength();
    // IsAlive Fuanction returns true/false
    void Speed();

    bool IsAlive();


}


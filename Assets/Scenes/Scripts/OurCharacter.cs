using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor4D.Common.CharacterScripts;

public class OurCharacter : MonoBehaviour, ICharacter
{
    const int BASE_HEALTH = 100;
    const float BASE_ARMOR = 0, BASEDAMAGE = 1;

    private List<int> items;// List<int> items conatains a id of Iteams the player have
    private float baseHealth, baseArmor, baseStrength, baseSpeed;
    private float currentHealth, currentArmor, currentStrength, currentSpeed;
    private bool isAlive;
    private Rigidbody2D rb2d;
    private Character4D Character4DContreoler;
    private CharacterAnimation CharacterAnimationContreoler;

    public OurCharacter() { }

    /// <summary>
    /// Constractor
    /// </summary>
    /// <param name="rb2d">rigibody 2d of the charecter</param>
    public OurCharacter(Rigidbody2D rb2d, Character4D script4D, CharacterAnimation scriptAnimation)
    {
        this.items = new List<int>();
        this.baseHealth = BASE_HEALTH;
        Health();
        this.baseArmor = BASE_ARMOR;
        Armor();
        this.baseStrength = BASEDAMAGE;
        Strength();
        this.baseSpeed = 3;
        Speed();

        this.Character4DContreoler = script4D;
        this.CharacterAnimationContreoler = scriptAnimation;
        this.isAlive = true;
        this.rb2d = rb2d;
    }


    /// <summary>
    /// Calculates The Helth of a Character
    /// </summary>
    /// <returns></returns>
    public void Health()
    {
        float health = 0;
        if (this.items.Count == 0)
        {
            this.currentHealth = this.baseHealth;
        }
        else
        {
            // code the runs on the database TO DO
            //.
            //.
            //.
        }
    }

    /// <summary>
    /// Calculates The Armor of a Character
    /// </summary>
    /// <returns></returns>
    public void Armor()
    {
        float armor = 0;
        if (this.items.Count == 0)
        {
            this.currentArmor = this.baseArmor;
        }
        else
        {
            // code the runs on the database TO DO
            //.
            //.
            //.
        }
    }

    /// <summary>
    /// Calculates The Damage of a Character
    /// </summary>
    public void Strength()
    {
        float strength = 0;
        if (this.items.Count == 0)
        {
             this.currentStrength = this.baseStrength;
        }
        else
        {
            // code the runs on the database
            //.
            //.
            //.
        }
    }

    public void Speed()
    {
        float speed = 0;
        if (this.items.Count == 0)
        {
            this.currentSpeed = this.baseSpeed;
        }
        else
        {
            // code the runs on the database
            //.
            //.
            //.
        }
    }

    /// <summary>
    /// Is the charecter alive?
    /// </summary>
    /// <returns></returns>
    public bool IsAlive()
    {
        if (this.currentHealth < 0)
        {
            this.isAlive = false;
        }
        return this.isAlive;
    }

    /// <summary>
    /// Move the charecter
    /// </summary>
    /// <param name="dir">direction for player to move [{-1,0,1},{-1,0,1}]</param>
    /// <param name="startposition">(Vector2)transform.position</param>
    /// /// <param name="dirToLook">direction for player to look</param>
    public void Move(Vector2 dirToLook, Vector2 dir, Vector2 startposition)
    {
        if (dir != Vector2.zero)
        {
            this.rb2d.MovePosition(startposition + (dir * this.currentSpeed * Time.deltaTime));
            CharacterAnimationContreoler.SetState(CharacterState.Walk); // walk
        }
        else
        {
            CharacterAnimationContreoler.SetState(CharacterState.Idle); // Idle
        }
        if (dirToLook != Vector2.zero)// if dir is [1,-1]
        {
            // i want left and right to be dominante
            Character4DContreoler.SetDirection(dirToLook);
        }
    }

    public void Attack()
    {
        CharacterAnimationContreoler.Attack();
    }








    #region get set 
    public List<int> Iteams   // property
    {
        get { return items; }   
        set { items = value; }  
    }
    public float BaseHealth   // property
    {
        get { return baseHealth; }   
        set
        {
            baseHealth = value;
            Health();
        }
    }
    public float BaseArmor   // property
    {
        get { return baseArmor; }   
        set
        {
            baseArmor = value;
            Armor();
        }
    }
    public float BaseStrength  // property
    {
        get { return baseStrength; }   
        set
        {
            baseStrength = value;
            Strength();
        }
    }
    public float BaseSpeed   // property
    {
        get { return baseSpeed; }   
        set
        {
            baseSpeed = value;
            Speed();
        }  
    }
    #endregion

}

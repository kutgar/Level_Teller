using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor4D.Common.CharacterScripts;


public class OurPlayer : OurCharacter
{
    //public float speed = 3;
    private Rigidbody2D rb2d;
    private Character4D Character4DContreoler;
    private CharacterAnimation CharacterAnimationContreoler;
    //private Vector2 movment;

    // Start is called before the first frame update
    //void Start()
    //{
    //    this.rb2d = GetComponent<Rigidbody2D>();
    //    this.Character4DContreoler = GetComponent<Character4D>();
    //    this.CharacterAnimationContreoler = GetComponent<CharacterAnimation>();
    //}

    public OurPlayer(Rigidbody2D rb2d, Character4D script4D, CharacterAnimation scriptAnimation): base(rb2d,script4D,scriptAnimation)
    {
        
    }


    //// Update is called once per frame
    //void Update()
    //{
    //    movment = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    //}
    //private void FixedUpdate()
    //{
    //    moveCharecter(movment);
    //}
    //void moveCharecter(Vector2 direction)
    //{
    //    //rb2d.AddForce(direction * speed);
    //    rb2d.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    //}
}

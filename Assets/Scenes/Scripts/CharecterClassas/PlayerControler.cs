using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor4D.Common.CharacterScripts;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Character4D Character4DContreoler;
    private CharacterAnimation CharacterAnimationContreoler;

    private Vector2 dir;// to go
    private Vector2 dirToLook;// to Lookatt
    private OurPlayer player;


    // Start is called before the first frame update
    void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.Character4DContreoler = GetComponent<Character4D>();
        this.CharacterAnimationContreoler = GetComponent<CharacterAnimation>();
        CreatePlayer();
        CharacterAnimationContreoler.SetState(CharacterState.Idle);
        this.dirToLook = Vector2.up;
    }

    void Update()
    {
        Controls();
        //movment = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        player.Move(dirToLook,dir,(Vector2)transform.position);
    }




    void CreatePlayer()
    {
         player = new OurPlayer(rb2d, Character4DContreoler, CharacterAnimationContreoler);
    }

    void Controls(float x = 0, float y = 0)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1;
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }
        this.dirToLook = new Vector2(x, y);
        x = 0;
        y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        this.dir = new Vector2(x, y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Attack();
        }
    }
}

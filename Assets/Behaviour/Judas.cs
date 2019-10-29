using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judas : MonoBehaviour
{

    public static Judas me; 
    public Camera cam;

    public bool isActive;
    public Rigidbody2D rb;

    public Vector2 StartPos;
    public Vector2 pos;
    public Vector2 vel;
    public float speed;

    public Vector2 mousePos;

    public Vector2 checkPos;
    public Vector2 target;

    public int PP;
    public int BB;
    public int RW;
    public int HS;
    public int SP;

    public GameObject PPstore;
    public GameObject BBstore;
    public GameObject HSstore;
    public GameObject RWstore;
    public GameObject SPstore;

    public CandyStorage PPCS;
    public CandyStorage BBCS;
    public CandyStorage HSCS;
    public CandyStorage RWCS;
    public CandyStorage SPCS;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    void Awake()
    {
        me = this;
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        Vector2MyPos();
        StartPos = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.me.GameOn == true)
        {
            Inputs();
            Vector2MyPos();
            GetCandyObj();
        }
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetVel();
        }

        if(Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }
    }

    void FixedUpdate()
    {
        Movement();
        //CheckTarget();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "PPobj")
        {
            Destroy(col.gameObject);
            PP++;
            GameManager.me.candyTaken++;
        }
        if (col.gameObject.tag == "BBobj")
        {
            Destroy(col.gameObject);
            BB++;
            GameManager.me.candyTaken++;
        }
        if (col.gameObject.tag == "RWobj")
        {
            Destroy(col.gameObject);
            RW++;
            GameManager.me.candyTaken++;
        }
        if (col.gameObject.tag == "HSobj")
        {
            Destroy(col.gameObject);
            HS++;
            GameManager.me.candyTaken++;
        }
        if (col.gameObject.tag == "SPobj")
        {
            Destroy(col.gameObject);
            SP++;
            GameManager.me.candyTaken++;
        }

        if (col.gameObject.tag == "PPstore" && PP > 0)
        {
            PPCS.Amount += PP;
            PP = 0;
        }
        if (col.gameObject.tag == "BBstore" && BB > 0)
        {
            BBCS.Amount += BB;
            BB = 0;
        }
        if (col.gameObject.tag == "RWstore" && RW > 0)
        {
            RWCS.Amount += RW;
            RW = 0;
        }
        if (col.gameObject.tag == "HSstore" && HS > 0)
        {
            HSCS.Amount += HS;
            HS = 0;
        }
        if (col.gameObject.tag == "SPstore" && SP > 0)
        {
            SPCS.Amount += SP;
            SP = 0;
        }
    }

    void SetVel()
    {
        Vector2MyMouse();
        target = mousePos;
        vel = target - pos;
        vel.Normalize();
    }

    void Movement()
    {
        //pos = pos + (vel / 10);
        rb.MovePosition(pos + vel);
    }

    void CheckTarget()
    {
        if((vel.x > 0 && pos.x > target.x) || (vel.x < 0 && pos.x < target.x) || (vel.y > 0 && pos.y > target.y) || (vel.y < 0 && pos.y < target.y))
        {
            vel = Vector2.zero;
        }
    }

    public void GetCandyObj()
    {
        PPstore = GameObject.Find("PitPats");
        PPCS = PPstore.GetComponent<CandyStorage>();
        BBstore = GameObject.Find("Booster Bars");
        BBCS = BBstore.GetComponent<CandyStorage>();
        RWstore = GameObject.Find("Red and Whites");
        RWCS = RWstore.GetComponent<CandyStorage>();
        HSstore = GameObject.Find("Her-She's");
        HSCS = HSstore.GetComponent<CandyStorage>();
        SPstore = GameObject.Find("SmallPleasers");
        SPCS = SPstore.GetComponent<CandyStorage>();
    }

    public void Vector2MyPos()
    {
        pos = new Vector2(transform.position.x, transform.position.y);
    }

    public void Vector2MyMouse()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    public float To1DP(float i)
    {
        float j = (Mathf.Round(i * 10) / 10);
        return j;
    }
}

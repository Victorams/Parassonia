using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour

{

    private GameObject player;

    [SerializeField] private bool isOpen;
    [SerializeField] private bool isLocked;
    [SerializeField] private GameObject key;
    [SerializeField] private bool isStuck;


    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player");

        if (isDoorStuck())
        {
            close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isDoorOpen()
    {
        return this.isOpen;
    }

    public bool isDoorLocked()
    {
        return this.isLocked;
    }

    public bool isDoorStuck()
    {
        return this.isStuck;
    }

    public void open()
    {
        if (!isDoorStuck())
        {
            if (!isDoorLocked())
            {
                this.isOpen = true;
                print("Porta aberta!");
            }
            else
            {
                print("Porta trancada!");
            }
        }
        else
        {
            print("Porta emperrada!");
        }
        
    }

    public void close()
    {
        this.isOpen = false;
        print("Porta fechada!");
    }

    public void Lock(){
        this.isLocked = true;
    }

    public void unlock()
    {
        this.isLocked = false;
        print("Porta destrancada!");
    }

    void jam()
    {
        this.isStuck = true;
    }

    public void fix()
    {
        this.isStuck = false;
    }
}

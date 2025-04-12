using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Weapon currentlyEquipped;
    private int index = 0;
    public List<Weapon> allWeapons = new List<Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        currentlyEquipped = allWeapons[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentlyEquipped.Attack();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            index++;

            if(index >= allWeapons.Count)
            {
                index = 0;
            }

            currentlyEquipped = allWeapons[index];
        }
    }
}

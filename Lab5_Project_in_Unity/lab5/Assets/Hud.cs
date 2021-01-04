using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
	public int hp, stamina;
	public Slider Hp, Stamina;

    void Start()
    {
        
    }


    void Update()
    {
        Hp.value = hp;
        Stamina.value = stamina;
    }
}

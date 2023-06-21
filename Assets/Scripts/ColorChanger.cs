using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour, IInteractable
{

    Material mat;
    public AudioClip shopkeeper;
    public AudioSource sfxPlayer; 

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public string GetDescription()
    {
        return "Interact with Player";
    }


    public void Interact()
    {
        sfxPlayer.Play(); 
        mat.color = new Color(Random.value, Random.value, Random.value);
    }
    
}
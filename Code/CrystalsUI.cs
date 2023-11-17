using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalsUI : MonoBehaviour
{
    public Text crystalsText;
 
    private void Update()
    {
        crystalsText.text = Corn.singleton.crystals.ToString("0000");
    }
}

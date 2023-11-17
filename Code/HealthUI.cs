using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        healthText.text = Corn.singleton.health.ToString();
    }
}

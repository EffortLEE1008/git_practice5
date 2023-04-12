using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    enum InfoType { Kill, Time, Health};
    
    [SerializeField]
    InfoType type;

    Text my_Text;

    Slider my_Slider;
    Player player;

    private void Awake()
    {
        my_Text = GetComponent<Text>();
        my_Slider = GetComponent<Slider>();

    }


    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Kill:

                break;

            case InfoType.Health:
             


                break;

            case InfoType.Time:

                break;
        }
    }

}

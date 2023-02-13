using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phealth : MonoBehaviour
{
    public Slider slider;

    private void Update()
    {
        slider.value = playermovement.Instance.playerhealth;
    }
}

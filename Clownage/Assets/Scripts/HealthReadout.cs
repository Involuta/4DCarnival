using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthReadout : MonoBehaviour
{
    public HealthInformation health;

    private Text readout;

    // Start is called before the first frame update
    void Start()
    {
        readout = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        readout.text = health.Health.ToString();
    }
}

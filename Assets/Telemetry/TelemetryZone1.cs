using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryZone1 : MonoBehaviour
{
    public string sectionName;

    private void OnTriggerEnter2D(Collider2D Collider2D) {
        if (Collider2D.TryGetComponent<PlayerControllerCurrent>(out var controller))
        {
            var logger = GameObject.FindObjectOfType<TelemetryLogger>();
        }
        //logger.ChangeSection(sectionName);
            TelemetryLogger.GetLogger(this).ChangeSection(sectionName);
    }

}

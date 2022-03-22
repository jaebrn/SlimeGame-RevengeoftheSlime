using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetrySection : MonoBehaviour
{

    public string sectionName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerControllerCurrent>(out var controller))
        {
            var logger = GameObject.FindObjectOfType<TelemetryLogger>();

            logger.ChangeSection(sectionName);

        }

    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StopsButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CarController car;
    public LampuMobil lampurem;

    public void OnPointerDown(PointerEventData pd)
    {
        car.REM(true);
        lampurem.ngerem(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        car.REM(false);
        lampurem.ngerem(false);
        // Start is called before the first frame update
    }
}

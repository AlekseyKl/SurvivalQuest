using UnityEngine;

public class ClickEvent : MonoBehaviour {

    void OnMouseDown()
    {
        EventsManager.eventFromConfigOccure(this.name, getTypeEvent());
    }

    public string getTypeEvent()
    {
        return EventsManager.PRESS;
    }
}

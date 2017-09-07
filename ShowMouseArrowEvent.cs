using UnityEngine;

public class ShowMouseArrowEvent : MonoBehaviour {

    void OnMouseEnter()
    {
        EventsManager.cursorEvent(this.name, EventsManager.ON_MOUSE_ENTER);
    }

    void OnMouseExit()
    {
        EventsManager.cursorEvent(this.name, EventsManager.ON_MOUSE_EXIT);
    }

}

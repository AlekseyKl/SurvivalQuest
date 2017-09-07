using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class EventsManager : MonoBehaviour
{

    public const string PRESS = "press";
    public const string SHOW = "show";
    public const string HIDE = "hide";
    public const string ON_MOUSE_ENTER = "on_mouse_enter";
    public const string ON_MOUSE_EXIT = "on_mouse_exit";
    public const string FUNCTION = "function";
    public const string FINISH_SCENE = "finish_scene";

    public const string IS_VISIBLE = "is_visible";

    static JSONObject config = null;

    static bool isInit = false;

    static GameObject sceneObect = null;
    static CustomCursor cursor = null;

    private static void init()
    {
        if (isInit) { return; }
        config = Scene.loadConfig();

        sceneObect = GameObject.Find("Scene");
        cursor = sceneObect.GetComponent("CustomCursor") as CustomCursor;

        isInit = true;
    }

    private static void runAction(string targetObjectName, string nameActionTargetObject, string nameSourceObject)
    {
        GameObject targetGameObject = GameObject.Find(targetObjectName);

        // GameObject.Find(targetObjectInfo["name"].str);
        switch (nameActionTargetObject)
        {
            case PRESS:
                //Debug.Log("event: '" + nameEvent + "'");
                break;
            case HIDE:
                if (targetGameObject != null)
                {
                    targetGameObject.GetComponent<Renderer>().enabled = false;
                }
                //eventObject.SetActive(false);
                break;
            case SHOW:
                if (targetGameObject != null)
                {
                    targetGameObject.GetComponent<Renderer>().enabled = true;
                }
                break;
            case FUNCTION:

                // targetObjectName
                MethodInfo theMethod = sceneObect.GetComponent("Scene").GetType().GetMethod("calculateSceneAndFinished");
                theMethod.Invoke(sceneObect.GetComponent("Scene"), null);

                break;
            case FINISH_SCENE:
                break;
            default:
                Debug.Log("error: not define event from config");
                break;
        }
    }

    public static void eventFromConfigOccure(string nameSourceObject, string nameEventSourceObject)
    {
        init();

        if (!isInit)
        {
            return;
        }

        foreach (JSONObject targetObjectInfo in config["actions"][nameEventSourceObject][nameSourceObject].list)
        {
            string targetObjectName = targetObjectInfo["name"].str;
            string targetAction = targetObjectInfo["action"].str;

            runAction(targetObjectName, targetAction, nameSourceObject);
        }

        /*
        // Find object and event
        GameObject eventObject = null;
        if (config["actions"][nameEventSourceObject][nameSourceObject]["name"])
        {
            eventObject = GameObject.Find(config["actions"][nameEventSourceObject][nameSourceObject]["name"].str);
        }

        string nameEventTargetObject = "";
        if (config["actions"][nameEventSourceObject][nameSourceObject]["action"])
        {
            nameEventTargetObject = config["actions"][nameEventSourceObject][nameSourceObject]["action"].str;
        }

        switch (nameEventTargetObject)
        {
            case PRESS:
                //Debug.Log("event: '" + nameEvent + "'");
                break;
            case HIDE:
                if (eventObject != null)
                {
                    eventObject.GetComponent<Renderer>().enabled = false;
                }
                //eventObject.SetActive(false);
                break;
            case SHOW:
                if (eventObject != null)
                {
                    eventObject.GetComponent<Renderer>().enabled = true;
                }
                break;
            case FUNCTION:
                string nameFunction = "";
                if (config["actions"][nameEventSourceObject][nameSourceObject]["name"])
                {
                    nameFunction = config["actions"][nameEventSourceObject][nameSourceObject]["name"].str;
                }

                //Type thisType = sceneObect.GetComponent("Scene").GetType();
                MethodInfo theMethod = sceneObect.GetComponent("Scene").GetType().GetMethod("calculateSceneAndFinished");
                theMethod.Invoke(sceneObect.GetComponent("Scene"), null);

                break;
            case FINISH_SCENE:
                break;
            default:
                Debug.Log("error: not define event from config");
                break;
        }
        */
    }

    public static void cursorEvent(string nameSourceObject, string nameEventSourceObject)
    {
        init();

        if (!isInit)
        {
            return;
        }

        switch (nameEventSourceObject)
        {
            case ON_MOUSE_ENTER:
                if (config["mouse_cursor"][nameSourceObject])
                {
                    cursor.showCursor(config["mouse_cursor"][nameSourceObject].str);
                }
                break;
            case ON_MOUSE_EXIT:
                cursor.hideCursor();
                break;
            default:
                Debug.Log("error: not define event");
                break;
        }
    }
}
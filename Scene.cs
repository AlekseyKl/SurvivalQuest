using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scene : MonoBehaviour {

    //static string config = "";
    JSONObject configJSON = null;

    void Start () {
        Debug.Log("start v.0.0.2");

        configJSON = loadConfig();

        // http://wiki.unity3d.com/index.php?title=JSONObject
        // config["hideObjectInStartScene"].list.Count
        foreach (JSONObject nameObject in configJSON["hideObjectInStartScene"].list)
        {
            GameObject objectForHide = GameObject.Find(nameObject.str);
            //objectForHide.SetActive(false);
            objectForHide.GetComponent<Renderer>().enabled = false;
        }

    }
    
    public static JSONObject loadConfig()
    {
        
        string configString = "" +
            "{" +
                "\"hideObjectInStartScene\":" +
                    "[" +
                        "\"arrow\"," +
                        "\"arrow_question\"," +
                        "\"scene_5_rock_place_1\"," +
                        "\"scene_5_rock_place_2\"," +
                    "]," +
                "\"actions\":" +
                    "{" +
                        "\"press\":" +
                            "{" +
                                "\"scene_5_rock_right_1\":" +
                                    "[" +
                                        "{\"name\":\"scene_5_rock_place_1\", \"action\":\"" + EventsManager.SHOW + "\"}," +
                                        "{\"name\":\"scene_5_rock_right_1\", \"action\":\"" + EventsManager.HIDE + "\"}" +
                                    "]," +
                                "\"scene_5_rock_right_2\":" +
                                    "[" +
                                        "{\"name\":\"scene_5_rock_place_2\", \"action\":\"" + EventsManager.SHOW + "\"}," +
                                        "{\"name\":\"scene_5_rock_right_2\", \"action\":\"" + EventsManager.HIDE + "\"}" +
                                    "]," +
                                "\"scene_5_puddle_active_area\":" +
                                    "[" +
                                        "{\"name\":\"calculateSceneAndFinished\", \"action\":\"" + EventsManager.FUNCTION + "\"}" +
                                    "]" +
                            "}," +
                    "}," +
                "\"mouse_cursor\":" +
                    "{" +
                        "\"scene_5_rock_right_1\":\"" + CustomCursor.CURSOR_ARROW + "\", " +
                        "\"scene_5_rock_right_2\":\"" + CustomCursor.CURSOR_ARROW + "\", " +
                        "\"scene_5_puddle_active_area\":\"" + CustomCursor.CURSOR_ARROW + "\", " +
                        "\"scene_5_rock_place_1\":\"" + CustomCursor.CURSOR_ARROW_QUESTION + "\", " +
                        "\"scene_5_rock_place_2\":\"" + CustomCursor.CURSOR_ARROW_QUESTION + "\", " +
                    "}," +
                "\"scene_product\":" +
                    "\"" + SceneProductType.EAT + "\"," +
                "\"scene_product_values\":" +
                    "[" +
                        "{\"name\":\"scene_5_rock_place_1\", \"condition\":\"" + EventsManager.IS_VISIBLE + "\", \"value\":\"1\"}, " +
                        "{\"name\":\"scene_5_rock_place_2\", \"condition\":\"" + EventsManager.IS_VISIBLE + "\", \"value\":\"1\"}, " +
                    "]," +
                "\"finished_popups\":" +
                    "[" +
                        "{\"name\":\"popup_1\", \"valueLess\":\"2\"}, " +
                        "{\"name\":\"popup_2\", \"valueLess\":\"2\"}, " +
                    "]," +
            "}";


        return new JSONObject(configString);
    }

    public void calculateSceneAndFinished()
    {
        Debug.Log("func: calculateSceneAndFinished INSIDE v.01");

        float values = 0.0F;

        foreach (JSONObject objJSON in configJSON["scene_product_values"].list)
        {
            GameObject obj = GameObject.Find(objJSON["name"].str);
            //objectForHide.SetActive(false);
            if (obj.GetComponent<Renderer>().enabled)
            {
                Debug.Log("func: calculateSceneAndFinished INSIDE v.02");
            }
        }

    }

    void Update () {
		
	}
}

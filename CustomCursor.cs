using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour {

    public const string CURSOR_ARROW = "cursor_arrow";
    public const string CURSOR_ARROW_QUESTION = "cursor_arrow_question";

    private Texture2D arrowTexture = null;
    private Texture2D arrowWithQuestionTexture = null;

    private bool isInit = false;

    public void showCursor(string cursorType)
    {
        init();

        Texture2D selectedTexture = null;
        Vector2 hotSpot = new Vector2(0, 0);

        switch (cursorType)
        {
            case CURSOR_ARROW:
                selectedTexture = arrowTexture;
                hotSpot = new Vector2((selectedTexture.width * (-1 / 3)), selectedTexture.height);
                break;
            case CURSOR_ARROW_QUESTION:
                selectedTexture = arrowWithQuestionTexture;
                hotSpot = new Vector2((selectedTexture.width * (-1 / 2)), selectedTexture.height);
                break;
            default:
                selectedTexture = arrowTexture;
                break;
        }

        if (selectedTexture != null)
        {
            //selectedTexture = Resources.Load("arrow") as Texture2D;
            //Vector2 hotSpot = new Vector2((selectedTexture.width * (-1/3)), selectedTexture.height);
            Cursor.SetCursor(selectedTexture, hotSpot, CursorMode.Auto);
        }


    }

    public void hideCursor()
    {
        init();
        Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
    }

    private void init()
    {
        if (isInit)
        {
            return;
        }

        arrowTexture = Resources.Load("arrow") as Texture2D;
        arrowWithQuestionTexture = Resources.Load("arrow_question") as Texture2D;

        isInit = true;

    }

	void Start () {

    }
}

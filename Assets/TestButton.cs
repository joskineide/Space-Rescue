using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour {

    public SpriteRenderer spriteManager;
    public Sprite idle;
    public Sprite activated;
    public int id;
    public bool isSelecting;

    private void Start()
    {
        spriteManager = GetComponent<SpriteRenderer>();        
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            isSelecting = true;
            if (activated != null)
                spriteManager.sprite = activated;
        }
        else if (isSelecting)
        {
            switch (id)
            {
                case 0:
                    SceneManager.LoadScene(1);
                    break;
                case 1:
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    Application.Quit();
                    break;
                case 3:
                    SceneManager.LoadScene(3);
                    break;

            }
        }

    }
    private void OnMouseExit()
    {
        if (isSelecting)
        {
            if (idle != null)
                spriteManager.sprite = idle;
            isSelecting = false;
        }
    }
}

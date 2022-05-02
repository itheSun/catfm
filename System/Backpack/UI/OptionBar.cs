using CatFM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionBar : MonoBehaviour
{
    [SerializeField]
    private Sprite background;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private List<IOption> options = new List<IOption>();

    private List<Button> buttons = new List<Button>();

    private void Awake()
    {
        content = transform.Find("ViewPort/Content");
        for (int i = 0; i < options.Count; i++)
        {
            GameObject go = GameObject.Instantiate(item);
            go.transform.SetParent(content);
            go.GetComponent<Image>().sprite = options[i].sprite;
            go.GetComponentInChildren<Text>().text = options[i].name;
            Button button = go.GetComponent<Button>();
            button.onClick.AddListener(() => { OnSelected(button); });
        }
    }

    private void OnSelected(Button button)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] == button)
            {
                Debug.Log(i);
            }
        }
    }
}

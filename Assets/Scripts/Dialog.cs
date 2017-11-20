using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private Sprite playerAvatar;

    [SerializeField]
    private Sprite helicopterAvatar;
    
    private Image window;
    private Image avatar;
    private Text text;
    // Use this for initialization
    void Start()
    {
        window = GetComponent<Image>();
        avatar = GameObject.Find("Avatar").GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }
    
    public void ShowDialog(Character character, string message, float length)
    {
        window.enabled = true;
        
        avatar.sprite = character == Character.PLAYER ? playerAvatar : helicopterAvatar;
        avatar.enabled = true;
        
        text.text = message;
        text.enabled = true;        
        
        Invoke("HideDialog", length);
    }

    private void HideDialog()
    {
        avatar.enabled = false;
        text.enabled = false;
        window.enabled = false;
    }
    
    public enum Character
    {
        PLAYER,
        PILOT
    }
}
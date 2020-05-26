using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChatManager : Singleton<ChatManager>
{
    [SerializeField] Text       instance;
    [SerializeField] InputField inputField;
    [SerializeField] ScrollView scrollView;

    void Start()
    {
        //scrollView.SetEnabled(false);
    }

    void Update()
    {
        switch( UIManager.Instance.CurrentState )
        {
            case UIState.Play:
            {
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    inputField.Select();

                    UIManager.Instance.CurrentState = UIState.Chat;
                }

                break;
            }
            case UIState.Chat:
            {
                if (Input.GetKeyDown(KeyCode.Return) && inputField.text != string.Empty)
                {
                    Debug.Log(inputField.text);

                    inputField.text = string.Empty;

                    UIManager.Instance.CurrentState = UIState.Play;
                }
                break;
            }
        }
    }
}

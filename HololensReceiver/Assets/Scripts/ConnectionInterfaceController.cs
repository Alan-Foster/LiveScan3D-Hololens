using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConnectionInterfaceController : MonoBehaviour
{

    public Text ipAddress;
    public PointCloudReceiver pointCloudReceiver;

    public void Connect(string ip)
    {
        StartCoroutine(ConnectHelper(ip));
    }

    public IEnumerator ConnectHelper(string ip)
    {
        yield return new WaitForSeconds(1);
        pointCloudReceiver.Connect(ip);
    }


    public void InputString(string input)
    {

        if (ipAddress.text.Contains("Connected") || ipAddress.text.Contains("127.0.0.1"))
        {
            ipAddress.text = string.Empty;
        }
        ipAddress.text += input;

    }

    public void DeleteLastCharacter()
    {

        if (!string.IsNullOrEmpty(ipAddress.text))
        {
            ipAddress.text = ipAddress.text.Substring(0, ipAddress.text.Length - 1);
        }
    }

    public void ClearIpAddressString()
    {
        ipAddress.text = "";
    }

    public void MenuButtonReceiver(string name)
    {
        if(name == "Connect")
        {
            Connect(ipAddress.text);
        }
        else if(name == "Delete")
        {
            DeleteLastCharacter();
        }
        else if(name == "Clear")
        {
            ClearIpAddressString();
        }
    }
}

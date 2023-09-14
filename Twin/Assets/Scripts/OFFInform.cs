using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OFFInform : MonoBehaviour
{
    [SerializeField] private GameObject TopMenu1;
    [SerializeField] private GameObject TopMenu2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TopMenu1.activeSelf == false)
            {
                TopMenu1.SetActive(true);
                TopMenu2.SetActive(true);
            }
            else
            {
                TopMenu1.SetActive(false);
                TopMenu2.SetActive(false);
            }
        }
    }

  
}

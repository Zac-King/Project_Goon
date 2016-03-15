using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUI : MonoBehaviour
{
    private static GUI _instance;
    public static GUI instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GUI>();
            return _instance;
        }
    }
    [SerializeField]
    private GameObject AttackButton;
    [SerializeField]
    private GameObject Unit1Button;
    [SerializeField]
    private GameObject Unit2Button;
    [SerializeField]
    private GameObject Unit3Button;

    public List<Combat.Unit> Enemies;
    void Awake()
    {
        Unit1Button.SetActive(false);
        Unit2Button.SetActive(false);
        Unit3Button.SetActive(false);
        AttackButton.SetActive(false);
    }
    void Start()
    {
        AttackButton.SetActive(true);
        Unit1Button.SetActive(false);
        Unit2Button.SetActive(false);
        Unit3Button.SetActive(false);
    }

    [ContextMenu("Test: allow attack")]
    public void AllowAttack()          // Beginning of Attack Selection    ||  Also assessable through a Back Button
    {
        Unit1Button.SetActive(false);
        Unit2Button.SetActive(false);
        Unit3Button.SetActive(false);
        AttackButton.SetActive(true);
    }

    public void ToggleTargets() // triggered once the user selects the Attack 
    {
        AttackButton.SetActive(false);

        if (Enemies[0].Alive == true)
            Unit1Button.SetActive(true);
        if (Enemies[1].Alive == true)
            Unit2Button.SetActive(true);
        if (Enemies[2].Alive == true)
            Unit3Button.SetActive(true);
    }

    public void ResetButtons()
    {
        AttackButton.SetActive(false);
        Unit1Button.SetActive(false);
        Unit2Button.SetActive(false);
        Unit3Button.SetActive(false);
    }
}

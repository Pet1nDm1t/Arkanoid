using Arkanoid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text _text;

    [SerializeField]private GameManager _gameManager;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }
    void Update()
    {
        _text.text = _gameManager.Health.ToString();

    }
}

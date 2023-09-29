using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePrint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreprinter;
    [SerializeField] ButtonAndSceneControllerAndTankChecker scorer;
    // Start is called before the first frame update
    void Start()
    {
        scorer = GameObject.FindGameObjectWithTag("Handler").GetComponent<ButtonAndSceneControllerAndTankChecker>();
        scoreprinter = GetComponent<TextMeshProUGUI>();
        print(scorer.Temp_GreenScore);
        print(scorer.Temp_RedScore);
        scoreprinter.text = ("Player 1 : " + scorer.Temp_GreenScore + "  |  Player 2 : " + scorer.Temp_RedScore);
    }
}

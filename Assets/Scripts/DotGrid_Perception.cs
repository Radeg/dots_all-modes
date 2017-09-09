using Gamelogic.Extensions.Algorithms;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MadLevelManager;

namespace Gamelogic.Grids.Examples
{
    public class DotGrid_Perception : GridBehaviour<FlatHexPoint>
    {
        public DotTileSet tiles;
        public Text statusScore;
        public Text endScore;
        public GameObject introPanel;
        public Image selectedPrefab;
        public GameObject endPanel;
        public int activeColorsNumber;
        public GameObject scorePlusPrefab;
        public GameObject scoreMinusPrefab;

        private int scoreValue;
        private List<Color> selectedCellColorList = new List<Color>();
        private float xPosition;
        private GameObject instObj;

        // Grid Initialization
        public override void InitGrid()
        {
            foreach (var point in Grid)
            {
                var cell = (DotCell)Grid[point];
                cell.foreground.sprite = tiles.sprites.RandomItem();
                cell.Color = tiles.colors.RandomItem();
                for (int i = 0; i < selectedCellColorList.Count; i++)
                {
                    if (cell.Color == selectedCellColorList[i])
                        cell.tag = "activeColor";
                }
                cell.gameObject.SetActive(false);
            }
        }

        public void Start()
        {
            Time.timeScale = 0f;
            GetRandomCells(activeColorsNumber);

            // Selected colors positioning
            switch (selectedCellColorList.Count)
            {
                case 1:
                    xPosition = -144f;
                    break;
                case 2:
                    xPosition = -216f;
                    break;
                case 3:
                    xPosition = -288f;
                    break;
                case 4:
                    xPosition = -360f;
                    break;
            }
            StartCoroutine(RandomPick());
            statusScore.text = "Score: " + scoreValue;

            for (int i = 0; i < selectedCellColorList.Count; i++)
            {
                xPosition += 144f;
                var exampleColor = Instantiate(selectedPrefab, introPanel);
                exampleColor.transform.position = new Vector3(xPosition, 0f, 0f);
                exampleColor.color = selectedCellColorList[i];
            }
        }

        // Random and progressive selection from group of all dots
        IEnumerator RandomPick()
        {
            Transform randomCell;
            List<int> randomNumbers = new List<int>();
            var numberOfCells = this.gameObject.transform.childCount;

            for (int i = 0; i <= numberOfCells; i++)
            {
                int index = Random.Range(0, numberOfCells);

                if (!randomNumbers.Contains(index))
                {
                    randomNumbers.Add(index);
                    randomCell = this.gameObject.transform.GetChild(index);
                    randomCell.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    randomCell.gameObject.SetActive(false);

                    // End of game
                    if (randomNumbers.Count == numberOfCells)
                    {
                        var canvas = GameObject.Find("Level Canvas");

                        Instantiate(endPanel, canvas);
                        MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
                    }
                } else
                {
                    if (i < numberOfCells)
                        i--;
                }
            }
        }

        // Random color selection for game start
        public void GetRandomCells(int numberOfCells)
        {
            var allCells = this.gameObject.transform.childCount;

            for (int i = 0; i < numberOfCells; i++)
            {
                int randomNumber = Random.Range(0, allCells);
                Transform selectedCell = this.gameObject.transform.GetChild(randomNumber);
                Color selectedCellColor = selectedCell.GetComponentInChildren<SpriteRenderer>().color;
                if (!selectedCellColorList.Contains(selectedCellColor))
                {
                    selectedCellColorList.Add(selectedCellColor);
                }
                else
                {
                    i--;
                }
            }
        }

        public void OnClick()
        {
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPos.z = -5;

            if (Grid[MousePosition] == null)
            {
                return;
            }
            var tag = Grid[MousePosition].tag;

            // Good or bad dot selected
            if (tag == "activeColor" && Grid[MousePosition].gameObject.activeSelf)
            {
                Grid[MousePosition].gameObject.SetActive(false);
                instObj = Instantiate(scorePlusPrefab, screenPos, Quaternion.identity);
                Destroy(instObj, 1f);
                scoreValue += 10;
                statusScore.text = "Score: " + scoreValue;
                endScore.text = "Score: " + scoreValue;
            } else if (tag != "activeColor" && Grid[MousePosition].gameObject.activeSelf)
            {
                Grid[MousePosition].gameObject.SetActive(false);
                instObj = Instantiate(scoreMinusPrefab, screenPos, Quaternion.identity);
                Destroy(instObj, 1f);
                scoreValue -= 5;
                statusScore.text = "Score: " + scoreValue;
                endScore.text = "Score: " + scoreValue;
            }
        }

        // Start button on introPrefab
        public void StartGame()
        {
            introPanel.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
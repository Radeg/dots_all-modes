using Gamelogic.Extensions.Algorithms;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MadLevelManager;

namespace Gamelogic.Grids.Examples
{
    public class DotGrid_Speed : GridBehaviour<FlatHexPoint>
    {
        public DotTileSet tiles;
        public Text endScore;
        public Text statusScore;
        public GameObject introPanel;
        public Image selectedPrefab;
        public GameObject endPanel;
        public int activeColorsNumber;
        public GameObject goodPrefab;
        public GameObject badPrefab;

        private float endTime;
        private List<Color> selectedCellColorList = new List<Color>();
        private float xPosition;
        private GameObject instObj;
        private bool activeColorsReady;

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
                    {
                        cell.tag = "activeColor";
                        activeColorsReady = true;
                    }
                }
            }
        }

        public void Start()
        {
            activeColorsReady = false;
            statusScore.text = "Time: 0 s";
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

            for (int i = 0; i < selectedCellColorList.Count; i++)
            {
                xPosition += 144f;
                var exampleColor = Instantiate(selectedPrefab, introPanel);
                exampleColor.transform.position = new Vector3(xPosition, 0f, 0f);
                exampleColor.color = selectedCellColorList[i];
            }
            this.gameObject.SetActive(false);
        }

        public void Update()
        {
            GameObject[] allActiveColors = GameObject.FindGameObjectsWithTag("activeColor");
            endTime += Time.deltaTime;
            statusScore.text = "Time: " + endTime.ToString("f1") + " s";
            endScore.text = "Time: " + endTime.ToString("f1") + " seconds";

            // End of game
            if (allActiveColors.Length == 0 && activeColorsReady)
            {
                var canvas = GameObject.Find("Level Canvas");

                this.gameObject.SetActive(false);
                Instantiate(endPanel, canvas);
                MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
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
                } else
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
            if (tag == "activeColor")
            {
                instObj = Instantiate(goodPrefab, screenPos, Quaternion.identity);
                Destroy(instObj, 1f);
                Destroy(Grid[MousePosition].gameObject);
            } else
            {
                instObj = Instantiate(badPrefab, screenPos, Quaternion.identity);
                Destroy(instObj, 1f);
            }
        }

        // Start button on introPrefab
        public void StartGame()
        {
            introPanel.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
        }
    }
}
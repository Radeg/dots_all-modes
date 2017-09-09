using Gamelogic.Extensions.Algorithms;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MadLevelManager;

namespace Gamelogic.Grids.Examples
{
    public class DotGrid_Memory : GridBehaviour<FlatHexPoint>
    {
        public DotTileSet tiles;
        public GameObject introPanel;
        public Image selectedPrefab;
        public GameObject endPanel;
        public Text statusScore;
        public Text endScore;
        public int activeColorsNumber;
        public GameObject goodPrefab;
        public GameObject badPrefab;

        private List<Color> selectedCellColorList = new List<Color>();
        private float xPosition;
        private int moves;
        private GameObject instObj;

        // Grid Initialization
        public override void InitGrid()
        {
            foreach (var point in Grid)
            {
                var cell = (DotCell) Grid[point];
                cell.foreground.sprite = tiles.sprites.RandomItem();
                cell.Color = tiles.colors.RandomItem();
            }
        }

        public void Start()
        {
            moves = 0;
            statusScore.text = "Moves: " + moves;
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
            endScore.text = "Moves: " + moves;

            // End of game
            if (selectedCellColorList.Count == 0)
            {
                var canvas = GameObject.Find("Level Canvas");

                this.gameObject.SetActive(false);
                Instantiate(endPanel, canvas);
                MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
            }
        }

        // Random color selection for game start
        public void GetRandomCells (int numberOfCells)
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
            var clickedCellColor = Grid[MousePosition].Color;
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPos.z = -5;

            moves++;
            statusScore.text = "Moves: " + moves;

            // Good or bad dot selected
            if (clickedCellColor == selectedCellColorList[0] && Grid[MousePosition].gameObject.activeSelf)
            {
                instObj = Instantiate(goodPrefab, screenPos, Quaternion.identity);
                Destroy(instObj, 1f);
                selectedCellColorList.Remove(clickedCellColor);
                Grid[MousePosition].gameObject.SetActive(false);
            }
            else if (clickedCellColor != selectedCellColorList[0] && Grid[MousePosition].gameObject.activeSelf)
                instObj = Instantiate(badPrefab, screenPos, Quaternion.identity);
                Destroy(instObj, 1f);

        }

        // Start button on introPrefab
        public void StartGame()
        {
            introPanel.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
        }
    }
}
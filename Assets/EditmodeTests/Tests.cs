using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

namespace Tesztek
{
    [TestFixture]
    public class MazeCellTests
    {
        private MazeCell mazeCell;

        [SetUp]
        public void SetUp()
        {
            GameObject go = new GameObject();
            mazeCell = go.AddComponent<MazeCell>();

            mazeCell._leftWall = new GameObject("LeftWall");
            mazeCell._rightWall = new GameObject("RightWall");
            mazeCell._frontWall = new GameObject("FrontWall");
            mazeCell._backWall = new GameObject("BackWall");
            mazeCell._unvisitedBlock = new GameObject("UnvisitedBlock");
        }

        [Test]
        public void MazeCell_DefaultState_IsNotVisited()
        {
            Assert.IsFalse(mazeCell.IsVisited);
        }

        [Test]
        public void MazeCell_Visit_SetsIsVisitedToTrue()
        {
            mazeCell.Visit();
            Assert.IsTrue(mazeCell.IsVisited);
            Assert.IsFalse(mazeCell._unvisitedBlock.activeSelf);
        }

        [Test]
        public void MazeCell_ClearLeftWall_DisablesLeftWall()
        {
            mazeCell.ClearLeftWall();
            Assert.IsFalse(mazeCell._leftWall.activeSelf);
        }

        [Test]
        public void MazeCell_ClearRightWall_DisablesRightWall()
        {
            mazeCell.ClearRightWall();
            Assert.IsFalse(mazeCell._rightWall.activeSelf);
        }

        [Test]
        public void MazeCell_ClearFrontWall_DisablesFrontWall()
        {
            mazeCell.ClearFrontWall();
            Assert.IsFalse(mazeCell._frontWall.activeSelf);
        }

        [Test]
        public void MazeCell_ClearBackWall_DisablesBackWall()
        {
            mazeCell.ClearBackWall();
            Assert.IsFalse(mazeCell._backWall.activeSelf);
        }
    }

    [TestFixture]
    public class DefaultMazeGenerationTests
    {
        [Test]
        public void DefaultGenerationTest()
        {
            GameObject mazeGeneratorObject = new GameObject();
            MazeGenerator mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

            
            mazeGenerator.Start();

            Assert.AreEqual(mazeGenerator._mazeWidth, 20);
            Assert.AreEqual(mazeGenerator._mazeDepth, 20);
            Assert.IsNotNull(mazeGenerator._mazeGrid);
        }
    }

    [TestFixture]
    public class MazeGeneratorTests
    {
        [Test]
        public void MazeGenerator_GeneratesMaze()
        {
            
            GameObject mazeGeneratorObject = new GameObject();
            MazeGenerator mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

            
            mazeGenerator.Start();

            
            Assert.IsNotNull(mazeGenerator._mazeGrid, "Maze grid should be initialized");
            Assert.Greater(mazeGenerator._mazeGrid.GetLength(0), 0, "Maze width should be greater than 0");
            Assert.Greater(mazeGenerator._mazeGrid.GetLength(1), 0, "Maze depth should be greater than 0");
        }

        [Test]
        public void MazeCell_Visit_SetsIsVisited()
        {
                
                GameObject mazeCellObject = new GameObject();
                MazeCell mazeCell = mazeCellObject.AddComponent<MazeCell>();
                mazeCell._unvisitedBlock = new GameObject("UnvisitedBlock");

                
                mazeCell.Visit();

                
                Assert.IsTrue(mazeCell.IsVisited, "Maze cell should be visited");
                Assert.IsFalse(mazeCell._unvisitedBlock.activeSelf, "Unvisited block should be deactivated");
        }

        [Test]
        public void MazeCell_ClearLeftWall_DeactivatesLeftWall()
        {
            
            GameObject mazeCellObject = new GameObject();
            MazeCell mazeCell = mazeCellObject.AddComponent<MazeCell>();
            mazeCell._leftWall = new GameObject();

            
            mazeCell.ClearLeftWall();

            
            Assert.IsFalse(mazeCell._leftWall.activeSelf, "Left wall should be deactivated");
        }

        [Test]
        public void MazeCell_ClearBackWall_DeactivatesBackWall()
        {
            
            GameObject mazeCellObject = new GameObject();
            MazeCell mazeCell = mazeCellObject.AddComponent<MazeCell>();
            mazeCell._backWall = new GameObject();

            
            mazeCell.ClearBackWall();

            
            Assert.IsFalse(mazeCell._backWall.activeSelf, "Back wall should be deactivated");
        }

        [Test]
        public void MazeCell_ClearFrontWall_DeactivatesFrontWall()
        {
            
            GameObject mazeCellObject = new GameObject();
            MazeCell mazeCell = mazeCellObject.AddComponent<MazeCell>();
            mazeCell._frontWall = new GameObject();

            
            mazeCell.ClearFrontWall();

            
            Assert.IsFalse(mazeCell._frontWall.activeSelf, "Front wall should be deactivated");
        }

        [Test]
        public void MazeCell_ClearRightWall_DeactivatesRightWall()
        {
            
            GameObject mazeCellObject = new GameObject();
            MazeCell mazeCell = mazeCellObject.AddComponent<MazeCell>();
            mazeCell._rightWall = new GameObject();

            
            mazeCell.ClearRightWall();

            
            Assert.IsFalse(mazeCell._rightWall.activeSelf, "Right wall should be deactivated");
        }

        [Test]
        public void MazeGenerator_GeneratesMazeWithCorrectDimensions()
        {
            
            GameObject mazeGeneratorObject = new GameObject();
            MazeGenerator mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

            
            mazeGenerator.Start();

            
            Assert.IsNotNull(mazeGenerator._mazeGrid, "Maze grid should be initialized");
            Assert.AreEqual(mazeGenerator._mazeWidth, mazeGenerator._mazeGrid.GetLength(0), "Maze width should match grid width");
            Assert.AreEqual(mazeGenerator._mazeDepth, mazeGenerator._mazeGrid.GetLength(1), "Maze depth should match grid depth");
        }
    }

    [TestFixture]
    public class SpawningTests
    {
        [Test]
        public void GenerateRandomItem_ItemsAreWithinMazeBounds()
        {
            
            GameObject spawningObject = new GameObject();
            Spawning spawning = spawningObject.AddComponent<Spawning>();
            spawning.itemPrefab = new GameObject();
            spawning.Count = 12;
            spawning.mazeSize = 80;

            
            spawning.GenerateRandomItem();

            
            var items = GameObject.FindGameObjectsWithTag("Kredit");
            foreach (var item in items)
            {
                var position = item.transform.position;
                Assert.IsTrue(position.x >= 0 && position.x < spawning.mazeSize, "Item is outside X bounds");
                Assert.IsTrue(position.y >= 0 && position.y < spawning.mazeSize, "Item is outside Y bounds");
            }
        }

        [Test]
        public void GenerateRandomItem_ItemsHaveCorrectPosition()
        {
            
            GameObject spawningObject = new GameObject();
            Spawning spawning = spawningObject.AddComponent<Spawning>();
            spawning.itemPrefab = new GameObject();
            spawning.Count = 12;
            spawning.mazeSize = 80;

            
            spawning.GenerateRandomItem();

            
            var items = GameObject.FindGameObjectsWithTag("Kredit");
            foreach (var item in items)
            {
                var position = item.transform.position;
                Assert.IsTrue(position.x % 4 == 0, "Item X position is not a multiple of 4");
                Assert.IsTrue(position.y % 4 == 0, "Item Y position is not a multiple of 4");
            }
        }
    }

    
}
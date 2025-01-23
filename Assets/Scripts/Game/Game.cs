using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class Game
{
    public Cell[] cells = new Cell[100];
    public CellText[] texts = new CellText[100];

    public Player player;
    public RedEnemy redEnemy;
    public BlueEnemy blueEnemy;
    public FluidEnemy fluidEnemy;

    public Event currentEvent;

    public int stepCount = 0;
    public int tree, rock, water;

    private System.Random random = new System.Random();
    private int[] toDestroy = new int[3];

    public Game(Player p, RedEnemy re, BlueEnemy be, FluidEnemy fe, Cell[] c, CellText[] ct)
    {
        this.player = p;
        this.redEnemy = re;
        this.blueEnemy = be;
        this.fluidEnemy = fe;

        for (int i = 0; i < 100; i++)
        {
            this.cells[i] = c[i];
            this.texts[i] = ct[i];
        }
    }

    public void gameStep(Vector2 start)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (this.player.getAvailableCells().Contains(i))
            {
                if (cells[i].pos.x - Consts.width / 2 <= start.x && start.x < cells[i].pos.x + Consts.width / 2)
                {
                    if (cells[i].pos.y + Consts.width / 2 >= start.y && start.y > cells[i].pos.y - Consts.width / 2)
                    {
                        if (cells[i].isAlive || cells[i].isBridge)
                        {
                            player.cell = i;
                            player.newPos(cells[i].pos.x, cells[i].pos.y);
                            Consts.game.cells[i].getResource();

                            Consts.game.stepCount++;

                            monsterStep();
                            desroyCells();
                            checkResult();

                            return;
                        }
                    }
                }
            }
        }
    }

    public void build(Vector2 start)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].pos.x - Consts.width / 2 <= start.x && start.x < cells[i].pos.x + Consts.width / 2)
            {
                if (cells[i].pos.y + Consts.width / 2 >= start.y && start.y > cells[i].pos.y - Consts.width / 2)
                {
                    if (Consts.buildBridge && !cells[i].isAlive && !cells[i].isHut)
                    {
                        this.cells[i].setBridge();
                        return;
                    }
                    if (Consts.buildHut && (cells[i].isAlive || cells[i].isBridge))
                    {
                        this.cells[i].setHut();
                        this.cells[i].resourceCount = 0;
                        this.texts[i].updateText(0);
                        this.texts[i].hideText();
                        return;
                    }
                }
            }
        }
    }

    public void skipStep()
    {
        Consts.game.stepCount++;

        monsterStep();
        desroyCells();
        checkResult();

        return;
    }

    public void desroyCells()
    {
        for (int j = 0; j < 3; j++)
        {
            this.cells[toDestroy[j]].setDestroy();
            toDestroy[j] = random.Next(100);
            if (this.cells[toDestroy[j]].isAlive)
            {
                this.cells[toDestroy[j]].setPreDestroy();
            }
        }
    }

    private void checkResult()
    {
        if (redEnemy.cell == player.cell)
        {
            Consts.titleText = LanguageManager.L.LoseTxt;
            Consts.textText = LanguageManager.L.RedEnd;
            Consts.EndShown = true;
            return;
        }

        if (!this.cells[player.cell].isAlive && !this.cells[player.cell].isBridge)
        {
            Consts.titleText = LanguageManager.L.LoseTxt;
            Consts.textText = LanguageManager.L.CosmosEnd;
            Consts.EndShown = true;
            return;
        }

        if (this.tree <= 0 && this.rock <= 0 && this.water <= 0)
        {
            Consts.titleText = LanguageManager.L.WinEnd;
            Consts.textText = LanguageManager.L.WinTxt;
            Consts.EndShown = true;
            return;
        }

        if (random.Next(10) == 5)
        {
            currentEvent = EventManager.events[EventManager.variances[random.Next(EventManager.variances.Length)]];
            Consts.OneCardShown = true;
            Consts.eventText = LanguageManager.L.Events[currentEvent.id];
            return;
        }
    }

    public void monsterStep()
    {
        if (!cells[redEnemy.cell].isAlive && !cells[redEnemy.cell].isBridge && redEnemy.isAlive)
        {
            redEnemy.isAlive = false;
            redEnemy.hideEnemy();
        }
        if (!cells[blueEnemy.cell].isAlive && !cells[blueEnemy.cell].isBridge && blueEnemy.isAlive)
        {
            blueEnemy.isAlive = false;
            blueEnemy.hideEnemy();
        }
        if (!cells[fluidEnemy.cell].isAlive && !cells[fluidEnemy.cell].isBridge && fluidEnemy.isAlive)
        {
            fluidEnemy.isAlive = false;
            fluidEnemy.hideEnemy();
        }

        if (redEnemy.isAlive)
        {
            List<int> availableCells = Enemy.getAvailableCells(Consts.game.redEnemy.cell, new int[] { 1, Consts.ONE_ROW, Consts.ONE_ROW - 1, Consts.ONE_ROW + 1, -1, -Consts.ONE_ROW, -Consts.ONE_ROW + 1, -Consts.ONE_ROW - 1 });
            if (availableCells.Count > 0)
            {
                int index = availableCells[this.random.Next(availableCells.Count)];
                for (int i = 0; i < availableCells.Count; i++)
                {
                    if (Consts.game.player.cell == availableCells[i] && !cells[Consts.game.player.cell].isHut)
                    {
                        index = availableCells[i];
                    }
                }
                if (cells[index].isAlive || cells[index].isBridge)
                {
                    Cell newCell = Consts.game.cells[index];
                    Consts.game.redEnemy.newPos(newCell.pos.x, newCell.pos.y);
                    Consts.game.redEnemy.cell = index;
                }
            }
        }

        if (blueEnemy.isAlive)
        {
            List<int> availableCells = Enemy.getAvailableCells(Consts.game.blueEnemy.cell, new int[] { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW });
            if (availableCells.Count > 0)
            {
                int index = availableCells[this.random.Next(availableCells.Count)];
                for (int i = 0; i < availableCells.Count; i++)
                {
                    if (Consts.game.player.cell == availableCells[i] && !cells[Consts.game.player.cell].isHut)
                    {
                        index = availableCells[i];
                        this.tree += 10;
                        this.water += 10;
                        this.rock += 10;
                    }
                }
                if (cells[index].isAlive || cells[index].isBridge)
                {
                    Cell newCell = Consts.game.cells[index];
                    Consts.game.blueEnemy.newPos(newCell.pos.x, newCell.pos.y);
                    Consts.game.blueEnemy.cell = index;
                }
            }
        }

        if (fluidEnemy.isAlive)
        {
            List<int> availableCells = Enemy.getAvailableCells(Consts.game.fluidEnemy.cell, new int[] { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW });
            if (availableCells.Count > 0)
            {
                int index = availableCells[this.random.Next(availableCells.Count)];
                for (int i = 0; i < availableCells.Count; i++)
                {
                    if (cells[availableCells[i]].type == fluidEnemy.type && cells[availableCells[i]].resourceCount != 0 && !cells[Consts.game.player.cell].isHut)
                    {
                        index = availableCells[i];
                    }
                }
                if (cells[index].isAlive || cells[index].isBridge)
                {
                    Cell newCell = Consts.game.cells[index];
                    Consts.game.fluidEnemy.newPos(newCell.pos.x, newCell.pos.y);
                    Consts.game.fluidEnemy.cell = index;
                }
                if (this.cells[Consts.game.fluidEnemy.cell].type == fluidEnemy.type)
                {
                    this.cells[Consts.game.fluidEnemy.cell].resourceCount = 0;
                    this.texts[Consts.game.fluidEnemy.cell].updateText(this.cells[Consts.game.fluidEnemy.cell].resourceCount);
                }
                if (random.Next(5) == 1)
                {
                    fluidEnemy.type = Consts.types[random.Next(Consts.types.Length)];
                }
            }
        }
    }

    public void getEvent()
    {
        EventManager.eventAction(this.currentEvent.id);
    }

    public void renewGame()
    {
        for (int i = 0; i < 100; i++)
        {
            this.cells[i].restartCell();
            this.texts[i].hidden = false;
            this.texts[i].updateText(this.cells[i].resourceCount);
        }

        this.tree = this.random.Next(20, 60);
        this.rock = this.random.Next(20, 60);
        this.water = this.random.Next(20, 60);
        this.stepCount = 0;

        int index = random.Next(100);
        Cell target = cells[index];
        player.cell = index;
        this.cells[player.cell].getResource();
        player.newPos(target.pos.x, target.pos.y);

        index = random.Next(100);
        while (index == player.cell)
        {
            index = random.Next(100);
        }
        target = cells[index];
        redEnemy.cell = index;
        redEnemy.newPos(target.pos.x, target.pos.y);

        index = random.Next(100);
        while (index == player.cell)
        {
            index = random.Next(100);
        }
        target = cells[index];
        blueEnemy.cell = index;
        blueEnemy.newPos(target.pos.x, target.pos.y);

        index = random.Next(100);
        while (index == player.cell)
        {
            index = random.Next(100);
        }
        target = cells[index];
        fluidEnemy.cell = index;
        fluidEnemy.newPos(target.pos.x, target.pos.y);
        fluidEnemy.type = Consts.types[random.Next(Consts.types.Length)];

        for (int j = 0; j < 3; j++)
        {
            toDestroy[j] = random.Next(100);
            this.cells[toDestroy[j]].setPreDestroy();
        }
    }
}

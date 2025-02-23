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

    public int stepCount = 0;
    public int tree, rock, water;
    public int yourtree, yourrock, yourwater;

    public List<Effect> effects = new List<Effect>();

    private System.Random random = new System.Random();
    private int[] toDestroy = new int[3];
    private Event currentEvent;

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
            if (this.player.getAvailableCells().Contains(i) || i == player.cell)
            {
                int sm = Consts.width / 2;
                if (Consts.width % 2 != 0)
                {
                    sm += 1;
                }
                if (cells[i].pos.x - sm <= start.x && start.x < cells[i].pos.x + sm)
                {
                    if (cells[i].pos.y + sm >= start.y && start.y > cells[i].pos.y - sm)
                    {
                        if (i == player.cell)
                        {
                            player.semiTransparent = !player.semiTransparent;
                            return;
                        }
                        else if (cells[i].isAlive || cells[i].isBridge)
                        {
                            Consts.game.cells[i].tapCell();
                            player.semiTransparent = false;
                            player.flip(player.cell, i);
                            player.cell = i;
                            player.newPos(cells[i].pos.x, cells[i].pos.y);
                            Consts.game.cells[i].getResource();

                            Consts.game.stepCount++;

                            effectsDoing();
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
                        return;
                    }
                }
            }
        }
    }

    public void skipStep()
    {
        player.semiTransparent = false;
        Consts.game.stepCount++;

        effectsDoing();
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

    public void effectsDoing()
    {
        foreach (Effect e in this.effects)
        {
            e.effect();
        }

        this.effects.RemoveAll(n => n.getLonging() == 0);
    }

    private void checkResult()
    {
        if (!this.cells[player.cell].isAlive)
        {
            Consts.titleText = LanguageManager.L.LoseTxt;
            Consts.textText = LanguageManager.L.CosmosEnd;
            Consts.spriteText = Resources.Load<Sprite>("Sprites/lostInCosmos");
            Consts.EndShown = true;
            return;
        }

        if (this.tree <= this.yourtree && this.rock <= this.yourrock && this.water <= this.yourwater)
        {
            Consts.titleText = LanguageManager.L.WinTxt;
            Consts.textText = LanguageManager.L.WinEnd;
            Consts.spriteText = Resources.Load<Sprite>("Sprites/win");
            Consts.EndShown = true;
            return;
        }

        if (random.Next(10) == 5)
        {
            currentEvent = EventManager.events[EventManager.variances[random.Next(EventManager.variances.Length)]];
            Consts.OneCardShown = true;
            Consts.eventSprite = Resources.Load<Sprite>("Sprites/event" + currentEvent.id);
            Consts.eventText = LanguageManager.L.Events[currentEvent.id];
            return;
        }
    }

    public void monsterStep()
    {
        if (!cells[redEnemy.cell].isAlive && !cells[redEnemy.cell].isBridge && redEnemy.isAlive)
        {
            redEnemy.isAlive = false;
        }
        if (!cells[blueEnemy.cell].isAlive && !cells[blueEnemy.cell].isBridge && blueEnemy.isAlive)
        {
            blueEnemy.isAlive = false;
        }
        if (!cells[fluidEnemy.cell].isAlive && !cells[fluidEnemy.cell].isBridge && fluidEnemy.isAlive)
        {
            fluidEnemy.isAlive = false;
        }

        if (redEnemy.isAlive && redEnemy.canMove)
        {
            List<int> availableCells = redEnemy.getAvailableCells();
            if (availableCells.Count > 0)
            {
                int index = availableCells[this.random.Next(availableCells.Count)];
                for (int i = 0; i < availableCells.Count; i++)
                {
                    if (player.cell == availableCells[i] && !cells[player.cell].isHut)
                    {
                        index = availableCells[i];
                    }
                }
                if (cells[index].isAlive || cells[index].isBridge)
                {
                    Cell newCell = cells[index];
                    redEnemy.newPos(newCell.pos.x, newCell.pos.y);
                    redEnemy.flip(redEnemy.cell, index);
                    redEnemy.cell = index;
                }
            }
            redEnemy.effect();
        }

        if (blueEnemy.isAlive && blueEnemy.canMove)
        {
            List<int> availableCells = blueEnemy.getAvailableCells();
            if (availableCells.Count > 0)
            {
                int index = availableCells[this.random.Next(availableCells.Count)];
                for (int i = 0; i < availableCells.Count; i++)
                {
                    if (player.cell == availableCells[i] && !cells[player.cell].isHut)
                    {
                        index = availableCells[i];
                    }
                }
                if (cells[index].isAlive || cells[index].isBridge)
                {
                    Cell newCell = cells[index];
                    blueEnemy.newPos(newCell.pos.x, newCell.pos.y);
                    blueEnemy.flip(blueEnemy.cell, index);
                    blueEnemy.cell = index;
                }
                blueEnemy.effect();
            }
        }

        if (fluidEnemy.isAlive && fluidEnemy.canMove)
        {
            List<int> availableCells = fluidEnemy.getAvailableCells();
            if (availableCells.Count > 0)
            {
                int index = availableCells[this.random.Next(availableCells.Count)];
                for (int i = 0; i < availableCells.Count; i++)
                {
                    if (cells[availableCells[i]].type == fluidEnemy.type && cells[availableCells[i]].resourceCount != 0 && !cells[player.cell].isHut)
                    {
                        index = availableCells[i];
                    }
                }
                if (cells[index].isAlive || cells[index].isBridge)
                {
                    Cell newCell = cells[index];
                    fluidEnemy.newPos(newCell.pos.x, newCell.pos.y);
                    fluidEnemy.flip(fluidEnemy.cell, index);
                    fluidEnemy.cell = index;
                }
                fluidEnemy.effect();
            }
        }
    }

    public void getEvent()
    {
        EventManager.eventAction(this.currentEvent);
    }

    public void renewGame()
    {
        for (int i = 0; i < 100; i++)
        {
            this.cells[i].restartCell();
        }

        this.tree = this.random.Next(20, 60);
        this.rock = this.random.Next(20, 60);
        this.water = this.random.Next(20, 60);
        this.stepCount = 0;
        this.yourtree = 0;
        this.yourrock = 0;
        this.yourwater = 0;

        int index = random.Next(100);
        player.renew(index);
        this.cells[player.cell].getResource();

        index = random.Next(100);
        while (index == player.cell)
        {
            index = random.Next(100);
        }
        redEnemy.renew(index);

        index = random.Next(100);
        while (index == player.cell)
        {
            index = random.Next(100);
        }
        blueEnemy.renew(index);

        index = random.Next(100);
        while (index == player.cell)
        {
            index = random.Next(100);
        }
        fluidEnemy.renew(index);

        for (int j = 0; j < 3; j++)
        {
            toDestroy[j] = random.Next(100);
            this.cells[toDestroy[j]].setPreDestroy();
        }
    }
}

public class SleepEffectMonsters : Effect
{
    public SleepEffectMonsters(int longing)
    {
        this.setLonging(longing);

        Consts.game.fluidEnemy.canMove = false;
        Consts.game.redEnemy.canMove = false;
        Consts.game.blueEnemy.canMove = false;
    }

    public override void effect()
    {
        this.setLonging(this.getLonging() - 1);

        if (this.getLonging() == 0)
        {
            Consts.game.fluidEnemy.canMove = true;
            Consts.game.redEnemy.canMove = true;
            Consts.game.blueEnemy.canMove = true;
        }
    }
}
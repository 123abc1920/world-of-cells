public class SleepEffectPlayer : Effect
{
    public SleepEffectPlayer(int longing)
    {
        this.setLonging(longing);
        Consts.game.player.canMove = false;
    }

    public override void effect()
    {
        this.setLonging(this.getLonging() - 1);

        if (this.getLonging() == 0)
        {
            Consts.game.player.canMove = true;
        }
    }
}
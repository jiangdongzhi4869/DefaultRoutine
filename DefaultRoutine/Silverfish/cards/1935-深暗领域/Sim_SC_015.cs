using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 法术 无效的 费用：3
    // Nydus Worm
    // 坑道虫
    // Draw two Zerg cards. They cost (1) less.
    // 抽两张异虫牌，这些牌的法力值消耗减少（1）点。

    class Sim_SC_015 : SimTemplate
    {
        
            public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}
        
    }
}
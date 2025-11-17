using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 法术 猎人 费用：2
    // Evolution Chamber
    // 进化腔
    // Give your minions +1 Attack. Give your Zerg an extra +1/+1.
    // 使你的随从获得 +1 攻击力，使你的异虫额外获得 +1/+1。

    class Sim_SC_021 : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions; // 获取己方随从列表

            foreach (Minion m in p.ownMinions)//异虫是作为一类牌加入炉石而非种族，固不能用种族类型方法
            {
                p.minionGetBuffed(m, 1, 0); // 所有随从获得 +1 攻击力

				if(m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇|| m.handcard.card.nameCN == CardDB.cardNameCN.巢群虫后)
				{
					p.minionGetBuffed(m, 2, 1); // 额外获得 +1/+1（共 +1 攻击，+1 生命）
				}
				                
            }
        }
    }
}
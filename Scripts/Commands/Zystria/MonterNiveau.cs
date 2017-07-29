using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Commands;

namespace Server.Commands.Zystria
{
    class MonterNiveau
    {
        public static void Initialize()
        {
            CommandSystem.Register("monterniveau", AccessLevel.Player, new CommandEventHandler(monterniveau_command));
        }

        [Usage("monterniveau")]
        [Description("Monter d'un niveau.")]

        public static void monterniveau_command(CommandEventArgs e)
        {
            bool lvlUp;
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile from = (PlayerMobile)e.Mobile;
                lvlUp=from.m_exp.levelUp();
                if (lvlUp == true)
                {
                    from.SendMessage("vous êtes maintenant niveau " + from.m_exp.niveaux);
                    from.m_exp.SkillUpdate(from);
                }
                    
                else
                {
                    from.SendMessage("il vous manque encore des xp");
                }
            }
        }
    }
}

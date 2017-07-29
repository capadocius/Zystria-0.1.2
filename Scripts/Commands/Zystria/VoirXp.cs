using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Commands;

namespace Server.Commands.Zystria
{
    class VoirXp
    {
        public static void Initialize()
        {
            CommandSystem.Register("voirxp", AccessLevel.Player, new CommandEventHandler(voirxp_command));
        }

        [Usage("voirxp")]
        [Description("Voir vos points d'expériences accumulés")]

        public static void voirxp_command(CommandEventArgs e)
        {
            int xp;
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile from = (PlayerMobile)e.Mobile;
                xp = from.m_exp.pointXP;
                from.SendMessage("Vos points d'expérience :" + xp);
            }
        }
    }
}

using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;
using Server.Commands;

namespace Server.Commands.Zystria
{
    class AjoutXp
    {
        public static void Initialize()
        {
            CommandSystem.Register("ajoutxp", AccessLevel.GameMaster, new CommandEventHandler(ajoutxp_command));
        }

        [Usage("ajoutxp")]
        [Description("ajouter un xp")]
        private static void ajoutxp_command(CommandEventArgs e)
        {
            PlayerMobile from = ((PlayerMobile)e.Mobile);
            from.Target = new XpTarget();
        }

        private class XpTarget : Target
        {
            public XpTarget() : base(30, false, TargetFlags.None)
            {

            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is PlayerMobile)
                {
                    PlayerMobile target = ((PlayerMobile)targeted);
                    target.m_exp.pointXP++;
                    from.SendMessage("Vous avez donné un point d'expérience");
                    target.SendMessage("Un MJ vous a donné un point d'expérience");
                }
                else
                {
                    from.SendMessage("vous devez cibler un joueur");
                }
            }
        }
    }
}

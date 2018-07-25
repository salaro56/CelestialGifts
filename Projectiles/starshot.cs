﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CelestialGifts.Projectiles
{
    public class starshot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Starshot";
            projectile.width = 36;
            projectile.height = 36;
            projectile.timeLeft = 200;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 5;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            projectile.light = 0.9f; //Lights up the whole room
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f); //Spawns dust
            Main.dust[DustID].noGravity = true; //Makes dust not fall
            projectile.type = 12;
        }
        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            Player owner = Main.player[projectile.owner];
            int rand = Main.rand.Next(2); //Generates an integer from 0 to 1
            if (rand == 0)
            {
                n.AddBuff(24, 180); //On Fire! debuff for 3 seconds
            }
            else if (rand == 1)
            {
                owner.statLife += 1; //Gives 5 Health
                owner.HealEffect(5, true); //Shows you have healed by 5 health
            }
            projectile.type = 12;
        }





    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;
using SoulsMod.Items.Weapons.Melee.Greatswords;
using System.Collections.Generic;
using Terraria.GameContent;

namespace SoulsMod.Projectiles.Swords
{
    public class KirkhammerProjectile2 : ModProjectile
    {
        public int SwingTime = 80;  //increase this, if the swing time is 0, Projectile.timeLeft is also 0
        public float holdOffset = 35f;
        public override void SetDefaults()

        {
            Projectile.timeLeft = SwingTime; //as you can see here
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.height = 60;
            Projectile.width = 60;
            Projectile.friendly = true;
            Projectile.scale = 1.2f;
        }
        public virtual float Lerp(float val)
        {
            return val == 1f ? 1f : (val == 0f ? 0f : (float)Math.Pow(2, val * 10f - 10f) / 2f);
        }

       
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {

            overPlayers.Add(index);
        }



    }
}

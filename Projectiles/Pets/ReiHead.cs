using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ARC.Projectiles.Pets
{
	public class ReiHead : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rei");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Wisp);
			aiType = ProjectileID.Wisp;
		}

        public override bool PreAI()
        {
			Player player = Main.player[projectile.owner];
			player.wisp = false;
			return true;
        }

        public override void AI() {
			Player player = Main.player[projectile.owner];
			ExampleModPlayer modPlayer = player.GetModPlayer<ExampleModPlayer>();
			if (!player.active) {
				projectile.active = false;
				return;
			}
			if (player.dead) {
				modPlayer.LightPet = false;
			}
			if (modPlayer.LightPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}
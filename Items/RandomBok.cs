using System;
using System.Net.Http;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BokMod.Items
{
    public class RandomBok : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.BokMod.hjson file.

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.width = 30;
            Item.height = 30;
            Item.rare = ItemRarityID.White;
            Item.value = 0;
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            base.RightClick(player);
            var itemIDs = new short[] { ItemID.Wood, ItemID.AshWood, ItemID.BorealWood };
            var random = new Random();
            Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://www.random.org/integers/?num=1&min=1&max=6&col=1&base=10&format=plain&rnd=new");
                var quantity = int.Parse(await response.Content.ReadAsStringAsync());
                player.QuickSpawnItem(player.GetSource_DropAsItem(), itemIDs[random.Next(0, 3)], quantity);
            });
            //player.QuickSpawnItem(player.GetSource_DropAsItem(), ItemID.Wood, 2);
            //player.QuickSpawnItem(player.GetSource_DropAsItem(), ItemID.AshWood, 2);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";

            Character hero = new Character();
            hero.Name = "Eleven";
            hero.Health = 100;
            hero.DamageMax = 15;
            hero.AttackBonus = 10;
            hero.LabelName = "elevenLabel";

            Character monster = new Character();
            monster.Name = "Demogorgon";
            monster.Health = 666;
            monster.DamageMax = 35;
            monster.AttackBonus = 0;
            monster.LabelName = "demogorgonLabel";

            monster.Defend(hero.Attack(), out action);
            writeAction(action);
            hero.Defend(monster.Attack(), out action);
            writeAction(action);

            updateStats(hero, monster);
        }

        private void updateStats(Character character1, Character character2)
        {
            Label label1 = FindControl(character1.LabelName) as Label;
            label1.Text = character1.Name + "<br />HP: " + character1.Health;

            Label label2 = FindControl(character2.LabelName) as Label;
            label2.Text = character2.Name + "<br />HP: " + character2.Health;
        }

        private void writeAction(string action)
        {
            actionLabel.Text += action + "<br />";
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMax { get; set; }
        public int AttackBonus { get; set; }
        public string LabelName { get; set; }

        public int Attack()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return random.Next(this.DamageMax + 1) + this.AttackBonus;
        }

        public void Defend(int damage, out string action)
        {
            this.Health -= damage;
            action = string.Format("{0} was hit for {1} damage.", this.Name, damage);
        }

    }

}
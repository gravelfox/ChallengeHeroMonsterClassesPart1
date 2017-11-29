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
            Random random = new Random();

            Character hero = new Character();
            hero.Name = "Eleven";
            hero.Health = 100;
            hero.DamageMax = 35;
            hero.AttackBonus = true;
            hero.LabelName = "elevenLabel";

            Character monster = new Character();
            monster.Name = "Demogorgon";
            monster.Health = 175;
            monster.DamageMax = 20;
            monster.AttackBonus = false;
            monster.LabelName = "demogorgonLabel";

            Die damageDie = new Die();
            
            //bonus round
            if (hero.AttackBonus) monster.Defend(hero.Attack(damageDie, random));
            if (monster.AttackBonus) hero.Defend(monster.Attack(damageDie, random));
            if (monster.AttackBonus || hero.AttackBonus) writeAction(hero, monster, true);
            
            //battle loop
            while (monster.Health > 0 && hero.Health > 0)
            {
                monster.Defend(hero.Attack(damageDie, random));
                hero.Defend(monster.Attack(damageDie, random));
                writeAction(hero, monster);
                updateStats(hero, monster);
            }

        }

        //writes character name and health under avatars
        private void updateStats(Character character1, Character character2)
        {
            Label label1 = FindControl(character1.LabelName) as Label;
            label1.Text = character1.Name + "<br />HP: " + character1.Health;

            Label label2 = FindControl(character2.LabelName) as Label;
            label2.Text = character2.Name + "<br />HP: " + character2.Health;
        }

        //describes a round of action
        private void writeAction(Character hero, Character monster, bool bonus = false)
        {
            if (bonus) actionLabel.Text += "BONUS ATTACK:<BR /><b>";
            if (!bonus || monster.AttackBonus)
                actionLabel.Text += string.Format("{0} hits {1} for {2} damage.<br />", monster.Name, hero.Name, monster.LastDealt.ToString());
            if (!bonus || hero.AttackBonus)
                actionLabel.Text += string.Format("{0} hits {1} for {2} damage.<br />", hero.Name, monster.Name, hero.LastDealt.ToString());
            if (bonus) actionLabel.Text += "</b>";
            if (monster.Health <= 0 && hero.Health <= 0)
            {
                actionLabel.Text += string.Format("{0} and {1} killed each other and will rot alongside one another.", monster.Name, hero.Name);
                return;
            }

            if (monster.Health <= 0)
            {
                actionLabel.Text += string.Format("{0} killed {1} and has vanquised evil from the realm.", hero.Name, monster.Name);
                return;
            }

            if (hero.Health <= 0)
            {
                actionLabel.Text += string.Format("{0} killed {1} the upside-down is bleeding into our world.", monster.Name, hero.Name);
                return;
            }
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMax { get; set; }
        public bool AttackBonus { get; set; }
        public string LabelName { get; set; }
        public int LastDealt { get; set; }

        public int Attack(Die die, Random random)
        {
            die.sides = this.DamageMax;
            this.LastDealt = die.RollDie(random);
            return this.LastDealt;
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }

    }

    class Die
    {
        public int sides { get; set; }

        public int RollDie (Random random)
        {
            return random.Next(1, this.sides + 1);
        }
    }

}
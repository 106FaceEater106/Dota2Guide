using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;

namespace Dota2Guide
{
    public partial class NeutralPage : PhoneApplicationPage
    {
        Neutral neutral;
        public NeutralPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("neutral"))
            {
                //hero = Hero.GetHero(this.NavigationContext.QueryString["hero"]);
                neutral = Globals.GetNeutral(this.NavigationContext.QueryString["neutral"]);
                 PageTitle.Text = neutral.Name;
                //LayoutRoot.ite = hero.Name;
                //LayoutRoot.Children[0].
                //pTitle.Title = neutral.Name;

                heroImg.Source = new BitmapImage(new Uri(neutral.ImageSource, UriKind.RelativeOrAbsolute));
                DamageTextBlock.Text = neutral.Damage;
                MoveSpeedTextBlock.Text = neutral.MoveSpeed;
                ArmorTextBlock.Text = neutral.Armor;
                bioTextBlock.Text = neutral.Bio;

                List<SampleSkill> skills = new List<SampleSkill>();

                for (int i = 0; i < neutral.SkillList.Count; i++)
                {
                    Skill s = neutral.SkillList[i];
                    skills.Add(new SampleSkill(s.Title, s.Description, s.ImageSource));
                }
                skillListBox.ItemsSource = skills;
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SampleSkill s = skillListBox.SelectedValue as SampleSkill;
            NavigationService.Navigate(new Uri("/SkillPage.xaml?skill=" + s.Title+"&type=neutral", UriKind.Relative));
        }
    }
}
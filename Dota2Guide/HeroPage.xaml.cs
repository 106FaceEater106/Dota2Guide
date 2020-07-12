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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Dota2Guide
{
    public partial class HeroPage : PhoneApplicationPage
    {
        DotaHero hero;
        public HeroPage()
        {
            InitializeComponent();
        }

         protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("hero"))
            {
               // hero = Globals.GetHero(this.NavigationContext.QueryString["hero"]);
                hero = DotaHero.Heroes.Where(h => h.Link.Equals(NavigationContext.QueryString["hero"])).SingleOrDefault();
                PageTitle.Text = hero.Name;

                heroImg.Source = new BitmapImage(new Uri(hero.ImageSource, UriKind.RelativeOrAbsolute));
                IntelligenceTextBlock.Text = hero.Intelligence;
                AgilityTextBlock.Text = hero.Agility;
                StrengthTextBlock.Text = hero.Strength;
                DamageTextBlock.Text = hero.Damage;
                MoveSpeedTextBlock.Text = hero.MovementSpeed;
                ArmorTextBlock.Text = hero.Armor;
                bioTextBlock.Text = hero.Bio;
                roleTextBlock.Text =string.Join("-",hero.Roles);

                var skills = DotaSkill.Skills.Where(s=>s.Hero.Equals(hero));
                
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
            NavigationService.Navigate(new Uri("/SkillPage.xaml?skill=" + s.Title, UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
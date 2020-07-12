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

namespace Dota2Guide
{
    public partial class SkillPage : PhoneApplicationPage
    {
        DotaSkill skill;
        public SkillPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SkillPage_Loaded);
        }

        private void SkillPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("skill") && this.NavigationContext.QueryString.ContainsKey("type"))
            {
                //skill = Skill.GetSkill(this.NavigationContext.QueryString["skill"]);

                String type = this.NavigationContext.QueryString["type"];

                if (String.IsNullOrEmpty(type) || type.Equals("hero"))
                {
                    skill = DotaSkill.Skills.Where(s => s.Link.Equals(NavigationContext.QueryString["skill"])).FirstOrDefault();
                }
                else if(type.Equals("neutral"))
                {
                   // skill = Globals.GetNeutralSkill(this.NavigationContext.QueryString["skill"]);
                }

                PageTitle.Text = skill.Title;

                if (skill.ManaCost == null || skill.CoolDown == null)
                    grid1.Visibility = System.Windows.Visibility.Collapsed;

                if (skill.Extra==null)
                    extraTextBlock.Visibility = System.Windows.Visibility.Collapsed;


                infoStackPanel.DataContext = skill;

            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

    }
}
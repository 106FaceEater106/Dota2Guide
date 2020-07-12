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
using Microsoft.Phone.Tasks;
using Microsoft.Advertising.Mobile.UI;

namespace Dota2Guide
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Globals.LoadAllInfo();

            //heroesListBox.ItemsSource =from h in Globals.heroList orderby h.Name select h;
            //itemsListBox.ItemsSource = from i in Globals.itemList orderby i.Title select i;
            neutralListBox.ItemsSource = from n in Globals.neutralList orderby n.Name select n;

            heroesListBox.ItemsSource = DotaHero.Heroes.OrderBy(h=>h.Name);
            DotaSkill.XmlToList("SkillXML/skills_" + Dota2Guide.Language.ActiveLanguage.Code + ".xml");
            itemsListBox.ItemsSource = DotaItem.Items.OrderBy(i=>i.Name);

            if(!DotaItem.itemsAssociated)
                DotaItem.AssociateRecipes();

            if(!DotaHero.skillsLoaded)
                DotaHero.LoadSkills();
        }

        private void HeroesStackPanel_Tap(object sender, GestureEventArgs e)
        {
            DotaHero h = heroesListBox.SelectedValue as DotaHero;
            NavigationService.Navigate(new Uri("/HeroInfoPage.xaml?hero=" + h.Link, UriKind.Relative)); 
        }

        private void ItemsStackPanel_Tap(object sender, GestureEventArgs e)
        {
            DotaItem i = itemsListBox.SelectedValue as DotaItem;
            NavigationService.Navigate(new Uri("/ItemPage.xaml?item=" + i.Link, UriKind.Relative)); 
        }

        private void NeutralsStackPanel_Tap(object sender, GestureEventArgs e)
        {
            Neutral n = neutralListBox.SelectedValue as Neutral;
            NavigationService.Navigate(new Uri("/NeutralPage.xaml?neutral=" + n.Name, UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Rate it

            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Play Paint Trek
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.windowsphone.com/en-us/store/app/paint-trek/d2901849-69e0-43d9-b57a-b73ca4e3e0a6");
            webBrowserTask.Show(); 

        }

        private void addealsButton_Click(object sender, EventArgs e)
        {
            String myWebLink = AdDealsSDKWP7.AdManager.GetWallWebLink();

            WebBrowserTask wbTask = new WebBrowserTask();
            wbTask.Uri = new Uri(myWebLink, UriKind.RelativeOrAbsolute);
            wbTask.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Color Picker Application
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.windowsphone.com/en-us/store/app/caps-color/d7ade0d0-baec-4290-ad70-79b04fba33e0");
            webBrowserTask.Show(); 
        }
    }
}
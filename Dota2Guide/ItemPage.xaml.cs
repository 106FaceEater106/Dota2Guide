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

namespace Dota2Guide
{
    public partial class ItemPage : PhoneApplicationPage
    {
        DotaItem item;
        public ItemPage()
        {
            InitializeComponent();
            //this.Loaded += new RoutedEventHandler(ItemPage_Loaded);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("item"))
            {
                //item = Item.GetItem(this.NavigationContext.QueryString["item"]);
                //item = Globals.GetItem(this.NavigationContext.QueryString["item"]);
                item = DotaItem.Items.Where(i => i.Link.Equals(NavigationContext.QueryString["item"])).SingleOrDefault();

                PageTitle.Text = item.Title;
        
                if (string.IsNullOrWhiteSpace(item.Lore))
                    loreTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Description))
                    roleTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.AllAttributes))
                    allAttributesTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Strength))
                    strengthTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Agility))
                    agilityTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Intelligence))
                    intelligenceTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Health))
                    healthTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Mana))
                    manaTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.HPRegeneration))
                    hpRegTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.ManaRegeneration))
                    manaRegTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Damage))
                    damageTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.MovementSpeed))
                    movementSpeedTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Armor))
                    armorTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.Evasion))
                    evasionTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.AttackSpeed))
                    attackSpeedTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.SpellResistance))
                    spellResistanceTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.SelectedAttribute))
                    selectedAttributeTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.CastRange))
                    castRangeTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.AttackRange))
                    attackRangeTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                if (string.IsNullOrWhiteSpace(item.ManaCost))
                {
                    manaCostTexBlock.Visibility = System.Windows.Visibility.Collapsed;
                    manaImage.Visibility = System.Windows.Visibility.Collapsed;
                }

                if (string.IsNullOrWhiteSpace(item.Cooldown))
                {
                    coolDownTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                    coolDownImage.Visibility = System.Windows.Visibility.Collapsed;
                }

                if (string.IsNullOrWhiteSpace(item.Price))
                {
                    goldImage.Visibility = System.Windows.Visibility.Collapsed;
                }

                infoStackPanel.DataContext = item;

             /*   var recipeList = new List<DotaItem>();

                if (item.RecipeList != null)
                    for (int i = 0; i < item.RecipeList.Count; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(item.RecipeList[i]))
                        {
                            if (item.RecipeList[i].Contains("Recipe"))
                                recipeList.Add(new DotaItem()
                                {
                                    Name = "Recipe",
                                    Description = "Not Defined",
                                    Image = new DotaImage() { Source = "/Dota2Guide;component/MainAttributeImage/recipe.png" }
                                });
                           
                        }
                    }
                else recipeTextBlock.Visibility = System.Windows.Visibility.Collapsed;*/

                if(!item.Recipes.Any())
                    recipeTextBlock.Visibility = System.Windows.Visibility.Collapsed;

                recipeListBox.ItemsSource = item.Recipes;
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void StackPanel_Tap(object sender, GestureEventArgs e)
        {
            DotaItem i = recipeListBox.SelectedValue as DotaItem;

            if(!i.Link.Contains("Recipe"))
                NavigationService.Navigate(new Uri("/ItemPage.xaml?item=" + i.Link, UriKind.Relative)); 
        }
    }
}
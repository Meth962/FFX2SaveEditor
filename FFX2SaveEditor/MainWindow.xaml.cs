using FFX2SaveEditor.Saves;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFX2SaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Ffx2Save save;
        MenuScreen menuScreen = MenuScreen.Main;
        PartyMember currentChar = PartyMember.Yuna;
        Dressphere currentDress = Dressphere.GunMage;

        int scroll = 0;

        #region WPF Stuff
        private void SetLightSource(FrameworkElement sender, FrameworkElement target)
        {
            var x = target.Margin.Left + target.ActualWidth / 2 - sender.Margin.Left + sender.ActualWidth / 2;
            x = Math.Max(25, x);
            var y = target.Margin.Top + target.ActualHeight / 2 - sender.Margin.Top + sender.ActualHeight / 2;
            var distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            var angle = Utils.RadianToDegree(Math.Acos(y / distance));

            ((DropShadowEffect)target.Effect).Direction = angle + 270;
            ((DropShadowEffect)target.Effect).ShadowDepth = distance / 960 * 50;
        }

        private void UpdateFocus(object sender)
        {
            if (sender == btnItems)
                lblHelp.Content = "Edit party items.";
            if (sender == btnStoryCompletion)
                lblHelp.Content = "Edit Game Completion Flags for 100%";
            if (sender == btnEquip)
                lblHelp.Content = "Edit party equipment.";
            if (sender == btnGarmentGrid)
                lblHelp.Content = "Edit garment grids.";
            if (sender == btnAccessories)
                lblHelp.Content = "Edit party accessories.";
            if (sender == btnAbilities)
                lblHelp.Content = "Edit party abilities.";
            if (sender == btnDresspheres)
                lblHelp.Content = "Edit dresspheres.";
            if (sender == btnMiniGames)
                lblHelp.Content = "Edit mini-game scores.";
            if (sender == btnSidequests)
                lblHelp.Content = "Edit side quest values such as O'aka dept, Chocobo ranch, PR and Marraige campaigns, etc.";
            if (sender == btnConfig)
                lblHelp.Content = "Change configuration of this application.";

            SetLightSource((FrameworkElement)sender, btnItems);
            SetLightSource((FrameworkElement)sender, btnStoryCompletion);
            SetLightSource((FrameworkElement)sender, btnEquip);
            SetLightSource((FrameworkElement)sender, btnGarmentGrid);
            SetLightSource((FrameworkElement)sender, btnAccessories);
            SetLightSource((FrameworkElement)sender, btnAbilities);
            SetLightSource((FrameworkElement)sender, btnDresspheres);
            SetLightSource((FrameworkElement)sender, btnMiniGames);
            SetLightSource((FrameworkElement)sender, btnSidequests);
            SetLightSource((FrameworkElement)sender, btnConfig);
            SetLightSource((FrameworkElement)sender, imgYuna);
            SetLightSource((FrameworkElement)sender, imgRikku);
            SetLightSource((FrameworkElement)sender, imgPaine);
            SetLightSource((FrameworkElement)sender, imgGilTime);
        }

        private void UpdateMainDisplay()
        {
            tbxYunaLvl.IsEnabled = true;
            tbxRikkuLvl.IsEnabled = true;
            tbxPaineLvl.IsEnabled = true;
            tbxGil.IsEnabled = true;
            tbxYunaLvl.Text = save.Characters[0].Level.ToString();
            tbxRikkuLvl.Text = save.Characters[1].Level.ToString();
            tbxPaineLvl.Text = save.Characters[2].Level.ToString();
            lblYunaDress.Content = save.Characters[0].Dressphere > Globals.Dresspheres.Length-1 ? "Invalid" : Globals.Dresspheres[save.Characters[0].Dressphere];
            lblRikkuDress.Content = save.Characters[1].Dressphere > Globals.Dresspheres.Length - 1 ? "Invalid" : Globals.Dresspheres[save.Characters[1].Dressphere];
            lblPaineDress.Content = save.Characters[2].Dressphere > Globals.Dresspheres.Length - 1 ? "Invalid" : Globals.Dresspheres[save.Characters[2].Dressphere];
            lblYunaHP.Content = $"{save.Characters[0].HP} / {save.Characters[0].MaxHP}";
            lblRikkuHP.Content = $"{save.Characters[1].HP} / {save.Characters[1].MaxHP}";
            lblPaineHP.Content = $"{save.Characters[2].HP} / {save.Characters[2].MaxHP}";
            lblYunaMP.Content = $"{save.Characters[0].MP} / {save.Characters[0].MaxMP}";
            lblRikkuMP.Content = $"{save.Characters[1].MP} / {save.Characters[1].MaxMP}";
            lblPaineMP.Content = $"{save.Characters[2].MP} / {save.Characters[2].MaxMP}";
            tbxGil.Text = save.Gil.ToString();
            tbxPlayTime.Text = $"{save.GameTime.TotalHours:0} : {save.GameTime.Minutes} : {save.GameTime.Seconds}";
        }

        private void SwitchToScreen(MenuScreen screen)
        {
            if (menuScreen == screen || save == null)
                return;

            btnItems.IsEnabled = false;
            btnStoryCompletion.IsEnabled = false;
            btnEquip.IsEnabled = false;
            btnGarmentGrid.IsEnabled = false;
            btnAccessories.IsEnabled = false;
            btnAbilities.IsEnabled = false;
            btnDresspheres.IsEnabled = false;
            btnMiniGames.IsEnabled = false;
            btnSidequests.IsEnabled = false;
            btnConfig.IsEnabled = false;

            MenuScreen current = menuScreen;
            menuScreen = screen;

            switch(current)
            {
                case MenuScreen.Main:
                    ClearMainScreen();
                    break;
                case MenuScreen.Items:
                    ClearItemScreen();
                    break;
                case MenuScreen.StoryCompletion:
                    ClearStoryScreen();
                    break;
                case MenuScreen.Equip:
                    ClearEquipScreen();
                    break;
                case MenuScreen.GarmentGrids:
                    ClearGarmentScreen();
                    break;
                case MenuScreen.Accessories:
                    ClearAccessoryScreen();
                    break;
                case MenuScreen.AbilitiesPartySelect:
                    ClearAbilitiesPartySelectScreen();
                    break;
                case MenuScreen.AbilitiesDressSelect:
                    ClearAbilitiesDressSelectScreen();
                    break;
                case MenuScreen.Abilities:
                    ClearAbilitiesScreen();
                    break;
                case MenuScreen.Dresspheres:
                    ClearDressphereScreen();
                    break;
                case MenuScreen.MiniGameSelect:
                    ClearMiniGameSelectScreen();
                    break;
                case MenuScreen.MiniGames:
                    ClearMinigameScreen();
                    break;
                case MenuScreen.Sidequests:
                    ClearSidequestScreen();
                    break;
                case MenuScreen.Config:
                    ClearConfigScreen();
                    break;
            }
        }

        private void ClearConfigScreen()
        {
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            da.Completed += SubMenuClear;
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearSidequestScreen()
        {
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            da.Completed += SubMenuClear;
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearMiniGameSelectScreen()
        {
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            da.Completed += SubMenuClear;
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearMinigameScreen()
        {
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            da.Completed += SubMenuClear;
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearDressphereScreen()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(-ActualWidth, TimeSpan.FromSeconds(0.25));
            btnAllDressTrans.BeginAnimation(TranslateTransform.YProperty, da);
            ClearGarmDressScreen(da, ts);
        }

        private void ClearAbilitiesPartySelectScreen()
        {
            var ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(-ActualWidth, TimeSpan.FromSeconds(0.25));
            if(menuScreen == MenuScreen.Main)
                btnAllAbilitiesTrans.BeginAnimation(TranslateTransform.YProperty, da);
            transPartyHeader.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transParty1.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transParty2.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            da.Completed += SubMenuClear;
            transParty3.BeginAnimation(TranslateTransform.XProperty, da);
        }

        private void ClearAbilitiesDressSelectScreen()
        {
            var ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(-ActualWidth, TimeSpan.FromSeconds(0.25));
            if (menuScreen == MenuScreen.Main)
            {
                da.To = ActualHeight;
                btnAllAbilitiesTrans.BeginAnimation(TranslateTransform.YProperty, da);
                da.To = -ActualWidth;
            }
            ClearGarmDressScreen(da, ts);
        }

        private void ClearAbilitiesScreen()
        {
            var ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));

            ClearItemAccScreen(da, ts);
        }

        private void ClearAccessoryScreen()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            btnAllAccTrans.BeginAnimation(TranslateTransform.YProperty, da);
            ClearItemAccScreen(da, ts);
        }

        private void ClearItemAccScreen(DoubleAnimation da, TimeSpan ts)
        {
            ScrollBar.Visibility = Visibility.Hidden;
            ScrollSlider.Visibility = Visibility.Hidden;
            ScrollArrowUp.Visibility = Visibility.Hidden;
            ScrollArrowDown.Visibility = Visibility.Hidden;

            if (menuScreen != MenuScreen.Abilities)
            {
                transItem22.BeginAnimation(TranslateTransform.YProperty, da);
                transItem21.BeginAnimation(TranslateTransform.YProperty, da);
                da.BeginTime += ts;
                transItem20.BeginAnimation(TranslateTransform.YProperty, da);
                transItem19.BeginAnimation(TranslateTransform.YProperty, da);
                da.BeginTime += ts;
                transItem18.BeginAnimation(TranslateTransform.YProperty, da);
                transItem17.BeginAnimation(TranslateTransform.YProperty, da);
                da.BeginTime += ts;
            }
            transItem16.BeginAnimation(TranslateTransform.YProperty, da);
            transItem15.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem14.BeginAnimation(TranslateTransform.YProperty, da);
            transItem13.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem12.BeginAnimation(TranslateTransform.YProperty, da);
            transItem11.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem10.BeginAnimation(TranslateTransform.YProperty, da);
            transItem9.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem8.BeginAnimation(TranslateTransform.YProperty, da);
            transItem7.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem6.BeginAnimation(TranslateTransform.YProperty, da);
            transItem5.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem4.BeginAnimation(TranslateTransform.YProperty, da);
            transItem3.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem1.BeginAnimation(TranslateTransform.YProperty, da);
            transItem2.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItemHeader1.BeginAnimation(TranslateTransform.YProperty, da);
            da.Completed += SubMenuClear;
            transItemHeader2.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearGarmentScreen()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(-ActualWidth, TimeSpan.FromSeconds(0.25));
            btnAllGarmTrans.BeginAnimation(TranslateTransform.YProperty, da);
            ClearGarmDressScreen(da, ts);
        }

        private void ClearGarmDressScreen(DoubleAnimation da, TimeSpan ts)
        {
            ScrollBar.Visibility = Visibility.Hidden;
            ScrollSlider.Visibility = Visibility.Hidden;
            ScrollArrowUp.Visibility = Visibility.Hidden;
            ScrollArrowDown.Visibility = Visibility.Hidden;

            transDress11.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress10.BeginAnimation(TranslateTransform.XProperty, da);
            transDress9.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress8.BeginAnimation(TranslateTransform.XProperty, da);
            transDress7.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress6.BeginAnimation(TranslateTransform.XProperty, da);
            transDress5.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress4.BeginAnimation(TranslateTransform.XProperty, da);
            transDress3.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress1.BeginAnimation(TranslateTransform.XProperty, da);
            transDress2.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            da.Completed += SubMenuClear;
            transDressHeader.BeginAnimation(TranslateTransform.XProperty, da);
        }

        private void ClearEquipScreen()
        {
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            da.Completed += SubMenuClear;
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearStoryScreen()
        {
            DoubleAnimation da = new DoubleAnimation(ActualHeight, TimeSpan.FromSeconds(0.25));
            transStoryTree.BeginAnimation(TranslateTransform.YProperty, da);
            btnAllStoryTrans.BeginAnimation(TranslateTransform.YProperty, da);
            da.Completed += SubMenuClear;
            transStoryComplete.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void ClearMainScreen()
        {
            tbxPlayTime.Visibility = Visibility.Hidden;
            tbxGil.Visibility = Visibility.Hidden;

            if (menuScreen != MenuScreen.AbilitiesPartySelect)
            {
                lblPaineHP.Visibility = Visibility.Hidden;
                tbxPaineLvl.Visibility = Visibility.Hidden;
                lblPaineMP.Visibility = Visibility.Hidden;
                lblRikkuHP.Visibility = Visibility.Hidden;
                tbxRikkuLvl.Visibility = Visibility.Hidden;
                lblRikkuMP.Visibility = Visibility.Hidden;
                lblYunaHP.Visibility = Visibility.Hidden;
                tbxYunaLvl.Visibility = Visibility.Hidden;
                lblYunaMP.Visibility = Visibility.Hidden;
                lblPaineDress.Visibility = Visibility.Hidden;
                lblRikkuDress.Visibility = Visibility.Hidden;
                lblYunaDress.Visibility = Visibility.Hidden;
            }

            DoubleAnimation dau = new DoubleAnimation(0, 0,TimeSpan.FromSeconds(0.25));
            transItems.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transStoryCompletion.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transEquip.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transGarmentGrid.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transAbilities.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transAccessories.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transDresspheres.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transMiniGames.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transSidequests.BeginAnimation(TranslateTransform.YProperty, dau);
            dau.BeginTime += TimeSpan.FromMilliseconds(18); dau.To -= 70;
            transConfig.BeginAnimation(TranslateTransform.YProperty, dau);

            DoubleAnimation dar = new DoubleAnimation(ActualWidth, TimeSpan.FromSeconds(0.25));
            if (menuScreen == MenuScreen.AbilitiesPartySelect) dar.To = 0;
            transYuna.BeginAnimation(TranslateTransform.XProperty, dar);
            dar.BeginTime += TimeSpan.FromMilliseconds(18);
            if (menuScreen == MenuScreen.AbilitiesPartySelect) dar.To = 158;
            transRikku.BeginAnimation(TranslateTransform.XProperty, dar);
            dar.BeginTime += TimeSpan.FromMilliseconds(18);
            if (menuScreen == MenuScreen.AbilitiesPartySelect) dar.To = 252;
            transPaine.BeginAnimation(TranslateTransform.XProperty, dar);
            dar.BeginTime += TimeSpan.FromMilliseconds(18);
            dar.Completed += MenuCleared;
            dar.To = ActualWidth;
            transGilTime.BeginAnimation(TranslateTransform.XProperty, dar);
        }

        private void MenuCleared(object sender, EventArgs e)
        {
            btnItems.Visibility = Visibility.Hidden;
            btnStoryCompletion.Visibility = Visibility.Hidden;
            btnEquip.Visibility = Visibility.Hidden;
            btnGarmentGrid.Visibility = Visibility.Hidden;
            btnAccessories.Visibility = Visibility.Hidden;
            btnAbilities.Visibility = Visibility.Hidden;
            btnDresspheres.Visibility = Visibility.Hidden;
            btnMiniGames.Visibility = Visibility.Hidden;
            btnSidequests.Visibility = Visibility.Hidden;
            btnConfig.Visibility = Visibility.Hidden;
           
            switch (menuScreen)
            {
                case MenuScreen.Items:
                    btnItems.Visibility = Visibility.Visible;
                    DisplayItemScreen();
                    break;
                case MenuScreen.StoryCompletion:
                    btnStoryCompletion.Visibility = Visibility.Visible;
                    DisplayStoryScreen();
                    break;
                case MenuScreen.Equip:
                    btnEquip.Visibility = Visibility.Visible;
                    DisplayEquipScreen();
                    break;
                case MenuScreen.GarmentGrids:
                    btnGarmentGrid.Visibility = Visibility.Visible;
                    DisplayGarmentScreen();
                    break;
                case MenuScreen.Accessories:
                    btnAccessories.Visibility = Visibility.Visible;
                    DisplayAccessoryScreen();
                    break;
                case MenuScreen.AbilitiesPartySelect:
                    btnAbilities.Visibility = Visibility.Visible;
                    DisplayAbilityPartySelectScreen();
                    break;
                case MenuScreen.Dresspheres:
                    btnDresspheres.Visibility = Visibility.Visible;
                    DisplayDressphereScreen();
                    break;
                case MenuScreen.MiniGameSelect:
                    btnMiniGames.Visibility = Visibility.Visible;
                    DisplayMinigameScreen();
                    break;
                case MenuScreen.Sidequests:
                    btnSidequests.Visibility = Visibility.Visible;
                    DisplaySidequestScreen();
                    break;
                case MenuScreen.Config:
                    btnConfig.Visibility = Visibility.Visible;
                    DisplayConfigScreen();
                    break;
                default:
                    break;
            }
        }

        private void DisplayMainScreen()
        {
            SwitchToScreen(MenuScreen.Main);

            menuScreen = MenuScreen.Main;
            btnItems.Visibility = Visibility.Visible;
            btnStoryCompletion.Visibility = Visibility.Visible;
            btnEquip.Visibility = Visibility.Visible;
            btnGarmentGrid.Visibility = Visibility.Visible;
            btnAccessories.Visibility = Visibility.Visible;
            btnAbilities.Visibility = Visibility.Visible;
            btnDresspheres.Visibility = Visibility.Visible;
            btnMiniGames.Visibility = Visibility.Visible;
            btnSidequests.Visibility = Visibility.Visible;
            btnConfig.Visibility = Visibility.Visible;

            DoubleAnimation dad = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            transItems.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transStoryCompletion.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transEquip.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transGarmentGrid.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transAbilities.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transAccessories.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transDresspheres.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transMiniGames.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transSidequests.BeginAnimation(TranslateTransform.YProperty, dad);
            dad.BeginTime += TimeSpan.FromMilliseconds(18);
            transConfig.BeginAnimation(TranslateTransform.YProperty, dad);

            DoubleAnimation dar = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            transYuna.BeginAnimation(TranslateTransform.XProperty, dar);
            dar.BeginTime += TimeSpan.FromMilliseconds(18);
            transRikku.BeginAnimation(TranslateTransform.XProperty, dar);
            transRikku.BeginAnimation(TranslateTransform.YProperty, dar);
            dar.BeginTime += TimeSpan.FromMilliseconds(18);
            transPaine.BeginAnimation(TranslateTransform.XProperty, dar);
            transPaine.BeginAnimation(TranslateTransform.YProperty, dar);
            dar.BeginTime += TimeSpan.FromMilliseconds(18);
            dar.Completed += MainMenuLoaded;
            transGilTime.BeginAnimation(TranslateTransform.XProperty, dar);
        }

        private void MainMenuLoaded(object sender, EventArgs e)
        {
            btnItems.IsEnabled = true;
            btnStoryCompletion.IsEnabled = true;
            btnEquip.IsEnabled = true;
            btnGarmentGrid.IsEnabled = true;
            btnAccessories.IsEnabled = true;
            btnAbilities.IsEnabled = true;
            btnDresspheres.IsEnabled = true;
            btnMiniGames.IsEnabled = true;
            btnSidequests.IsEnabled = true;
            btnConfig.IsEnabled = true;
            tbxGil.Visibility = Visibility.Visible;
            lblPaineHP.Visibility = Visibility.Visible;
            tbxPaineLvl.Visibility = Visibility.Visible;
            lblPaineMP.Visibility = Visibility.Visible;
            tbxPlayTime.Visibility = Visibility.Visible;
            lblRikkuHP.Visibility = Visibility.Visible;
            tbxRikkuLvl.Visibility = Visibility.Visible;
            lblRikkuMP.Visibility = Visibility.Visible;
            lblYunaHP.Visibility = Visibility.Visible;
            tbxYunaLvl.Visibility = Visibility.Visible;
            lblYunaMP.Visibility = Visibility.Visible;
            lblPaineDress.Visibility = Visibility.Visible;
            lblRikkuDress.Visibility = Visibility.Visible;
            lblYunaDress.Visibility = Visibility.Visible;
        }

        private void ClearItemScreen()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(this.ActualHeight, TimeSpan.FromSeconds(0.25));
            btnAllItemsTrans.BeginAnimation(TranslateTransform.YProperty, da);
            ClearItemAccScreen(da, ts);
        }

        private void SubMenuClear(object sender, EventArgs e)
        {
            Console.WriteLine("SubMenuCleared()");
            switch(menuScreen)
            {
                case MenuScreen.AbilitiesDressSelect:
                    DisplayAbilityDressSelectScreen();
                    break;
                case MenuScreen.Abilities:
                    DisplayAbilitiesScreen();
                    break;
                default:
                    DisplayMainScreen();
                    break;
            }
        }

        private void ResetScrollBar(object sender, EventArgs e)
        {
            ScrollBar.Visibility = Visibility.Visible;
            ScrollSlider.Visibility = Visibility.Visible;
            Canvas.SetTop(ScrollSlider, scroll);
            ScrollArrowUp.Visibility = Visibility.Hidden;
            ScrollArrowDown.Visibility = Visibility.Visible;
            ScrollCanvas.Visibility = Visibility.Visible;
        }

        private void DisplayItemScreen()
        {
            btnItems.IsEnabled = true;
            itemHeader1.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/ItemHeader.png"));
            itemHeader2.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/ItemHeader.png"));

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            da.Completed += ResetScrollBar;
            btnAllItemsTrans.BeginAnimation(TranslateTransform.YProperty, da);
            DisplayItemAccScreen(da, ts);

            UpdateItemScreen();
        }

        private void UpdateItemScreen()
        { 
            txtItem1.Text = Globals.Items[save.Items[0+scroll,0]];
            txtItemQty1.Text = save.Items[0+scroll, 1].ToString();
            txtItem2.Text = Globals.Items[save.Items[1+scroll, 0]];
            txtItemQty2.Text = save.Items[1+scroll, 1].ToString();
            txtItem3.Text = Globals.Items[save.Items[2+scroll, 0]];
            txtItemQty3.Text = save.Items[2+scroll, 1].ToString();
            txtItem4.Text = Globals.Items[save.Items[3+scroll, 0]];
            txtItemQty4.Text = save.Items[3+scroll, 1].ToString();
            txtItem5.Text = Globals.Items[save.Items[4+scroll, 0]];
            txtItemQty5.Text = save.Items[4+scroll, 1].ToString();
            txtItem6.Text = Globals.Items[save.Items[5+scroll, 0]];
            txtItemQty6.Text = save.Items[5+scroll, 1].ToString();
            txtItem7.Text = Globals.Items[save.Items[6+scroll, 0]];
            txtItemQty7.Text = save.Items[6+scroll, 1].ToString();
            txtItem8.Text = Globals.Items[save.Items[7+scroll, 0]];
            txtItemQty8.Text = save.Items[7+scroll, 1].ToString();
            txtItem9.Text = Globals.Items[save.Items[8+scroll, 0]];
            txtItemQty9.Text = save.Items[8+scroll, 1].ToString();
            txtItem10.Text = Globals.Items[save.Items[9+scroll, 0]];
            txtItemQty10.Text = save.Items[9+scroll, 1].ToString();
            txtItem11.Text = Globals.Items[save.Items[10+scroll, 0]];
            txtItemQty11.Text = save.Items[10+scroll, 1].ToString();
            txtItem12.Text = Globals.Items[save.Items[11+scroll, 0]];
            txtItemQty12.Text = save.Items[11+scroll, 1].ToString();
            txtItem13.Text = Globals.Items[save.Items[12+scroll, 0]];
            txtItemQty13.Text = save.Items[12+scroll, 1].ToString();
            txtItem14.Text = Globals.Items[save.Items[13+scroll, 0]];
            txtItemQty14.Text = save.Items[13+scroll, 1].ToString();
            txtItem15.Text = Globals.Items[save.Items[14+scroll, 0]];
            txtItemQty15.Text = save.Items[14+scroll, 1].ToString();
            txtItem16.Text = Globals.Items[save.Items[15+scroll, 0]];
            txtItemQty16.Text = save.Items[15+scroll, 1].ToString();
            txtItem17.Text = Globals.Items[save.Items[16+scroll, 0]];
            txtItemQty17.Text = save.Items[16+scroll, 1].ToString();
            txtItem18.Text = Globals.Items[save.Items[17+scroll, 0]];
            txtItemQty18.Text = save.Items[17+scroll, 1].ToString();
            txtItem19.Text = Globals.Items[save.Items[18+scroll, 0]];
            txtItemQty19.Text = save.Items[18+scroll, 1].ToString();
            txtItem20.Text = Globals.Items[save.Items[19+scroll, 0]];
            txtItemQty20.Text = save.Items[19+scroll, 1].ToString();
            txtItem21.Text = Globals.Items[save.Items[20+scroll, 0]];
            txtItemQty21.Text = save.Items[20+scroll, 1].ToString();
            txtItem22.Text = Globals.Items[save.Items[21+scroll, 0]];
            txtItemQty22.Text = save.Items[21+scroll, 1].ToString();

            iconItem1.Source = GetItmIcon(0 + scroll);
            iconItem2.Source = GetItmIcon(1 + scroll);
            iconItem3.Source = GetItmIcon(2 + scroll);
            iconItem4.Source = GetItmIcon(3 + scroll);
            iconItem5.Source = GetItmIcon(4 + scroll);
            iconItem6.Source = GetItmIcon(5 + scroll);
            iconItem7.Source = GetItmIcon(6 + scroll);
            iconItem8.Source = GetItmIcon(7 + scroll);
            iconItem9.Source = GetItmIcon(8 + scroll);
            iconItem10.Source = GetItmIcon(9 + scroll);
            iconItem11.Source = GetItmIcon(10 + scroll);
            iconItem12.Source = GetItmIcon(11 + scroll);
            iconItem13.Source = GetItmIcon(12 + scroll);
            iconItem14.Source = GetItmIcon(13 + scroll);
            iconItem15.Source = GetItmIcon(14 + scroll);
            iconItem16.Source = GetItmIcon(15 + scroll);
            iconItem17.Source = GetItmIcon(16 + scroll);
            iconItem18.Source = GetItmIcon(17 + scroll);
            iconItem19.Source = GetItmIcon(18 + scroll);
            iconItem20.Source = GetItmIcon(19 + scroll);
            iconItem21.Source = GetItmIcon(20 + scroll);
            iconItem22.Source = GetItmIcon(21 + scroll);

            txtItemQty1.Background = null;
            txtItemQty2.Background = null;
            txtItemQty3.Background = null;
            txtItemQty4.Background = null;
            txtItemQty5.Background = null;
            txtItemQty6.Background = null;
            txtItemQty7.Background = null;
            txtItemQty8.Background = null;
            txtItemQty9.Background = null;
            txtItemQty10.Background = null;
            txtItemQty11.Background = null;
            txtItemQty12.Background = null;
            txtItemQty13.Background = null;
            txtItemQty14.Background = null;
            txtItemQty15.Background = null;
            txtItemQty16.Background = null;
            txtItemQty17.Background = null;
            txtItemQty18.Background = null;
            txtItemQty19.Background = null;
            txtItemQty20.Background = null;
            txtItemQty21.Background = null;
            txtItemQty22.Background = null;

            UpdateItemColors();
        }

        private void UpdateItemColors()
        {
            txtItem1.Foreground = txtItemQty1.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem2.Foreground = txtItemQty2.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem3.Foreground = txtItemQty3.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem4.Foreground = txtItemQty4.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem5.Foreground = txtItemQty5.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem6.Foreground = txtItemQty6.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem7.Foreground = txtItemQty7.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem8.Foreground = txtItemQty8.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem9.Foreground = txtItemQty9.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem10.Foreground = txtItemQty10.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem11.Foreground = txtItemQty11.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem12.Foreground = txtItemQty12.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem13.Foreground = txtItemQty13.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem14.Foreground = txtItemQty14.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem15.Foreground = txtItemQty15.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem16.Foreground = txtItemQty16.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem17.Foreground = txtItemQty17.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem18.Foreground = txtItemQty18.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem19.Foreground = txtItemQty19.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem20.Foreground = txtItemQty20.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem21.Foreground = txtItemQty21.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtItem22.Foreground = txtItemQty22.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
        }

        private ImageSource GetItmIcon(int index)
        {
            if (save.Items[index, 0] == 0xff) return null;

            switch (Globals.ItemTypes[save.Items[index, 0]])
            {
                default:
                case 0:
                    return new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Resources/Potion.png"));
                case 1:
                    return new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Resources/Orb.png"));
                case 2:
                    return new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Resources/Misc.png"));
            }
        }

        private void DisplayItemAccScreen(DoubleAnimation da, TimeSpan ts)
        {
            scroll = 0;

            transItemHeader1.BeginAnimation(TranslateTransform.YProperty, da);
            transItemHeader2.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem1.BeginAnimation(TranslateTransform.YProperty, da);
            transItem2.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem3.BeginAnimation(TranslateTransform.YProperty, da);
            transItem4.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem5.BeginAnimation(TranslateTransform.YProperty, da);
            transItem6.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem7.BeginAnimation(TranslateTransform.YProperty, da);
            transItem8.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem9.BeginAnimation(TranslateTransform.YProperty, da);
            transItem10.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem11.BeginAnimation(TranslateTransform.YProperty, da);
            transItem12.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem13.BeginAnimation(TranslateTransform.YProperty, da);
            transItem14.BeginAnimation(TranslateTransform.YProperty, da);
            da.BeginTime += ts;
            transItem15.BeginAnimation(TranslateTransform.YProperty, da);
            transItem16.BeginAnimation(TranslateTransform.YProperty, da);
            if (menuScreen != MenuScreen.Abilities)
            {
                da.BeginTime += ts;
                transItem17.BeginAnimation(TranslateTransform.YProperty, da);
                transItem18.BeginAnimation(TranslateTransform.YProperty, da);
                da.BeginTime += ts;
                transItem19.BeginAnimation(TranslateTransform.YProperty, da);
                transItem20.BeginAnimation(TranslateTransform.YProperty, da);
                da.BeginTime += ts;
                transItem21.BeginAnimation(TranslateTransform.YProperty, da);
                transItem22.BeginAnimation(TranslateTransform.YProperty, da);
            }

            ScrollBar.Visibility = Visibility.Visible;
            ScrollSlider.Visibility = Visibility.Visible;
        }

        private void DisplayStoryScreen()
        {
            UpdateFlags();
            lblHelp.Content = "Double click item to change value. Doing so on a header will clear all flags under it.";
            btnStoryCompletion.IsEnabled = true;
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15));
            transStoryTree.BeginAnimation(TranslateTransform.YProperty, da);
            btnAllStoryTrans.BeginAnimation(TranslateTransform.YProperty, da);
            transStoryComplete.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void DisplayEquipScreen()
        {
            btnEquip.IsEnabled = true;
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15));
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void DisplayGarmentScreen()
        {
            btnGarmentGrid.IsEnabled = true;

            dressHeader.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/GarmentHeader.png"));

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            da.Completed += ResetScrollBar;
            btnAllGarmTrans.BeginAnimation(TranslateTransform.YProperty, da);
            DisplayGarmDressScreen(da, ts);

            UpdateGarmentScreen();
        }

        private void UpdateGarmentScreen()
        {
            iconDress1.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress2.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress3.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress4.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress5.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress6.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress7.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress8.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress9.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress10.Source = new BitmapImage(Globals.GarmentIcon);
            iconDress11.Source = new BitmapImage(Globals.GarmentIcon);

            txtDress1.Text = Globals.GarmentGrids[0+scroll];
            txtDress2.Text = Globals.GarmentGrids[1+scroll];
            txtDress3.Text = Globals.GarmentGrids[2+scroll];
            txtDress4.Text = Globals.GarmentGrids[3+scroll];
            txtDress5.Text = Globals.GarmentGrids[4+scroll];
            txtDress6.Text = Globals.GarmentGrids[5+scroll];
            txtDress7.Text = Globals.GarmentGrids[6+scroll];
            txtDress8.Text = Globals.GarmentGrids[7+scroll];
            txtDress9.Text = Globals.GarmentGrids[8+scroll];
            txtDress10.Text = Globals.GarmentGrids[9+scroll];
            txtDress11.Text = Globals.GarmentGrids[10+scroll];

            txtDressQty1.Text = save.GarmentGrids[0+scroll] ? "1" : "0";
            txtDressQty2.Text = save.GarmentGrids[1+scroll] ? "1" : "0";
            txtDressQty3.Text = save.GarmentGrids[2+scroll] ? "1" : "0";
            txtDressQty4.Text = save.GarmentGrids[3+scroll] ? "1" : "0";
            txtDressQty5.Text = save.GarmentGrids[4+scroll] ? "1" : "0";
            txtDressQty6.Text = save.GarmentGrids[5+scroll] ? "1" : "0";
            txtDressQty7.Text = save.GarmentGrids[6+scroll] ? "1" : "0";
            txtDressQty8.Text = save.GarmentGrids[7+scroll] ? "1" : "0";
            txtDressQty9.Text = save.GarmentGrids[8+scroll] ? "1" : "0";
            txtDressQty10.Text = save.GarmentGrids[9+scroll] ? "1" : "0";
            txtDressQty11.Text = save.GarmentGrids[10+scroll] ? "1" : "0";

            txtDress1.Foreground = txtDressQty1.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress2.Foreground = txtDressQty2.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress3.Foreground = txtDressQty3.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress4.Foreground = txtDressQty4.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress5.Foreground = txtDressQty5.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress6.Foreground = txtDressQty6.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress7.Foreground = txtDressQty7.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress8.Foreground = txtDressQty8.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress9.Foreground = txtDressQty9.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress10.Foreground = txtDressQty10.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress11.Foreground = txtDressQty11.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
        }

        private void DisplayGarmDressScreen(DoubleAnimation da, TimeSpan ts)
        {
            scroll = 0;
            
            transDressHeader.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress1.BeginAnimation(TranslateTransform.XProperty, da);
            transDress2.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress3.BeginAnimation(TranslateTransform.XProperty, da);
            transDress4.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress5.BeginAnimation(TranslateTransform.XProperty, da);
            transDress6.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress7.BeginAnimation(TranslateTransform.XProperty, da);
            transDress8.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress9.BeginAnimation(TranslateTransform.XProperty, da);
            transDress10.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transDress11.BeginAnimation(TranslateTransform.XProperty, da);
        }

        private void DisplayAccessoryScreen()
        {
            itemHeader1.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/AccessoryHeader.png"));
            itemHeader2.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/AccessoryHeader.png"));

            btnAccessories.IsEnabled = true;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            da.Completed += ResetScrollBar;
            btnAllAccTrans.BeginAnimation(TranslateTransform.YProperty, da);
            DisplayItemAccScreen(da, ts);

            UpdateAccessoryScreen();
        }

        private void UpdateAccessoryScreen()
        {
            txtItemQty1.Background = null;
            txtItemQty2.Background = null;
            txtItemQty3.Background = null;
            txtItemQty4.Background = null;
            txtItemQty5.Background = null;
            txtItemQty6.Background = null;
            txtItemQty7.Background = null;
            txtItemQty8.Background = null;
            txtItemQty9.Background = null;
            txtItemQty10.Background = null;
            txtItemQty11.Background = null;
            txtItemQty12.Background = null;
            txtItemQty13.Background = null;
            txtItemQty14.Background = null;
            txtItemQty15.Background = null;
            txtItemQty16.Background = null;
            
            txtItem1.Text = Globals.Accessories[save.Accessories[0+scroll, 0]];
            txtItemQty1.Text = save.Accessories[0+scroll, 1].ToString();
            txtItem2.Text = Globals.Accessories[save.Accessories[1+scroll, 0]];
            txtItemQty2.Text = save.Accessories[1+scroll, 1].ToString();
            txtItem3.Text = Globals.Accessories[save.Accessories[2+scroll, 0]];
            txtItemQty3.Text = save.Accessories[2+scroll, 1].ToString();
            txtItem4.Text = Globals.Accessories[save.Accessories[3+scroll, 0]];
            txtItemQty4.Text = save.Accessories[3+scroll, 1].ToString();
            txtItem5.Text = Globals.Accessories[save.Accessories[4+scroll, 0]];
            txtItemQty5.Text = save.Accessories[4+scroll, 1].ToString();
            txtItem6.Text = Globals.Accessories[save.Accessories[5+scroll, 0]];
            txtItemQty6.Text = save.Accessories[5+scroll, 1].ToString();
            txtItem7.Text = Globals.Accessories[save.Accessories[6+scroll, 0]];
            txtItemQty7.Text = save.Accessories[6+scroll, 1].ToString();
            txtItem8.Text = Globals.Accessories[save.Accessories[7+scroll, 0]];
            txtItemQty8.Text = save.Accessories[7+scroll, 1].ToString();
            txtItem9.Text = Globals.Accessories[save.Accessories[8+scroll, 0]];
            txtItemQty9.Text = save.Accessories[8+scroll, 1].ToString();
            txtItem10.Text = Globals.Accessories[save.Accessories[9+scroll, 0]];
            txtItemQty10.Text = save.Accessories[9+scroll, 1].ToString();
            txtItem11.Text = Globals.Accessories[save.Accessories[10+scroll, 0]];
            txtItemQty11.Text = save.Accessories[10+scroll, 1].ToString();
            txtItem12.Text = Globals.Accessories[save.Accessories[11+scroll, 0]];
            txtItemQty12.Text = save.Accessories[11+scroll, 1].ToString();
            txtItem13.Text = Globals.Accessories[save.Accessories[12+scroll, 0]];
            txtItemQty13.Text = save.Accessories[12+scroll, 1].ToString();
            txtItem14.Text = Globals.Accessories[save.Accessories[13+scroll, 0]];
            txtItemQty14.Text = save.Accessories[13+scroll, 1].ToString();
            txtItem15.Text = Globals.Accessories[save.Accessories[14+scroll, 0]];
            txtItemQty15.Text = save.Accessories[14+scroll, 1].ToString();
            txtItem16.Text = Globals.Accessories[save.Accessories[15+scroll, 0]];
            txtItemQty16.Text = save.Accessories[15+scroll, 1].ToString();
            txtItem17.Text = Globals.Accessories[save.Accessories[16+scroll, 0]];
            txtItemQty17.Text = save.Accessories[16+scroll, 1].ToString();
            txtItem18.Text = Globals.Accessories[save.Accessories[17+scroll, 0]];
            txtItemQty18.Text = save.Accessories[17+scroll, 1].ToString();
            txtItem19.Text = Globals.Accessories[save.Accessories[18+scroll, 0]];
            txtItemQty19.Text = save.Accessories[18+scroll, 1].ToString();
            txtItem20.Text = Globals.Accessories[save.Accessories[19+scroll, 0]];
            txtItemQty20.Text = save.Accessories[19+scroll, 1].ToString();
            txtItem21.Text = Globals.Accessories[save.Accessories[20+scroll, 0]];
            txtItemQty21.Text = save.Accessories[20+scroll, 1].ToString();
            txtItem22.Text = Globals.Accessories[save.Accessories[21+scroll, 0]];
            txtItemQty22.Text = save.Accessories[21+scroll, 1].ToString();

            iconItem1.Source = GetAccIcon(0+scroll);
            iconItem2.Source = GetAccIcon(1+scroll);
            iconItem3.Source = GetAccIcon(2+scroll);
            iconItem4.Source = GetAccIcon(3+scroll);
            iconItem5.Source = GetAccIcon(4+scroll);
            iconItem6.Source = GetAccIcon(5+scroll);
            iconItem7.Source = GetAccIcon(6+scroll);
            iconItem8.Source = GetAccIcon(7+scroll);
            iconItem9.Source = GetAccIcon(8+scroll);
            iconItem10.Source = GetAccIcon(9+scroll);
            iconItem11.Source = GetAccIcon(10+scroll);
            iconItem12.Source = GetAccIcon(11+scroll);
            iconItem13.Source = GetAccIcon(12+scroll);
            iconItem14.Source = GetAccIcon(13+scroll);
            iconItem15.Source = GetAccIcon(14+scroll);
            iconItem16.Source = GetAccIcon(15+scroll);
            iconItem17.Source = GetAccIcon(16+scroll);
            iconItem18.Source = GetAccIcon(17+scroll);
            iconItem19.Source = GetAccIcon(18+scroll);
            iconItem20.Source = GetAccIcon(19+scroll);
            iconItem21.Source = GetAccIcon(20+scroll);
            iconItem22.Source = GetAccIcon(21+scroll);

            UpdateItemColors();
        }

        private void DisplayAbilitiesScreen()
        {
            itemHeader1.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/AbilitiesHeader.png"));
            itemHeader2.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/AbilitiesHeader.png"));

            ScrollBar.Visibility = Visibility.Hidden;
            ScrollSlider.Visibility = Visibility.Hidden;
            ScrollArrowUp.Visibility = Visibility.Hidden;
            ScrollArrowDown.Visibility = Visibility.Hidden;
            ScrollCanvas.Visibility = Visibility.Hidden;

            btnAbilities.IsEnabled = true;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(171, TimeSpan.FromSeconds(0.25));
            
            btnAllAbilitiesTrans.BeginAnimation(TranslateTransform.YProperty, da);
            DisplayItemAccScreen(da, ts);

            UpdateAbilitiesScreen();
        }

        private void UpdateAbilitiesScreen()
        {
            var abilities = save.Characters[(byte)currentChar].Abilities.Where(a => a.Dressphere == (byte)currentDress).ToList();
            if (abilities.Count == 0) return;

            txtItem1.Text = abilities[0].Name;
            txtItemQty1.Text = abilities[0].Mastered ? "" : abilities[0].Ap + "/" + abilities[0].MaxAp;
            txtItem2.Text = abilities[1].Name;
            txtItemQty2.Text = abilities[1].Mastered ? "" : abilities[1].Ap + "/" + abilities[1].MaxAp;
            txtItem3.Text = abilities[2].Name;
            txtItemQty3.Text = abilities[2].Mastered ? "" : abilities[2].Ap + "/" + abilities[2].MaxAp;
            txtItem4.Text = abilities[3].Name;
            txtItemQty4.Text = abilities[3].Mastered ? "" : abilities[3].Ap + "/" + abilities[3].MaxAp;
            txtItem5.Text = abilities[4].Name;
            txtItemQty5.Text = abilities[4].Mastered ? "" : abilities[4].Ap + "/" + abilities[4].MaxAp;
            txtItem6.Text = abilities[5].Name;
            txtItemQty6.Text = abilities[5].Mastered ? "" : abilities[5].Ap + "/" + abilities[5].MaxAp;
            txtItem7.Text = abilities[6].Name;
            txtItemQty7.Text = abilities[6].Mastered ? "" : abilities[6].Ap + "/" + abilities[6].MaxAp;
            txtItem8.Text = abilities[7].Name;
            txtItemQty8.Text = abilities[7].Mastered ? "" : abilities[7].Ap + "/" + abilities[7].MaxAp;
            txtItem9.Text = abilities[8].Name;
            txtItemQty9.Text = abilities[8].Mastered ? "" : abilities[8].Ap + "/" + abilities[8].MaxAp;
            txtItem10.Text = abilities[9].Name;
            txtItemQty10.Text = abilities[9].Mastered ? "" : abilities[9].Ap + "/" + abilities[9].MaxAp;
            txtItem11.Text = abilities[10].Name;
            txtItemQty11.Text = abilities[10].Mastered ? "" : abilities[10].Ap + "/" + abilities[10].MaxAp;
            txtItem12.Text = abilities[11].Name;
            txtItemQty12.Text = abilities[11].Mastered ? "" : abilities[11].Ap + "/" + abilities[11].MaxAp;
            txtItem13.Text = abilities[12].Name;
            txtItemQty13.Text = abilities[12].Mastered ? "" : abilities[12].Ap + "/" + abilities[12].MaxAp;
            txtItem14.Text = abilities[13].Name;
            txtItemQty14.Text = abilities[13].Mastered ? "" : abilities[13].Ap + "/" + abilities[13].MaxAp;
            txtItem15.Text = abilities[14].Name;
            txtItemQty15.Text = abilities[14].Mastered ? "" : abilities[14].Ap + "/" + abilities[14].MaxAp;
            txtItem16.Text = abilities[15].Name;
            txtItemQty16.Text = abilities[15].Mastered ? "" : abilities[15].Ap + "/" + abilities[15].MaxAp;

            iconItem1.Source = new BitmapImage(Globals.AbilityIcons[abilities[0].Type]);
            iconItem2.Source = new BitmapImage(Globals.AbilityIcons[abilities[1].Type]);
            iconItem3.Source = new BitmapImage(Globals.AbilityIcons[abilities[2].Type]);
            iconItem4.Source = new BitmapImage(Globals.AbilityIcons[abilities[3].Type]);
            iconItem5.Source = new BitmapImage(Globals.AbilityIcons[abilities[4].Type]);
            iconItem6.Source = new BitmapImage(Globals.AbilityIcons[abilities[5].Type]);
            iconItem7.Source = new BitmapImage(Globals.AbilityIcons[abilities[6].Type]);
            iconItem8.Source = new BitmapImage(Globals.AbilityIcons[abilities[7].Type]);
            iconItem9.Source = new BitmapImage(Globals.AbilityIcons[abilities[8].Type]);
            iconItem10.Source = new BitmapImage(Globals.AbilityIcons[abilities[9].Type]);
            iconItem11.Source = new BitmapImage(Globals.AbilityIcons[abilities[10].Type]);
            iconItem12.Source = new BitmapImage(Globals.AbilityIcons[abilities[11].Type]);
            iconItem13.Source = new BitmapImage(Globals.AbilityIcons[abilities[12].Type]);
            iconItem14.Source = new BitmapImage(Globals.AbilityIcons[abilities[13].Type]);
            iconItem15.Source = new BitmapImage(Globals.AbilityIcons[abilities[14].Type]);
            iconItem16.Source = new BitmapImage(Globals.AbilityIcons[abilities[15].Type]);

            if (abilities[0].Mastered) txtItemQty1.Background = Globals.MasteredBrush; else txtItemQty1.Background = null;
            if (abilities[1].Mastered) txtItemQty2.Background = Globals.MasteredBrush; else txtItemQty2.Background = null;
            if (abilities[2].Mastered) txtItemQty3.Background = Globals.MasteredBrush; else txtItemQty3.Background = null;
            if (abilities[3].Mastered) txtItemQty4.Background = Globals.MasteredBrush; else txtItemQty4.Background = null;
            if (abilities[4].Mastered) txtItemQty5.Background = Globals.MasteredBrush; else txtItemQty5.Background = null;
            if (abilities[5].Mastered) txtItemQty6.Background = Globals.MasteredBrush; else txtItemQty6.Background = null;
            if (abilities[6].Mastered) txtItemQty7.Background = Globals.MasteredBrush; else txtItemQty7.Background = null;
            if (abilities[7].Mastered) txtItemQty8.Background = Globals.MasteredBrush; else txtItemQty8.Background = null;
            if (abilities[8].Mastered) txtItemQty9.Background = Globals.MasteredBrush; else txtItemQty9.Background = null;
            if (abilities[9].Mastered) txtItemQty10.Background = Globals.MasteredBrush; else txtItemQty10.Background = null;
            if (abilities[10].Mastered) txtItemQty11.Background = Globals.MasteredBrush; else txtItemQty11.Background = null;
            if (abilities[11].Mastered) txtItemQty12.Background = Globals.MasteredBrush; else txtItemQty12.Background = null;
            if (abilities[12].Mastered) txtItemQty13.Background = Globals.MasteredBrush; else txtItemQty13.Background = null;
            if (abilities[13].Mastered) txtItemQty14.Background = Globals.MasteredBrush; else txtItemQty14.Background = null;
            if (abilities[14].Mastered) txtItemQty15.Background = Globals.MasteredBrush; else txtItemQty15.Background = null;
            if (abilities[15].Mastered) txtItemQty16.Background = Globals.MasteredBrush; else txtItemQty16.Background = null;

            // Create an ImageBrush.
            //ImageBrush textImageBrush = new ImageBrush();
            //textImageBrush.ImageSource = new BitmapImage(Globals.MasteredIcon);
            //textImageBrush.AlignmentX = AlignmentX.Left;
            //textImageBrush.Stretch = Stretch.None;
            // Use the brush to paint the button's background.
            //myTextBox.Background = textImageBrush;

            //UpdateAbilityColors();
        }

        private ImageSource GetAccIcon(int index)
        {
            if (save.Accessories[index, 0] == 0xff) return null;

            switch(Globals.AccessoryType[save.Accessories[index,0]])
            {
                default:
                case 0:
                    return new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Resources/BronzeAccessory.png"));
                case 1:
                    return new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Resources/SilverAccessory.png"));
                case 2:
                    return new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/Resources/GoldAccessory.png"));
            }
        }

        private void DisplayAbilityPartySelectScreen()
        {
            btnAbilities.IsEnabled = true;
            var ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15));
            transPartyHeader.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transParty1.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transParty2.BeginAnimation(TranslateTransform.XProperty, da);
            da.BeginTime += ts;
            transParty3.BeginAnimation(TranslateTransform.XProperty, da);
        }

        private void DisplayAbilityDressSelectScreen()
        {
            btnAbilities.IsEnabled = true;
            dressHeader.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/DressphereHeader.png"));

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 250);
            DoubleAnimation dax = new DoubleAnimation(ActualWidth, ts);
            if(currentChar != PartyMember.Yuna)
                transYuna.BeginAnimation(TranslateTransform.XProperty, dax);
            if (currentChar != PartyMember.Rikku)
                transRikku.BeginAnimation(TranslateTransform.XProperty, dax);
            if (currentChar != PartyMember.Paine)
                transPaine.BeginAnimation(TranslateTransform.XProperty, dax);

            // Move selected character up
            DoubleAnimation day;
            switch (currentChar)
            {
                case PartyMember.Rikku:
                    day = new DoubleAnimation(-179, ts);
                    transRikku.BeginAnimation(TranslateTransform.YProperty, day);
                    break;
                case PartyMember.Paine:
                    day = new DoubleAnimation(-358, ts);
                    transPaine.BeginAnimation(TranslateTransform.YProperty, day);
                    break;
            }

            ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(171, TimeSpan.FromSeconds(0.25));
            btnAllAbilitiesTrans.BeginAnimation(TranslateTransform.YProperty, da);
            da.To = 0;
            da.Completed += ResetScrollBar;
            DisplayGarmDressScreen(da, ts);

            UpdateAbilityDressScreen();
        }

        private void DisplayDressphereScreen()
        {
            btnDresspheres.IsEnabled = true;
            dressHeader.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "/FFX2SaveEditor;component/Resources/DressphereHeader.png"));

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            da.Completed += ResetScrollBar;
            btnAllDressTrans.BeginAnimation(TranslateTransform.YProperty, da);
            DisplayGarmDressScreen(da, ts);

            UpdateDressphereScreen();
        }

        private void UpdateDressphereScreen()
        {
            iconDress1.Source = new BitmapImage(Globals.DressIcons[0 + scroll]);
            iconDress2.Source = new BitmapImage(Globals.DressIcons[1 + scroll]);
            iconDress3.Source = new BitmapImage(Globals.DressIcons[2 + scroll]);
            iconDress4.Source = new BitmapImage(Globals.DressIcons[3 + scroll]);
            iconDress5.Source = new BitmapImage(Globals.DressIcons[4 + scroll]);
            iconDress6.Source = new BitmapImage(Globals.DressIcons[5 + scroll]);
            iconDress7.Source = new BitmapImage(Globals.DressIcons[6 + scroll]);
            iconDress8.Source = new BitmapImage(Globals.DressIcons[7 + scroll]);
            iconDress9.Source = new BitmapImage(Globals.DressIcons[8 + scroll]);
            iconDress10.Source = new BitmapImage(Globals.DressIcons[9 + scroll]);
            iconDress11.Source = new BitmapImage(Globals.DressIcons[10 + scroll]);

            txtDress1.Text = Globals.Dresspheres[0+scroll];
            txtDress2.Text = Globals.Dresspheres[1+scroll];
            txtDress3.Text = Globals.Dresspheres[2+scroll];
            txtDress4.Text = Globals.Dresspheres[3+scroll];
            txtDress5.Text = Globals.Dresspheres[4+scroll];
            txtDress6.Text = Globals.Dresspheres[5+scroll];
            txtDress7.Text = Globals.Dresspheres[6+scroll];
            txtDress8.Text = Globals.Dresspheres[7+scroll];
            txtDress9.Text = Globals.Dresspheres[8+scroll];
            txtDress10.Text = Globals.Dresspheres[9+scroll];
            txtDress11.Text = Globals.Dresspheres[10+scroll];

            txtDressQty1.Text = save.Dresspheres[0+scroll].ToString();
            txtDressQty2.Text = save.Dresspheres[1+scroll].ToString();
            txtDressQty3.Text = save.Dresspheres[2+scroll].ToString();
            txtDressQty4.Text = save.Dresspheres[3+scroll].ToString();
            txtDressQty5.Text = save.Dresspheres[4+scroll].ToString();
            txtDressQty6.Text = save.Dresspheres[5+scroll].ToString();
            txtDressQty7.Text = save.Dresspheres[6+scroll].ToString();
            txtDressQty8.Text = save.Dresspheres[7+scroll].ToString();
            txtDressQty9.Text = save.Dresspheres[8+scroll].ToString();
            txtDressQty10.Text = save.Dresspheres[9+scroll].ToString();
            txtDressQty11.Text = save.Dresspheres[10+scroll].ToString();

            txtDress1.Foreground = txtDressQty1.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress2.Foreground = txtDressQty2.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress3.Foreground = txtDressQty3.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress4.Foreground = txtDressQty4.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress5.Foreground = txtDressQty5.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress6.Foreground = txtDressQty6.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress7.Foreground = txtDressQty7.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress8.Foreground = txtDressQty8.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress9.Foreground = txtDressQty9.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress10.Foreground = txtDressQty10.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
            txtDress11.Foreground = txtDressQty11.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
        }

        private void UpdateAbilityDressScreen()
        {
            txtDress1.Foreground = Globals.WhiteBrush;
            txtDress2.Foreground = Globals.WhiteBrush;
            txtDress3.Foreground = Globals.WhiteBrush;
            txtDress4.Foreground = Globals.WhiteBrush;
            txtDress5.Foreground = Globals.WhiteBrush;
            txtDress6.Foreground = Globals.WhiteBrush;
            txtDress7.Foreground = Globals.WhiteBrush;
            txtDress8.Foreground = Globals.WhiteBrush;
            txtDress9.Foreground = Globals.WhiteBrush;
            txtDress10.Foreground = Globals.WhiteBrush;
            txtDress11.Foreground = Globals.WhiteBrush;

            txtDress1.Text = Globals.Dresspheres[0 + scroll];
            txtDress2.Text = Globals.Dresspheres[1 + scroll];
            txtDress3.Text = Globals.Dresspheres[2 + scroll];
            txtDress4.Text = Globals.Dresspheres[3 + scroll];
            txtDress5.Text = Globals.Dresspheres[4 + scroll];
            txtDress6.Text = Globals.Dresspheres[5 + scroll];
            txtDress7.Text = Globals.Dresspheres[6 + scroll];
            txtDress8.Text = Globals.Dresspheres[7 + scroll];
            txtDress9.Text = Globals.Dresspheres[8 + scroll];
            txtDress10.Text = Globals.Dresspheres[9 + scroll];
            txtDress11.Text = Globals.Dresspheres[10 + scroll];

            gridDress1.Tag = txtDress1.Text;
            gridDress2.Tag = txtDress2.Text;
            gridDress3.Tag = txtDress3.Text;
            gridDress4.Tag = txtDress4.Text;
            gridDress5.Tag = txtDress5.Text;
            gridDress6.Tag = txtDress6.Text;
            gridDress7.Tag = txtDress7.Text;
            gridDress8.Tag = txtDress8.Text;
            gridDress9.Tag = txtDress9.Text;
            gridDress10.Tag = txtDress10.Text;
            gridDress11.Tag = txtDress11.Text;

            iconDress1.Source = new BitmapImage(Globals.DressIcons[0 + scroll]);
            iconDress2.Source = new BitmapImage(Globals.DressIcons[1 + scroll]);
            iconDress3.Source = new BitmapImage(Globals.DressIcons[2 + scroll]);
            iconDress4.Source = new BitmapImage(Globals.DressIcons[3 + scroll]);
            iconDress5.Source = new BitmapImage(Globals.DressIcons[4 + scroll]);
            iconDress6.Source = new BitmapImage(Globals.DressIcons[5 + scroll]);
            iconDress7.Source = new BitmapImage(Globals.DressIcons[6 + scroll]);
            iconDress8.Source = new BitmapImage(Globals.DressIcons[7 + scroll]);
            iconDress9.Source = new BitmapImage(Globals.DressIcons[8 + scroll]);
            iconDress10.Source = new BitmapImage(Globals.DressIcons[9 + scroll]);
            iconDress11.Source = new BitmapImage(Globals.DressIcons[10 + scroll]);

            var abilities = new int[11];
            for(int i = 0; i < abilities.Length;i++)
                abilities[i] = save.Characters[(byte)currentChar].Abilities.Count(a => a.Dressphere == 1 + i + scroll && a.Mastered == true);
            txtDressQty1.Text = abilities[0]*100/16 + "%";
            txtDressQty2.Text = abilities[1]*100/16 + "%";
            txtDressQty3.Text = abilities[2]*100/16 + "%";
            txtDressQty4.Text = abilities[3]*100/16 + "%";
            txtDressQty5.Text = abilities[4]*100/16 + "%";
            txtDressQty6.Text = abilities[5]*100/16 + "%";
            txtDressQty7.Text = abilities[6]*100/16 + "%";
            txtDressQty8.Text = abilities[7]*100/16 + "%";
            txtDressQty9.Text = abilities[8]*100/16 + "%";
            txtDressQty10.Text = abilities[9]*100/16 + "%";
            txtDressQty11.Text = abilities[10]*100/16 + "%";
        }

        private void UpdateMiniGameSelectScreen()
        {
            iconDress1.Source = null;
            iconDress2.Source = null;
            iconDress3.Source = null;
            iconDress4.Source = null;
            iconDress5.Source = null;
            iconDress6.Source = null;
            iconDress7.Source = null;
            iconDress8.Source = null;
            iconDress9.Source = null;
            iconDress10.Source =null;
            iconDress11.Source =null;

            txtDress1.Text = "Calm Lands";
            txtDress2.Text = "Thunder Plains";
            txtDress3.Text = "Bikanel Desert";
            txtDress4.Text = "Besaid";
            txtDress5.Text = "Chocobo Dungeon";
            txtDress6.Text = "Mt. Gagazet";
            txtDress7.Text = "Miscellaneous";
            txtDress8.Text = "";
            txtDress9.Text = "";
            txtDress10.Text = "";
            txtDress11.Text = "";

            txtDressQty1.Text = "";
            txtDressQty2.Text = "";
            txtDressQty3.Text = "";
            txtDressQty4.Text = "";
            txtDressQty5.Text = "";
            txtDressQty6.Text = "";
            txtDressQty7.Text = "";
            txtDressQty8.Text = "";
            txtDressQty9.Text = "";
            txtDressQty10.Text ="";
            txtDressQty11.Text ="";
        }

        private void DisplayMinigameScreen()
        {
            btnMiniGames.IsEnabled = true;
            dressHeader.Source = null;

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, 25);
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.25));
            da.Completed += ResetScrollBar;
            
            DisplayGarmDressScreen(da, ts);

            UpdateMiniGameSelectScreen();
        }

        private void DisplaySidequestScreen()
        {
            btnSidequests.IsEnabled = true;
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15));
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private void DisplayConfigScreen()
        {
            btnConfig.IsEnabled = true;
            DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromSeconds(0.15));
            transUnderConstruction.BeginAnimation(TranslateTransform.YProperty, da);
        }

        private TreeViewItem FindChild(TreeViewItem parent, string name)
        {
            foreach (TreeViewItem item in parent.Items)
            {
                if (item.Header.ToString() == name)
                    return item;
            }

            return null;
        }

        private void MainPage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var max = 0d;
            switch (menuScreen)
            {
                case MenuScreen.Items:
                case MenuScreen.Accessories:
                    max = 128d;
                    if (e.Delta < 0 && scroll <= max - 2)
                        scroll += 2;
                    else if (e.Delta > 0 && scroll > 1)
                        scroll -= 2;

                    ScrollArrowUp.Visibility = scroll == 0 ? Visibility.Hidden : Visibility.Visible;
                    ScrollArrowDown.Visibility = scroll == max ? Visibility.Hidden : Visibility.Visible;

                    Canvas.SetTop(ScrollSlider, scroll / max * (ScrollBar.Height - ScrollSlider.Height));
                    break;
                case MenuScreen.Dresspheres:
                case MenuScreen.GarmentGrids:
                case MenuScreen.AbilitiesDressSelect:
                    switch (menuScreen)
                    {
                        case MenuScreen.Dresspheres:
                            max = 18;
                            break;
                        case MenuScreen.GarmentGrids:
                            max = 53;
                            break;
                        case MenuScreen.AbilitiesDressSelect:
                            max = 18;
                            break;
                    }

                    if (e.Delta < 0 && scroll < max)
                        scroll++;
                    else if (e.Delta > 0 && scroll > 0)
                        scroll--;

                    ScrollArrowUp.Visibility = scroll == 0 ? Visibility.Hidden : Visibility.Visible;
                    ScrollArrowDown.Visibility = scroll == max ? Visibility.Hidden : Visibility.Visible;

                    Canvas.SetTop(ScrollSlider, scroll / max * (ScrollBar.Height - ScrollSlider.Height));
                    break;
            }

            switch (menuScreen)
            {
                case MenuScreen.Items:
                    UpdateItemScreen();
                    break;
                case MenuScreen.Accessories:
                    UpdateAccessoryScreen();
                    break;
                case MenuScreen.GarmentGrids:
                    UpdateGarmentScreen();
                    break;
                case MenuScreen.Dresspheres:
                    UpdateDressphereScreen();
                    break;
                case MenuScreen.AbilitiesDressSelect:
                    UpdateAbilityDressScreen();
                    break;
            }
        }

        private void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.End)
            {
                switch (menuScreen)
                {
                    case MenuScreen.Items:
                    case MenuScreen.Accessories:
                        scroll = 128;
                        break;
                    case MenuScreen.Dresspheres:
                    case MenuScreen.AbilitiesDressSelect:
                        scroll = 18;
                        break;
                    case MenuScreen.GarmentGrids:
                        scroll = 53;
                        break;
                }

                ScrollArrowUp.Visibility = Visibility.Visible;
                ScrollArrowDown.Visibility = Visibility.Hidden;

                Canvas.SetTop(ScrollSlider, ScrollBar.Height - ScrollSlider.Height);

                switch (menuScreen)
                {
                    case MenuScreen.Items:
                        UpdateItemScreen();
                        break;
                    case MenuScreen.Accessories:
                        UpdateAccessoryScreen();
                        break;
                    case MenuScreen.GarmentGrids:
                        UpdateGarmentScreen();
                        break;
                    case MenuScreen.Dresspheres:
                        UpdateDressphereScreen();
                        break;
                    case MenuScreen.AbilitiesDressSelect:
                        UpdateAbilityDressScreen();
                        break;
                }
            }
            if (e.Key == Key.Home)
            {
                scroll = 0;

                ScrollArrowUp.Visibility = Visibility.Hidden;
                ScrollArrowDown.Visibility = Visibility.Visible;

                Canvas.SetTop(ScrollSlider, scroll);

                switch (menuScreen)
                {
                    case MenuScreen.Items:
                        UpdateItemScreen();
                        break;
                    case MenuScreen.Accessories:
                        UpdateAccessoryScreen();
                        break;
                    case MenuScreen.GarmentGrids:
                        UpdateGarmentScreen();
                        break;
                    case MenuScreen.Dresspheres:
                        UpdateDressphereScreen();
                        break;
                    case MenuScreen.AbilitiesDressSelect:
                        UpdateAbilityDressScreen();
                        break;
                }
            }
        }
        #endregion

        #region FormEvents
        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            UpdateFocus(sender);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            UpdateFocus(sender);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            DisplayMainScreen();
            OpenFile();
        }

        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.Items)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Items);
        }

        private void btnStoryCompletion_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.StoryCompletion)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.StoryCompletion);
        }

        private void btnAccessories_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (menuScreen == MenuScreen.Accessories)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Accessories);
        }

        private void btnEquip_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.Equip)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Equip);
        }

        private void btnGarmentGrid_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.GarmentGrids)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.GarmentGrids);
        }

        private void btnAccessories_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.Accessories)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Accessories);
        }

        private void btnAbilities_Click(object sender, RoutedEventArgs e)
        {
            switch (menuScreen)
            {
                case MenuScreen.AbilitiesPartySelect:
                    SwitchToScreen(MenuScreen.Main);
                    break;
                case MenuScreen.Main:
                case MenuScreen.AbilitiesDressSelect:
                    SwitchToScreen(MenuScreen.AbilitiesPartySelect);
                    break;
                case MenuScreen.Abilities:
                    SwitchToScreen(MenuScreen.AbilitiesDressSelect);
                    break;
            }
        }

        private void btnDresspheres_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.Dresspheres)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Dresspheres);
        }

        private void btnDresspheres_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (menuScreen == MenuScreen.Dresspheres)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Dresspheres);
        }

        private void btnMiniGames_Click(object sender, RoutedEventArgs e)
        {
            /*
            switch (menuScreen)
            {
                case MenuScreen.MiniGameSelect:
                    SwitchToScreen(MenuScreen.Main);
                    break;
                case MenuScreen.Main:
                case MenuScreen.MiniGames:
                    SwitchToScreen(MenuScreen.MiniGameSelect);
                    break;
            }
            */
        }

        private void btnSidequests_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (menuScreen == MenuScreen.Sidequests)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Sidequests);
            */
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            if (menuScreen == MenuScreen.Config)
                SwitchToScreen(MenuScreen.Main);
            else
                SwitchToScreen(MenuScreen.Config);
        }

        private void item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            var grid = (Grid)sender;
            switch (menuScreen)
            {
                case MenuScreen.Items:
                    EditOneItem(grid);
                    break;
                case MenuScreen.Accessories:
                    EditOneAccessory(grid);
                    break;
                case MenuScreen.GarmentGrids:
                    EditOneGarment(grid);
                    break;
                case MenuScreen.Dresspheres:
                    EditOneDressphere(grid);
                    break;
                case MenuScreen.AbilitiesPartySelect:
                    currentChar = (PartyMember)Enum.Parse(typeof(PartyMember), grid.Tag.ToString());
                    SwitchToScreen(MenuScreen.AbilitiesDressSelect);
                    break;
                case MenuScreen.AbilitiesDressSelect:
                    currentDress = (Dressphere)Enum.Parse(typeof(Dressphere),grid.Tag.ToString().Replace(" ","").Replace("-",""));
                    SwitchToScreen(MenuScreen.Abilities);
                    break;
                case MenuScreen.Abilities:
                    EditOneAbility(grid);
                    break;
                case MenuScreen.MiniGameSelect:
                    EditMinigame(grid);
                    break;
            }
        }

        private void EditOneItem(Grid sender)
        { 
            var dialog = new ItemSelect(MenuType.Items);
            var icon = ((Image)((sender).Children[0]));
            var item = ((TextBlock)((sender).Children[1]));
            var qty = ((TextBlock)(sender).Children[2]);
            var index = int.Parse((sender).Name.Substring(7));
            index += scroll-1;
            dialog.cbxItem.SelectedValue = Globals.Items.First(i => i.Value == item.Text).Key;
            dialog.tbxQuantity.Text = qty.Text;
            if (dialog.ShowDialog() == true)
            {
                item.Text = Globals.Items[dialog.ItemId];
                qty.Text = dialog.Quantity.ToString();
                item.Foreground = qty.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
                save.Items[index, 0] = dialog.ItemId;
                save.Items[index, 1] = dialog.Quantity;
                icon.Source = GetItmIcon(index);
                save.WriteItem((byte)index);
            }
        }

        private void EditOneAccessory(Grid sender)
        {
            var dialog = new ItemSelect(MenuType.Accessories);
            var icon = ((Image)((sender).Children[0]));
            var item = ((TextBlock)((sender).Children[1]));
            var qty = ((TextBlock)(sender).Children[2]);
            var index = byte.Parse((sender).Name.Substring(7));
            index--;
            dialog.cbxItem.SelectedValue = Globals.Accessories.First(i => i.Value == item.Text).Key;
            dialog.tbxQuantity.Text = qty.Text;
            if (dialog.ShowDialog() == true)
            {
                item.Text = Globals.Accessories[dialog.ItemId];
                qty.Text = dialog.Quantity.ToString();
                save.Accessories[index, 0] = dialog.ItemId;
                save.Accessories[index, 1] = dialog.Quantity;
                item.Foreground = qty.Text == "0" ? Globals.GrayBrush : Globals.WhiteBrush;
                icon.Source = GetAccIcon(index);
                save.WriteAccessory(index);
            }
        }

        private void EditOneGarment(Grid sender)
        {
            var wpfSucks = sender.Children;
            var item = (TextBlock)(sender.Children[1]);
            var qty = ((TextBlock)((sender).Children[2]));
            var index = int.Parse((sender).Name.Substring(9));
            index += scroll-1;
            if (qty.Text == "0") qty.Text = "1";
            else qty.Text = "0";
            item.Foreground = (qty.Text == "0") ? new SolidColorBrush(Color.FromRgb(55,55,55)) : new SolidColorBrush(Color.FromRgb(225,225,225));
            save.GarmentGrids[index] = !save.GarmentGrids[index];
            save.WriteGarmentGrids();
        }

        private void EditOneDressphere(Grid sender)
        {
            var dialog = new ItemSelect(MenuType.Dressphere);
            var item = ((TextBlock)(sender).Children[1]);
            var qty = ((TextBlock)(sender).Children[2]);
            var index = int.Parse((sender).Name.Substring(9));
            index+=scroll-1;

            // If we don't have it, let's just add 1 instead of opening the form
            if (qty.Text == "0")
            {
                qty.Text = "1";
                item.Foreground = Globals.WhiteBrush;
                save.Dresspheres[index] = 1;
                save.WriteDressphere((byte)index);
            }
            else
            {
                dialog.cbxItem.Text = Globals.Dresspheres[index];
                dialog.tbxQuantity.Text = qty.Text;
                if (dialog.ShowDialog() == true)
                {
                    qty.Text = dialog.Quantity.ToString();
                    item.Foreground = dialog.Quantity == 0 ? Globals.GrayBrush : Globals.WhiteBrush;
                    save.Dresspheres[index] = dialog.Quantity;
                    save.WriteDresspheres();
                }
            }
        }

        private void EditOneAbility(Grid sender)
        {
            var index = byte.Parse(sender.Name.Substring(7));
            index--;
            var ability = save.Characters[(byte)currentChar].Abilities.Where(a => a.Dressphere == (byte)currentDress).Skip(index).Take(1).FirstOrDefault();
            ability.Ap = ability.MaxAp;
            save.WriteAbility((byte)currentChar, ability);
            UpdateAbilitiesScreen();
        }

        private void EditMinigame(Grid sender)
        {
            var index = byte.Parse(sender.Name.Substring(9));
            index--;
            switch(index)
            {
                case 0:
                    EditCalmLandsMiniGames();
                    break;
                case 1:
                    EditThunderPlainsMiniGames();
                    break;
            }
        }

        private void EditCalmLandsMiniGames()
        {
            var form = new CalmLands();
            form.OpenAirCredits = save.OpenAirCredits;
            form.OpenAirPoints = save.OpenAirPoints;
            form.ArgentCredits = save.ArgentCredits;
            form.ArgentPoints = save.ArgentPoints;
            form.MarraigePoints = save.MarraigePoints;
            form.CreditsCh5 = save.SlCredits;
            form.Credits2Ch5 = save.SlCredits5;
            form.HoverRides = save.HoverRides;

            if(form.ShowDialog() == true)
            {
                save.OpenAirCredits = form.OpenAirCredits;
                save.OpenAirPoints = form.OpenAirPoints;
                save.ArgentCredits = form.ArgentCredits;
                save.ArgentPoints = form.ArgentPoints;
                save.MarraigePoints = form.MarraigePoints;
                save.SlCredits = form.CreditsCh5;
                save.SlCredits5 = form.Credits2Ch5;
            }
        }

        private void EditThunderPlainsMiniGames()
        {
            var form = new ThunderPlains();
            form.Tower1Calibrated = save.TowerCalibrations[0];
            form.Tower2Calibrated = save.TowerCalibrations[1];
            form.Tower3Calibrated = save.TowerCalibrations[2];
            form.Tower4Calibrated = save.TowerCalibrations[3];
            form.Tower5Calibrated = save.TowerCalibrations[4];
            form.Tower6Calibrated = save.TowerCalibrations[5];
            form.Tower7Calibrated = save.TowerCalibrations[6];
            form.Tower8Calibrated = save.TowerCalibrations[7];
            form.Tower9Calibrated = save.TowerCalibrations[8];
            form.Tower10Calibrated = save.TowerCalibrations[9];
            form.Tower1Attempts = save.TowerAttempts[0];
            form.Tower2Attempts = save.TowerAttempts[1];
            form.Tower3Attempts = save.TowerAttempts[2];
            form.Tower4Attempts = save.TowerAttempts[3];
            form.Tower5Attempts = save.TowerAttempts[4];
            form.Tower6Attempts = save.TowerAttempts[5];
            form.Tower7Attempts = save.TowerAttempts[6];
            form.Tower8Attempts = save.TowerAttempts[7];
            form.Tower9Attempts = save.TowerAttempts[8];
            form.Tower10Attempts = save.TowerAttempts[9];

            if(form.ShowDialog() == true)
            {
                save.TowerCalibrations[0] = form.Tower1Calibrated;
                save.TowerCalibrations[1] = form.Tower2Calibrated;
                save.TowerCalibrations[2] = form.Tower3Calibrated;
                save.TowerCalibrations[3] = form.Tower4Calibrated;
                save.TowerCalibrations[4] = form.Tower5Calibrated;
                save.TowerCalibrations[5] = form.Tower6Calibrated;
                save.TowerCalibrations[6] = form.Tower7Calibrated;
                save.TowerCalibrations[7] = form.Tower8Calibrated;
                save.TowerCalibrations[8] = form.Tower9Calibrated;
                save.TowerCalibrations[9] = form.Tower10Calibrated;
                save.TowerAttempts[0] = form.Tower1Attempts;
                save.TowerAttempts[1] = form.Tower1Attempts;
                save.TowerAttempts[2] = form.Tower1Attempts;
                save.TowerAttempts[3] = form.Tower1Attempts;
                save.TowerAttempts[4] = form.Tower1Attempts;
                save.TowerAttempts[5] = form.Tower1Attempts;
                save.TowerAttempts[6] = form.Tower1Attempts;
                save.TowerAttempts[7] = form.Tower1Attempts;
                save.TowerAttempts[8] = form.Tower1Attempts;
                save.TowerAttempts[9] = form.Tower1Attempts;
            }
        }

        private void btnAllItems_Click(object sender, RoutedEventArgs e)
        {
            for (byte i = 0; i < 67; i++)
            {
                save.Items[i, 0] = i;
                save.Items[i, 1] = 99;
            }

            save.WriteItems();
            DisplayItemScreen();
        }

        private void btnAllAccessories_Click(object sender, RoutedEventArgs e)
        {
            for (byte i = 0; i < 128; i++)
            {
                save.Accessories[i, 0] = i;
                save.Accessories[i, 1] = 99;
            }

            save.WriteAccessories();
            DisplayAccessoryScreen();
        }

        private void btnAllGarments_Click(object sender, RoutedEventArgs e)
        {
            save.GarmentGrids = save.GarmentGrids.Select(g => { g = true; return g; }).ToArray();

            save.WriteGarmentGrids();
            UpdateGarmentScreen();
        }

        private void btnAllDress_Click(object sender, RoutedEventArgs e)
        {
            for (byte i = 0; i < save.Dresspheres.Length; i++)
            {
                save.Dresspheres[i] = 99;
            }

            save.WriteDresspheres();
            UpdateDressphereScreen();
        }

        private void btnAllAbilities_Click(object sender, RoutedEventArgs e)
        {
            switch(menuScreen)
            {
                case MenuScreen.AbilitiesDressSelect:
                    foreach (var ability in save.Characters[(byte)currentChar].Abilities)
                    {
                        ability.Ap = ability.MaxAp;
                        save.WriteAbility((byte)currentChar, ability);
                    }
                    UpdateAbilityDressScreen();
                    break;
                case MenuScreen.Abilities:
                    var abilities = save.Characters[(byte)currentChar].Abilities.Where(a => a.Dressphere == (byte)currentDress).ToList();
                    foreach (var ability in abilities)
                    {
                        ability.Ap = ability.MaxAp;
                        save.WriteAbility((byte)currentChar, ability);
                    }
                    UpdateAbilitiesScreen();
                    break;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void trvStory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (TreeViewItem)((TreeView)sender).SelectedItem;
            if (item == null) return;

            switch ((string)item.Tag)
            {
                case "Chapter":
                    foreach (TreeViewItem location in item.Items)
                    {
                        foreach (TreeViewItem flag in location.Items)
                        {
                            RemoveFlag((StoryFlag)flag.Header);
                        }
                    }
                    break;
                case "Location":
                    foreach (TreeViewItem flag in item.Items)
                    {
                        RemoveFlag((StoryFlag)flag.Header);
                    }
                    break;
                default:
                    RemoveFlag((StoryFlag)item.Header);
                    break;
            }

            UpdateFlags();
        }

        private void trvStory_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.OriginalSource as TreeViewItem;

            if (item == null || e.Handled) return;

            item.IsExpanded = !item.IsExpanded;
            e.Handled = true;
        }

        private void btnAllStory_Click(object sender, RoutedEventArgs e)
        {
            save.MissingFlags.Clear();
            save.Requisites.Clear();
            UpdateFlags();
        }

        private void tbxGil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    save.Gil = int.Parse(tbxGil.Text);
                    save.WriteGil();
                    btnSave.Focus();
                }
                catch
                {
                    tbxGil.Text = save.Gil.ToString();
                }
            }
        }
        #endregion

        private void LoadAllFlags()
        {
            trvStory.Items.Clear();
            var chapters = new List<TreeViewItem>() {
                new TreeViewItem() { Header = "Chapter 1", Tag="Chapter", FontSize=28},
                new TreeViewItem() { Header = "Chapter 2", Tag="Chapter", FontSize=28},
                new TreeViewItem() { Header = "Chapter 3", Tag="Chapter", FontSize=28},
                new TreeViewItem() { Header = "Chapter 4", Tag="Chapter", FontSize=28},
                new TreeViewItem() { Header = "Chapter 5", Tag="Chapter", FontSize=28} 
            };

            foreach(var flag in GameInfo.Flags)
            {
                var c = flag.Chapter % 6 - 1;
                var place = FindChild(chapters[c], flag.Location);
                if (place == null)
                {
                    place = new TreeViewItem() { Header = flag.Location, Tag="Location", FontSize=18 };
                    chapters[c].Items.Add(place);
                }

                place.Items.Add(new TreeViewItem() { Tag = flag.Address + ":" + flag.Value, Header = flag, FontSize = 14, HorizontalAlignment = HorizontalAlignment.Left, Width = 742, Height = 57 });
            }

            foreach (var item in chapters)
                trvStory.Items.Add(item);
        }

        private void RemoveFlag(StoryFlag flag)
        {
            save.StoryFlagBytes[flag.Address] ^= flag.Value;
            save.MissingFlags.Remove(flag);
            save.WriteStoryFlag(flag.Address, save.StoryFlagBytes[flag.Address]);
        }

        private void UpdateFlags()
        {
            trvStory.Items.Clear();

            ushort[] chapterCounts = new ushort[7];
            List<TreeViewItem> chapters = new List<TreeViewItem>()
            {
                new TreeViewItem() { Header="Unknown", Tag="Chapter", FontSize=24 },
                new TreeViewItem() { Header="Chapter 1", Tag="Chapter", FontSize=24 },
                new TreeViewItem() { Header="Chapter 2", Tag="Chapter", FontSize=24 },
                new TreeViewItem() { Header="Chapter 3", Tag="Chapter", FontSize=24 },
                new TreeViewItem() { Header="Chapter 4", Tag="Chapter", FontSize=24 },
                new TreeViewItem() { Header="Chapter 5", Tag="Chapter", FontSize=24 },
                new TreeViewItem() { Header="Requisites", Tag="Chapter", FontSize=24 }
            };
            List<TreeViewItem> subHeaders = new List<TreeViewItem>()
            {
                new TreeViewItem() { Header="Chapter 1", Tag="Chapter", FontSize=18 },
                new TreeViewItem() { Header="Chapter 2", Tag="Chapter", FontSize=18 },
                new TreeViewItem() { Header="Chapter 3", Tag="Chapter", FontSize=18 },
                new TreeViewItem() { Header="Chapter 4", Tag="Chapter", FontSize=18 },
                new TreeViewItem() { Header="Chapter 5", Tag="Chapter", FontSize=18 }
            };

            foreach (var f in save.MissingFlags)
            {
                var item = new TreeViewItem() { Tag = f.Address + ":" + f.Value, Header = f, FontSize = 14, HorizontalAlignment = HorizontalAlignment.Left, Width = 762, Height = 57 };

                if (f.Faction > 0 && f.Faction != save.Faction)// && chkFactions.IsChecked != true)
                    continue;
                if (f.Chapter <= 5)
                {
                    var place = FindChild(chapters[f.Chapter], f.Location);
                    if (place == null)
                    {
                        place = new TreeViewItem() { Header = f.Location, Tag = "Location", FontSize = 18 };
                        chapters[f.Chapter].Items.Add(place);
                    }
                    chapterCounts[f.Chapter]++;
                    place.Items.Add(item);
                }
                else
                {
                    chapterCounts[0]++;
                    chapters[0].Items.Add(item);
                }
            }

            foreach (var f in save.Requisites)
            {
                var item = new TreeViewItem() { Tag = f.Address + ":" + f.Value, Header = f, FontSize = 14, HorizontalAlignment = HorizontalAlignment.Left, Width = 742, Height = 57 };
                chapterCounts[6]++;
                subHeaders[f.Chapter - 1].Items.Add(item);
            }
            foreach (var h in subHeaders)
            {
                if (h.Items.Count > 0)
                    chapters[6].Items.Add(h);
            }

            for (byte h = 1; h < chapters.Count - 1; h++)
            {
                chapters[h].Header += string.Format(" - Missing: {0}/{1}", chapterCounts[h], GameInfo.ChapterTotals[h - 1]);
                if (chapters[h].Items.Count > 0)
                    trvStory.Items.Add(chapters[h]);
            }

            if (chapters[0].Items.Count > 0)
            {
                chapters[0].Header += string.Format(" - Missing: {0}", chapterCounts[0]);
                trvStory.Items.Add(chapters[0]);
            }
            if (chapters[6].Items.Count > 0)
            {
                chapters[6].Header += string.Format(" - Missing: {0}", chapterCounts[6]);
                trvStory.Items.Add(chapters[6]);
            }

            lblStoryComplete.Text = $"Completion: {(525-save.MissingFlags.Count)*100/500.0:n1}%";
            //pbCompletion.Value = total - flags;
        }

        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "PC saves, Raw files (*.*)|*.*|PS3 Saves (*.PFD,*.SFO,*.*)|*.PFD;*.SFO;*.*";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            if (!(bool)ofd.ShowDialog())
                return;

            if (ofd.FileNames.Count() == 3)
                save = new Ps3Save(ofd.FileNames);
            else
                save = new PcSave(ofd.FileName);

            UpdateMainDisplay();
        }

        private void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (save is Ps3Save)
            {
                sfd.FileName = "SAVES";
                sfd.Filter = "PS3 SAVES Data|*.*";
            }
            else if (save is PcSave)
            {
                sfd.FileName = ((PcSave)save).OriginalName;
                sfd.Filter = "PC Save Data|*.*";
            }

            if (!(bool)sfd.ShowDialog())
                return;

            save.SaveFile(sfd.FileName);
        }

        private void textboxLevel_TextChanged(object sender, TextChangedEventArgs e)
        {
            var c = byte.Parse(((TextBox)sender).Tag.ToString());
            var tbx = (TextBox)sender;

            try
            {
                var lvl = byte.Parse(tbx.Text);
                save.Characters[c].Level = lvl;
                save.WriteCharLevel(c);
            }
            catch
            {
                tbx.Text = save.Characters[c].Level.ToString();
            }
        }

        private void textboxNum2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            bool oversized = false;

            if (!string.IsNullOrWhiteSpace(e.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
                oversized = textBox.Text.Length + e.Text.Length - textBox.SelectionLength > 2;

            e.Handled = oversized || Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void textboxNum2_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var tbx = (TextBox)sender;
            if (string.IsNullOrEmpty(tbx.Text)) return;

            var num = int.Parse(tbx.Text);
            if (e.Delta < 0 && num > 0)
                num--;
            else if (e.Delta > 0 && num < 99)
                num++;

            tbx.Text = num.ToString();
            textboxLevel_TextChanged(sender, null);
        }

        private void textbox_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste || e.Command == ApplicationCommands.Cut)
                e.Handled = true;
        }

        private void textboxLevel_LostFocus(object sender, RoutedEventArgs e)
        {
            textboxLevel_TextChanged(sender, null);
        }
    }
}

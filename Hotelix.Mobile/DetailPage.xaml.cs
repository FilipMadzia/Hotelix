using Hotelix.Mobile.Models;
using Microsoft.Maui.Controls;
using System;

namespace Hotelix.Mobile
{
    public partial class DetailPage : ContentPage
    {
        public Hotel SelectedHotel { get; set; }

        public DetailPage(Hotel selectedHotel)
        {
            InitializeComponent();
            SelectedHotel = selectedHotel;
            BindingContext = SelectedHotel;
            SetVisibility();
            ToggleDescriptionExpansionInitial();
        }

        private void SetVisibility()
        {
            if (string.IsNullOrEmpty(SelectedHotel.Contact?.PhoneNumber) && string.IsNullOrEmpty(SelectedHotel.Contact?.Email))
            {
                NoContactLink.IsVisible = true;
                PhoneLabel.IsVisible = false;
                PhoneLink.IsVisible = false;
                EmailLabel.IsVisible = false;
                EmailLink.IsVisible = false;
            }
            else
            {
                if (string.IsNullOrEmpty(SelectedHotel.Contact?.PhoneNumber))
                {
                    PhoneLabel.IsVisible = false;
                    PhoneLink.IsVisible = false;
                }
                else
                {
                    PhoneLink.Text = "Zadzwon";
                    NoContactLink.IsVisible = false;
                }

                if (string.IsNullOrEmpty(SelectedHotel.Contact?.Email))
                {
                    EmailLabel.IsVisible = false;
                    EmailLink.IsVisible = false;
                }
                else
                {
                    EmailLink.Text = "Wyslij maila";
                    NoContactLink.IsVisible = false;
                }
            }
        }

        bool isExpanded = false;

        private void OnLabelTapped(object sender, EventArgs e)
        {
            ToggleDescriptionExpansion();
        }

        private void OnMoreLabelTapped(object sender, EventArgs e)
        {
            ToggleDescriptionExpansion();
        }

        private void ToggleDescriptionExpansionInitial()
        {
            if (!string.IsNullOrWhiteSpace(DescriptionLabel.Text))
            {
                MoreLabel.Text = "wiêcej";
                MoreLabel.IsVisible = true;
            }
            else
            {
                MoreLabel.IsVisible = false;
            }
        }

        private void ToggleDescriptionExpansion()
        {
            if (DescriptionLabel.Text != null)
            {
                if (!isExpanded)
                {
                    DescriptionLabel.MaxLines = int.MaxValue;
                    MoreLabel.Text = "mniej";
                }
                else
                {
                    DescriptionLabel.MaxLines = 3;
                    MoreLabel.Text = "wiêcej";
                }

                isExpanded = !isExpanded;
            }
            else
            {
                MoreLabel.IsVisible = false;
            }
        }
    }
}

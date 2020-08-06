using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Starlight.Client.Rendering;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class MainMenuScreen : AbstractScreen
    {
        public MainMenuScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnLayout(StarlightGrid rootUI) {
            base.OnLayout(rootUI);

            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));

            var loginPanel = new StarlightGrid()
            {
                Background = new SolidBrush(Color.Gray),
                GridColumn = 1,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                ColumnSpacing = 0,
                RowSpacing = 0
            };
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Part));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Part));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Part));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Part));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.Widgets.Add(loginPanel);

            var loginLabel = new Label()
            {
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "Username",
                TextAlign = TextAlign.Center
            };
            loginPanel.Widgets.Add(loginLabel);

            var loginTextBox = new TextBox()
            {
                GridColumn = 0,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Myra.Graphics2D.Thickness(5, 0)
            };
            loginPanel.Widgets.Add(loginTextBox);

            var passwordLabel = new Label()
            {
                GridColumn = 0,
                GridRow = 2,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "Password",
                TextAlign = TextAlign.Center
            };
            loginPanel.Widgets.Add(passwordLabel);

            var passwordTextBox = new TextBox()
            {
                GridColumn = 0,
                GridRow = 3,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Myra.Graphics2D.Thickness(5, 0),
                PasswordField = true
            };
            loginPanel.Widgets.Add(passwordTextBox);

            var loginButton = new TextButton()
            {
                GridColumn = 0,
                GridRow = 4,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Myra.Graphics2D.Thickness(5, 2),
                Text = "Login"
            };
            loginPanel.Widgets.Add(loginButton);
        }
    }
}

using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Starlight.Client.Rendering;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Starlight.Client.Screens
{
    public class MainMenuScreen : AbstractScreen
    {
        StarlightGrid loginPanel;
        StarlightGrid registerPanel;

        public MainMenuScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnLayout(StarlightGrid rootUI) {
            base.OnLayout(rootUI);

            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            rootUI.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Auto));
            rootUI.RowsProportions.Add(new Proportion(ProportionType.Part));

            var centerGrid = new StarlightGrid()
            {
                GridColumn = 1,
                GridRow = 1
            };
            centerGrid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            centerGrid.RowsProportions.Add(new Proportion(ProportionType.Part));
            rootUI.Widgets.Add(centerGrid);

            var commandGrid = new StarlightGrid();
            commandGrid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            commandGrid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            commandGrid.ColumnsProportions.Add(new Proportion(ProportionType.Fill));
            centerGrid.Widgets.Add(commandGrid);

            BuildCommandPanel(commandGrid); 

            var panelGrid = new StarlightGrid()
            {
                Background = new SolidBrush(Color.Gray),
                GridColumn = 0,
                GridRow = 1,
                Width = 300,
                Height = 200
            };
            centerGrid.Widgets.Add(panelGrid);

            BuildLoginPanel(panelGrid);
            BuildRegisterPanel(panelGrid);
        }

        private void BuildCommandPanel(StarlightGrid rootUI) {
            var loginButton = new TextButton()
            {
                GridColumn = 0,
                GridRow = 0,
                Text = "Login",
                Padding = new Myra.Graphics2D.Thickness(5)
            };
            rootUI.Widgets.Add(loginButton);

            var registerButton = new TextButton()
            {
                GridColumn = 1,
                GridRow = 0,
                Text = "Register",
                Padding = new Myra.Graphics2D.Thickness(5)
            };
            rootUI.Widgets.Add(registerButton);

            loginButton.Click += LoginButton_Click;
            registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            HidePanels();
            registerPanel.Visible = true;
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            HidePanels();
            loginPanel.Visible = true;
        }

        private void BuildRegisterPanel(StarlightGrid rootUI) {
            registerPanel = new StarlightGrid()
            {
                Background = new SolidBrush(Color.Gray),
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                ColumnSpacing = 0,
                RowSpacing = 0
            };
            registerPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
            registerPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
            rootUI.Widgets.Add(registerPanel);

            var usernameLabel = new Label()
            {
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Text = "Username",
                TextAlign = TextAlign.Center
            };
            registerPanel.Widgets.Add(usernameLabel);

            var usernameTextBox = new TextBox()
            {
                GridColumn = 0,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Myra.Graphics2D.Thickness(5, 0)
            };
            registerPanel.Widgets.Add(usernameTextBox);

            registerPanel.Visible = false;
        }

        private void BuildLoginPanel(StarlightGrid rootUI) {
            loginPanel = new StarlightGrid()
            {
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                ColumnSpacing = 0,
                RowSpacing = 0
            };
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
            loginPanel.RowsProportions.Add(new Proportion(ProportionType.Auto));
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

        private void HidePanels() {
            loginPanel.Visible = false;
            registerPanel.Visible = false;
        }
    }
}

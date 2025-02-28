﻿using System;
using System.Collections.Generic;
using System.Text;

namespace menu
{
    public abstract class MenuPage : Page
    {
        protected Menu Menu { get; set; }

        public MenuPage(string title, MenuProgram program, params Option[] options)
            : base(title, program)
        {
            Menu = new Menu();

            foreach (var option in options)
                Menu.Add(option);
        }

        public override void Display()
        {
            base.Display();

            if (Program.NavigationEnabled && !Menu.Contains("Go back"))
                Menu.Add("Go back", () => { Program.NavigateBack(); });

            Menu.Display();
        }
    }
}

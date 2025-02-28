﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace menu
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public MenuProgram Program { get; set; }

        public Page(string title, MenuProgram program)
        {
            Title = title;
            Program = program;
        }

        public virtual void Display()
        {
            if (Program.History.Count > 1 && Program.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in Program.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                Console.WriteLine(breadcrumb);
            }
            else
            {
                Console.WriteLine(Title);
            }
            Console.WriteLine("---");
        }
    }
}

﻿using menu;
using System.Text;
using universal.entropic.compression.Menu.Encoder;

namespace universal.entropic.compression.Menu
{
    public class MainPage : MenuPage
    {
       
        public MainPage(MenuProgram menu)
             : base("TGA - Teoria da Informação", menu,
                   new Option("Encoder", () => menu.NavigateTo<Encode>()),
                   new Option("Decoder", () => menu.NavigateTo<Decoder>()),
                   new Option("CRC-8 + Hamming", () => menu.NavigateTo<CRC8>()),
                   new Option("Entropy Calc", () => menu.NavigateTo<Entropy>()))
        {
        }
    }
}


using menu;
using System;
using System.Collections.Generic;
using System.Text;
using universal.entropic.compression.Menu.Encoder;

namespace universal.entropic.compression.Menu
{
    public class MainMenu : MenuProgram
    {
        public MainMenu()
            : base("TGA - Teoria da Informação", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new Encode(this));
            AddPage(new Decoder(this));
            AddPage(new EUnary(this));        
            AddPage(new DUnary(this));
            AddPage(new DGolomb(this));
            AddPage(new EGolomb(this));           
            AddPage(new EDelta(this));
            AddPage(new DDelta(this));
            AddPage(new DFibonacci(this));
            AddPage(new EFibonacci(this));
            AddPage(new EEliasGamma(this));
            AddPage(new DEliasGamma(this));
            AddPage(new AliceEncodeUnary(this));
            AddPage(new AliceDecodeUnary(this));
            AddPage(new AliceDecodeGolomb(this));
            AddPage(new AliceEncodeGolomb(this));
            AddPage(new AliceDecodeEliasGamma(this));
            AddPage(new AliceEncodeEliasGamma(this));
            AddPage(new AliceDecodeFibonacci(this));
            AddPage(new AliceEncodeFibonacci(this));
            AddPage(new AliceEncodeDelta(this));
            AddPage(new AliceDecodeDelta(this));
            AddPage(new SumDecodeDelta(this));
            AddPage(new SumDecodeEliasGamma(this));
            AddPage(new SumDecodeFibonacci(this));
            AddPage(new SumDecodeGolomb(this));
            AddPage(new SumDecodeUnary(this));
            AddPage(new SumEncodeDelta(this));
            AddPage(new SumEncodeEliasGamma(this));
            AddPage(new SumEncodeFibonacci(this));
            AddPage(new SumEncodeGolomb(this));
            AddPage(new SumEncodeUnary(this));





            

            SetPage<MainPage>();
        }
    }
}

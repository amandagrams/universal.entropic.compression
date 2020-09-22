using menu;

namespace universal.entropic.compression.Menu
{
    class Decoder : MenuPage
    {
        public Decoder(MenuProgram menu)
           : base("Decoder", menu,
                 new Option("Unary", () => menu.NavigateTo<DUnary>()),
                 new Option("Golomb", () => menu.NavigateTo<DGolomb>()),
                 new Option("Elias Gamma", () => menu.NavigateTo<DEliasGamma>()),
                 new Option("Fibonacci", () => menu.NavigateTo<DFibonacci>()),
                 new Option("Delta", () => menu.NavigateTo<DDelta>()))
        {
        }
    }
}

using menu;

namespace universal.entropic.compression.Menu.Encoder
{
    public class Encode : MenuPage
    {
        public Encode(MenuProgram menu)
           : base("Encoder", menu,
                 new Option("Unary", () => menu.NavigateTo<EUnary>()),
                 new Option("Golomb", () => menu.NavigateTo<EGolomb>()),
                 new Option("Elias Gamma", () => menu.NavigateTo<EEliasGamma>()),
                 new Option("Fibonacci", () => menu.NavigateTo<EFibonacci>()),
                 new Option("Delta", () => menu.NavigateTo<EDelta>()))
        {
        }
    }
}

namespace Grapher.Scale
{
    //handle conversion from default scales (linear frequency, milliseconds,etc) to table scale
    //idk im lost on how it work but it does
    public interface IScale
    {
        double GetScaled(double notscaled);

        double GetMin();
        double GetMax();

        double To01(double notscaled);
    }
}

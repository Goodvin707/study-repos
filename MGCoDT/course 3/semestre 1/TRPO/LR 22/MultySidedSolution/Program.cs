using System;

namespace MultySidedSolution
{
    interface ITarget
    {
        double CalculateDp(int T0, int dT);
        void ModifMass(double dm);
        String GetData();
    }
    class GasBalloon
    {
        public double volume { get; set; }
        public double mass { get; set; }
        public double molar { get; set; }
        const double R = 8.31;
        public GasBalloon(double volume, double mass, double molar)
        {
            this.volume = volume;
            this.mass = mass;
            this.molar = molar;
        }
        public double GetPressure(double T)
        {
            return (mass * R * T) / (molar * volume);
        }
        public double AmountOfMatter()
        {
            return mass / molar;
        }
        public override string ToString()
        {
            return $"Объём [{volume} м^3] | Масса газа [{mass} кг] | Молярная масса [{molar} кг/моль]";
        }
    }
    class Adapter : ITarget
    {
        GasBalloon adapted;
        public Adapter(GasBalloon gb)
        {
            adapted = gb;
        }
        public double CalculateDp(int T0, int dT)
        {
            return adapted.GetPressure(dT) - adapted.GetPressure(T0);
        }
        public void ModifMass(double dm)
        {
            adapted.mass += dm;
        }
        public String GetData()
        {
            return adapted.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var gb = new GasBalloon(60, 5, 0.0064);
            Console.WriteLine(gb.ToString());

            ITarget target = new Adapter(gb);
            target.ModifMass(10);
            Console.WriteLine(target.GetData());
            Console.ReadKey();
        }
    }
}
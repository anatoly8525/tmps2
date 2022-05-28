using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adapter
{
    interface IScales
    {
        float Getweight();
    }

    class RussianScales: IScales
    {
        private float currentweight;
        public RussianScales(float cw) => this.currentweight = cw;
        public float Getweight() => currentweight;
    }

    class BritishScales
    {
        private float currentweight;
        public BritishScales(float cw) => this.currentweight = cw;
        public float Getweight() => currentweight;
        
    }

    class AdapterForBritishScales : IScales
    {
        BritishScales britishScales;
        public AdapterForBritishScales(BritishScales britishScales) => this.britishScales = britishScales;

        public float Getweight() => britishScales.Getweight() * 0.453f;
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            float kg = 55.0f;
            float lb = 55.0f;

            IScales rScales = new RussianScales(kg);
            IScales bScales = new AdapterForBritishScales((new BritishScales(lb)));
            
            Console.WriteLine(rScales.Getweight());
            Console.WriteLine(bScales.Getweight());
        }
    }
}
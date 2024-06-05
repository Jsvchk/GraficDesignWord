namespace PatternAdapter{

    interface Iscales{
        float GetWeight();
    }
    class UAscales: Iscales{
        private float currentWeight;
        public UAscales(float cw) => this.currentWeight = cw;
        public float GetWeight() => currentWeight;
    }
    class USAscales {
        float currentWeight;
        public USAscales(float cw) => this.currentWeight = cw;
        public float GetWeight() => currentWeight;
    }
    class AdapterForUSAscales: Iscales{
        USAscales uSAscales;
        public AdapterForUSAscales(USAscales uSAscales) => this.uSAscales = uSAscales;
        public float GetWeight() =>uSAscales.GetWeight() * 0.453f;
    }
    class Program{
        static void Main (string[]args){
            float kg = 78.0f; // кілограми 
            float lb = 78.0f; // фунти
            Iscales uaScales = new UAscales(kg);
            Iscales usaScales = new AdapterForUSAscales(new USAscales(lb));

            Console.WriteLine(uaScales.GetWeight()); // виводимо кілограми
            Console.WriteLine(usaScales.GetWeight()); // виводимо відкориговану вагу (перевели фунти в кілограми)
        }
    }
}

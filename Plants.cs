using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public class Plants
    {
        public static Random rnd = new Random();
        public float height = 0;
        public virtual string GetInfo()
        {
            var str = string.Format("\nВысота: {0}", this.height);
            return str;
        }
    }
        // Цветы
        public enum FlowerColor { черный, зеленый, розовый, оранжевый, красный, белый };
        public enum FlowerType { роза, одуванчик, мак, лилии, пионы };
    public class Flowers : Plants
    {
        public int numbOfPetals = 0; // число лепестков
        public FlowerColor color = FlowerColor.розовый;
        public FlowerType type = FlowerType.лилии;
        public override string GetInfo()
        {
            var str = "Я Цветок";
            str += base.GetInfo() + string.Format("\nЧисло лепестков: {0}", this.numbOfPetals) + string.Format("\nЦвет: {0}", this.color) + string.Format("\nТип: {0}", this.type);
            return str;
        }
        public static Flowers Generate()
        {
            return new Flowers
            {
                height = rnd.Next() % 60, 
                numbOfPetals = 5 + rnd.Next() % 20,
                color = (FlowerColor)rnd.Next(Enum.GetValues(typeof(FlowerColor)).Length),
                type = (FlowerType)rnd.Next(Enum.GetValues(typeof(FlowerType)).Length)
            };

        }
    }
        // Кустарники

        public class Shrubs : Plants
        {
            public bool flowers = true;
            public int numbOfSprigs = 0; // количество веточек
        public override string GetInfo()
        {
            var str = "Я Кустарник";
            str += base.GetInfo() + string.Format("\nКоличество веточек: {0}", this.numbOfSprigs) + string.Format("\nНаличие цветов: {0}", this.flowers);
            return str;
        }
        public static Shrubs Generate()
        {
            return new Shrubs
            {
                height = 100 + rnd.Next() % 100, // спелость от 0 до 100
                flowers = rnd.Next() % 2 == 0,
                numbOfSprigs = 50 + rnd.Next() % 300, // количество долек от 5 до 25
            };

        }
    }

        // Деревья
        public enum TreesType { хвойное, листовое };
        public class Trees : Plants
        {
            public TreesType type = TreesType.хвойное;
            public  float radius = 0;
        public override string GetInfo()
        {
            var str = "Я Дерево";
            str += base.GetInfo() + string.Format("\nРадиус дерева: {0}", this.radius) + string.Format("\nТип дерева: {0}", this.type);
            return str;
        }
        public static Trees Generate()
        {
            return new Trees
            {
                height = 100 + rnd.Next() % 1000, // спелость от 0 до 100
                type = (TreesType)rnd.Next(Enum.GetValues(typeof(TreesType)).Length),
                radius = 50 + rnd.Next() % 300, // количество долек от 5 до 25
            };

        }
    }
}

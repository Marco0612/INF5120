

// See https://aka.ms/new-console-template for more information

using System;

class Prograama{

    static void Main()
    {
        double x = 1.23, y = 2.34, z = 3.45,  w =4.56;

        double numerador  = (0.045*x + 2.33*y)*x*y*z*w;
        double exponente = 2.1*Math.Pow(z,x +7.3*w/(9.2*z - x*y));


    //    double form = (0.045*x +2.33*y)/(2.1*Math.Pow(z,(x+(7.3*w)/(9.2*z-x*y)))-z*4.5/w)*x*y*z*w);
        //Console.WriteLine(form);
        Console.WriteLine($"El resultado es: {numerador/(exponente -z*4.5/w)}");

        
    }


}
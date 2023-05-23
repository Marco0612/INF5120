class Corro
{   static void Main()
    {
        Complex a = new Complex(3,2);
        Complex b = new Complex(1,4);

        Console.WriteLine($"{a} + {b} = {a+b}");
        Console.WriteLine($"{a} - {b} = {a-b}");
        Console.WriteLine($"{a} * {b} = {a*b}");
        Console.WriteLine($"{a} / {b} = {a/b}");
    }
}

class Complex{
    private double parte_real;
    private double parte_img;
    public Complex(double real, double img)
    {
        parte_real = real;
        parte_img = img;
    }

    public double get_real()
    {
        return parte_real;
    }
    public double get_img()
    {
        return parte_img;
    }

    public static Complex operator + (Complex a, Complex b)
    {
        Complex nuevo = new Complex(a.get_real()+a.get_real(), b.get_img() +b.get_img());
        return nuevo;
    }
    public static Complex operator - (Complex a, Complex b)
    {
        Complex nuevo = new Complex(a.get_real()-b.get_real(), a.get_img() -b.get_img());
        return nuevo;
    }
    public static Complex operator * (Complex a, Complex b)
    {
        Complex nuevo = new Complex(a.get_real()*b.get_real()-a.get_img()*b.get_img(), a.get_real()*b.get_img() +a.get_img()*b.get_real());
        return nuevo;
    }
    public static Complex operator / (Complex a, Complex b)
    {
        double real = (a.get_real()*b.get_real()+a.get_img()*b.get_img()) / (Math.Pow(b.get_real(),2) + Math.Pow(b.get_img(),2));
        double img = (-a.get_real()*b.get_img() +a.get_img()*b.get_real()) / (Math.Pow(b.get_real(),2) + Math.Pow(b.get_img(),2));

        return new Complex(real, img);
    }
    public override string ToString()
    {
        if(parte_img > 0)
        {
            return$"({parte_real} + {parte_img}i)";
        }
        return$"({parte_real} - {Math.Abs(parte_img)}i)";
    }
}
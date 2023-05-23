// See https://aka.ms/new-console-template for more information
class Correr
{

static void Main()
{
    Shape shape = new Shape();
    Console.WriteLine(shape);
    shape.set_color("rojo");
    Shape shape1 = new Shape("amarillo", false);
    Console.WriteLine(shape1);
    Console.WriteLine();

    Circulo circ1 = new Circulo();
    Console.WriteLine(circ1);
    Circulo circ2 = new Circulo(3);
    Console.WriteLine(circ2);
    Circulo circ3 = new Circulo(3, "amarillo", false);
    Console.WriteLine(circ3);
    Console.WriteLine();


    Rectangulo rec1 = new Rectangulo();
    Console.WriteLine(rec1);

    Rectangulo rec2 = new Rectangulo(4, 5);
    Console.WriteLine(rec2);

    Rectangulo rec3 = new Rectangulo(4, 5, "Rosado", true);
    Console.WriteLine(rec3);

    Console.WriteLine();

    Cuadrado cua = new Cuadrado();
    Console.WriteLine(cua);
    Cuadrado cua1 = new Cuadrado(3);
    Console.WriteLine(cua1);
    Cuadrado cua2 = new Cuadrado(3, "azul", false);
    Console.WriteLine(cua2);
}

class Shape{

    private string color;
    private bool isfilled;

    public Shape()
    {
        color = "verde";
        isfilled = true;
    }
    public Shape(string color, bool filled)
    {  
        this.color = color;
        this.isfilled = filled;
    }

    public void set_color(string color)
    {
        this.color = color;
    }

    public void set_filled(bool filled)
    {
        this.isfilled = filled;
    }

    public string get_color()
    {
        return  color;
    }
    public bool get_filled()
    {
        return  isfilled;
    }

    public override string ToString()
    {
        if(isfilled){
            return $"Una figuna de color {color} que está llena.";
        }

        return $"Una figuna de color {color} que NO está llena.";
    }
}


class Rectangulo: Shape
{
    private double lado;
    private double ancho;


    public Rectangulo():base()
    {
        lado = 1.0;
        ancho = 1.0;
    }
    public Rectangulo(double lado, double ancho):base()
    {
        this.lado = lado;
        this.ancho = ancho;
    }
    public Rectangulo(double lado, double ancho, string color, bool filled):base(color, filled)
    {
        this.lado = lado;
        this.ancho = ancho;
    }
    public double get_lado()
    {
        return  lado;
    }
    public virtual void set_lado(double lado)
    {
        this.lado = lado;
    }
     public double get_ancho()
    {
        return  ancho;
    }
    public virtual void set_ancho(double lado)
    {
        this.ancho = lado;
    }

    public double get_Area(){
        return lado*ancho;
    }

    public double get_Peremeter(){
        return 2*lado+2*ancho;
    }
    public override string ToString()
    {
        return $"Un Rectangulo de lado {lado} y ancho {ancho}, que es una subclase de {base.ToString()}";
    }

}

class Cuadrado: Rectangulo{
    public Cuadrado(): base(1.0, 1.0)
    {}
    public Cuadrado(double lado): base(lado, lado)
    {}
    public Cuadrado(double lado, string color, bool filled): base(lado, lado, color, filled)
    {}

    public void set_side(double side)
    {
        this.set_ancho(side);
        this.set_lado(side);
    }

    public override void set_ancho(double side)
    {
        this.set_ancho(side);
        this.set_lado(side);
    }

    public override void set_lado(double side)
    {
        this.set_ancho(side);
        this.set_lado(side);
    }
    public double  get_side()
    {
        return this.get_ancho();

    }

    public override string ToString()
    {
        return $"Un Cuadrado de lado {this.get_side()}, que es una subclase de {base.ToString()}";;
    }
}

class Circulo: Shape{
    private double radius;
    public Circulo(): base()
    {
        radius = 1.0;
    }
    public Circulo(double r): base()
    {
        radius = r;
    }

    public Circulo(double r,string color, bool filled): base(color, filled)
    {
        radius = r;
    }

    public void setRadius(double r){
        radius  = r;
    }

    public double getRadius(double r)
    {
        return radius;
    }
    public double getArea()
    {
        return radius*radius*Math.PI;
    }
    public double getPerimeter()
    {
        return 2*radius*Math.PI;
    }

    public override string ToString()
    {
        return $"Un Circulo de radio {radius}, que es una subclase de {base.ToString()}";
    }


}
}
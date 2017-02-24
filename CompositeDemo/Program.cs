using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDemo
{
    using Composite;

    class Program
    {
        static void Main(string[] args)
        {
            var tec = new RoomGroup("Tec");

            var a1 = new RoomGroup("Aulas 1");
            var a11 = new ClassRoom("Salón 101");
            var a12 = new ClassRoom("Salón 102");
            a1.AddRoom(a11);
            a1.AddRoom(a12);
            tec.AddRoom(a1);

            var a2 = new RoomGroup("Aulas 2");
            var a21 = new ClassRoom("Salón 201");
            var a22 = new ClassRoom("Salón 202");
            a2.AddRoom(a21);
            a2.AddRoom(a22);
            tec.AddRoom(a2);

            a11.AddEvent("Clase de arquitectura");
            a12.AddEvent("Reunion con familiares del Dr. Lavariega");
            a1.AddEvent("Conferencia arquitectónica");
   
            a21.AddEvent("Platica con el Dr Lavariega");
            a2.AddEvent("Galería de patrones");

            tec.AddEvent("Conferencia magna sobre aquitectura");

            Console.WriteLine(tec.Schedule(0));
        }
    }
}

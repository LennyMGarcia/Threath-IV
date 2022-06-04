using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threath_IV
{
    class Program
    {
        static void Main(string[] args)
        {//lo que esto es ver si la tarea termina para luego pasar a la otra
            var tareaTerminada = new TaskCompletionSource<bool>();

            var hilo1 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 1");
                    Thread.Sleep(1000);
                }
                //esto dice que cuando el flujo de ejuccion termina aqui da por terminada la tarea de este hilo
               tareaTerminada.TrySetResult(true);

            });
         
            

            var hilo2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 2");
                    Thread.Sleep(1000);
                }

            });

            var hilo3 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Hilo 3");
                    Thread.Sleep(1000);
                }
                tareaTerminada.TrySetResult(true);

            });

            hilo1.Start();
           
            

            hilo2.Start();

            //esto dice que le diga el resultado de la trea terminada que se llama asi
            var resultado = tareaTerminada.Task.Result;

            hilo3.Start();

            

        }
    }
}

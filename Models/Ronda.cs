using ProyectoSistemasOperativos.ViewModels;
using ProyectoSistemasOperativos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;

namespace ProyectoSistemasOperativos.Models
{
    public class Ronda
    {
        public static Canvas canvas { get; set; }
        public static Canvas canvas2 { get; set; }
        public static RondaView clase { get; set; }
        public static Grid miStackPanel { get; set; }
        public static Grid Titulos { get; set; }
        public static Grid ProcesosNombres { get; set; }

        public static List<ProcesoViewModel> Resolver(List<ProcesoViewModel> lista)
        {
            List<ProcesoViewModel> Listos = new();
            ProcesoViewModel Auxiliar = new();
            ProcesoViewModel Nuevo = new();
            ProcesoViewModel Ultimo = new();
            List<ProcesoViewModel> ordenados = lista.OrderBy(p => p.TiempoLlegada).ToList();
            

            int totalTiempoCPU = 0;
            foreach (var item in lista)
            {
                totalTiempoCPU += item.TiempoCPU;
            }

            for (int i = 0; i < totalTiempoCPU+1; i++)
            {
                bool ultimoeliminado = false;
                if(Listos.Count > 0)
                {
                    Listos.First().TiempoCPURestante = Listos.First().TiempoCPURestante-1;
                    Listos.First().TiemposEjecucion.Add(i-1);
                    if(Listos.First().TiempoCPURestante == 0)
                    {
                        Listos.First().TiempoFinal = i;
                        Listos.Remove(Listos.First());
                        ultimoeliminado = true;
                    }
                    else
                    {
                        Auxiliar = Listos.First();
                        Listos.Remove(Listos.First());
                        Listos.Add(Auxiliar);
                    }
                }

                foreach (var item in ordenados)
                {
                    if(i== item.TiempoLlegada)
                    {
                        if(Listos.Count > 0 && (!ultimoeliminado))
                        {
                            Auxiliar = Listos.Last();
                            Listos.Remove(Listos.Last());
                            Listos.Add(item);
                            Listos.Add(Auxiliar);
                        }
                        else
                        {
                            Listos.Add(item);
                        }

                        break;
                    }
                }

                

                
            }


            return lista;
        }

        public static void Dibujar(List<ProcesoViewModel> lista)
        {
            Titulos.ColumnDefinitions.Clear();
            Titulos.Children.Clear();
            ProcesosNombres.Children.Clear();
            ProcesosNombres.RowDefinitions.Clear();
            int totalTiempoCPU = 0;
            foreach (var item in lista)
            {
                totalTiempoCPU += item.TiempoCPU;
            }

            double AnchoCuadrado = canvas.ActualWidth / totalTiempoCPU;
            canvas.Height = miStackPanel.Height;
            double AltoCuadrado = (canvas.ActualHeight-35) / lista.Count+1;
            canvas2.Height = AltoCuadrado;

            char letra = 'A';
            for (int i = 0; i < totalTiempoCPU; i++)
            {
                ColumnDefinition c = new();
                c.Width = new GridLength(Titulos.ActualWidth / (totalTiempoCPU));
                Titulos.ColumnDefinitions.Add(c);
                Label l = new();
                l.Content = i + 1;
                l.FontSize = 16;
                l.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(l, i);
                Titulos.Children.Add(l);
            }

            for (int i = 0; i < lista.Count; i++)
            {
                RowDefinition r = new();
                r.Height = new GridLength(AltoCuadrado);
                ProcesosNombres.RowDefinitions.Add(r);
                Label l = new();
                l.Content = letra++;
                l.FontSize = 16;
                l.HorizontalAlignment = HorizontalAlignment.Center;
                l.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(l, i);
                ProcesosNombres.Children.Add(l);

            }

            for (int j = 0; j < lista.Count; j++)
            {
                for (int i = 0; i < totalTiempoCPU; i++)
                {
                    SolidColorBrush Color;
                    if (i < lista[j].TiempoLlegada)
                    {
                        Color = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        Color = new SolidColorBrush(Colors.Gray);
                        foreach (var item2 in lista[j].TiemposEjecucion)
                        {
                            if (item2 == i)
                            {
                                Color = new SolidColorBrush(lista[j].ColorFondo);
                                DibujarProcesosCPU(AltoCuadrado, AnchoCuadrado, lista[j], i);
                                break;
                            }
                        }
                    }
                    if (i >= lista[j].TiempoFinal) Color = new SolidColorBrush(Colors.White);

                    Rectangle r = new();
                    r.Width = AnchoCuadrado;
                    r.Height = AltoCuadrado;
                    r.Stroke = new SolidColorBrush(Colors.Black);
                    r.Fill = Color;
                    Canvas.SetLeft(r, AnchoCuadrado * i);
                    Canvas.SetTop(r, AltoCuadrado * j);
                    clase.AgregarRectangulo(r);
                }
            }
        }

        public static void DibujarProcesosCPU(double alto, double ancho, ProcesoViewModel p, int i)
        {
            Rectangle r = new();
            r.Width = ancho;
            r.Height = alto;
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.Fill = new SolidColorBrush(p.ColorFondo);
            Canvas.SetLeft(r, ancho * i);
            clase.AgregarRectangulo2(r);
        }
    }
}

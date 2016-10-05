using System.Collections.Generic;
using System.Linq;
using Mandelbrot.Models;

namespace Mandelbrot
{
    public static class PresetsHandler
    {
        public static List<Preset> presets = new List<Preset>()
        {
            {
                new Preset() {
                    Name = "Overview",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = -1.6,
                        CenterY = -1.6,
                        Scale = 0.005,
                        Max = 1000,
                        ColorScheme = ColorSchemes.BlueGreen
                    }
                }
            },
            {
                new Preset() {
                    Name = "Towers",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.438793517456055,
                        CenterY = 0.342581103686523,
                        Scale = 1.70909423828125E-06,
                        Max = 200,
                        ColorScheme = ColorSchemes.RedGreen
                    }
                }
            },
              new Preset(){
                    Name = "Crack",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.337684609375,
                        CenterY = 0.573904396875,
                        Scale = 9.765625E-07,
                        Max = 200,
                        ColorScheme = ColorSchemes.BlueGreen
                    }
                },
            {
                new Preset(){
                    Name = "Aura",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.439261809277344,
                        CenterY = 0.343060077346802,
                        Scale = 1.06818389892578E-07,
                        Max = 200,
                        ColorScheme = ColorSchemes.MultiColor
                    }
                }
            },
            {
                new Preset(){
                    Name = "Spiral",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = -0.7463970546875,
                        CenterY = -0.134127125,
                        Scale = 1.019140625E-05,
                        Max = 2500,
                        ColorScheme = ColorSchemes.BlueGreen
                    }
                }
            },
            {
                new Preset(){
                    Name = "Vortex",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = -0.743307505996704,
                        CenterY = -0.131193313735961,
                        Scale = 9.95254516601565E-09,
                        Max = 1000,
                        ColorScheme = ColorSchemes.MultiColor
                    }
                }
            }
        };

        public static UserInputParameters GetPresets(string presetName)
        {
            return presets.Single(x => x.Name == presetName).InputParameters;
        }
    }
}


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
                    Name = "Mooi",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.438793517456055,
                        CenterY = 0.342581103686523,
                        Scale = 1.70909423828125E-06,
                        Max = 200,
                        ColorScheme = "RedGreen"
                    }
                }
            },
              new Preset(){
                    Name = "Blobs",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.33695703125,
                        CenterY = 0.57427734375,
                        Scale = 1.953125E-06,
                        Max = 200,
                        ColorScheme = "BlueGreen"
                    }
                },
            {
                new Preset() {
                    Name = "Nog mooier",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = -1.6,
                        CenterY = -1.6,
                        Scale = 0.005,
                        Max = 1000,
                        ColorScheme = "BlueGreen"
                    }
                }
            },
            {
                new Preset(){
                    Name = "Ook mooi",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.439261809277344,
                        CenterY = 0.343060077346802,
                        Scale = 1.06818389892578E-07,
                        Max = 200,
                        ColorScheme = "MultiColor"
                    }
                }
            },
            {
                new Preset(){
                    Name = "Maaike",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = -0.7463970546875,
                        CenterY = -0.134127125,
                        Scale = 1.019140625E-05,
                        Max = 2500,
                        ColorScheme = "BlueGreen"
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


using System.Collections.Generic;
using System.Linq;
using Mandelbrot.Models;

namespace Mandelbrot
{
    public static class PresetsHandler
    {
        private static List<Preset> presets = new List<Preset>()
        {
            {
                new Preset() {
                    Name = "Mooi",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.437853515625,
                        CenterY = 0.34181884765625,
                        Scale = 0.34181884765625E-5,
                        Max = 200,
                        ColorScheme = "RedGreen"
                    }
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
            }
        };

        public static UserInputParameters GetPresets(string presetName)
        {
            return presets.Single(x => x.Name == presetName).InputParameters;
        }
    }
}


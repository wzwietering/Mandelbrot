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
                    Name = "Preset1",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 0.437853515625,
                        CenterY = 0.34181884765625,
                        Scale = 0.34181884765625,
                        Max = 200
                    }
                }
            },
            {
                new Preset() {
                    Name = "Preset2",
                    InputParameters = new UserInputParameters()
                    {
                        CenterX = 1.6,
                        CenterY = 1.6,
                        Scale = 0.05,
                        Max = 1000
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


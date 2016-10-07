namespace Mandelbrot.Models
{
    /// <summary>
    /// A preset item. Contains preset values for the user input parameters.
    /// A user can select a preset to have the application show a nice image.
    /// </summary>
    public class Preset
    {
        /// <summary>
        /// Name of the preset that will appear in the menu.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameters that go with this preset name.
        /// </summary>
        public UserInputParameters InputParameters { get; set; }

    }
}

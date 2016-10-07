namespace Mandelbrot.Models
{
    /// <summary>
    /// This class creates some constant values, for example long texts, because we don't want this
    /// rubbish in our code, for obvious reasons.
    /// </summary>
    public static class Constants
    {
        public const string userGuideText = 
            @"Welcome to the mandelbrot generator. With this application you can generate 
beautiful images based on the mandelbrot formula!

Try some preset images from the top menu > presets, or play around using the following hotkeys:

Left mouse button: zoom in towards the spot you clicked.
Right mouse button: zoom out towards te spot you clicked.
Ctrl + minus: zoom out.
Ctrl + Shift + plus: zoom in.
Ctrl + arrow keys: move around.
Mousewheel: zoom.
            
You can change the color settings using the colorscheme dropdown, and you can also enter your own values into the boxes for x- and y-coordinates, scale and max value. 

If you find a very nice image you can save it using the top menu > image > save.

Have fun creating beautiful images!";
    }
}
